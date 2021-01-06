import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

export interface BookState {
    isLoading: boolean;
    startIndex?: number;
    books: Book[];
}

export interface Book {
    id: number;
    name: string;
    price: number;
}

interface RequestBooksAction {
    type: 'REQUEST_BOOKS';
    startIndex: number;
}

interface ReceiveBooksAction {
    type: 'RECEIVE_BOOKS';
    startIndex: number;
    books: Book[];
}

type KnownAction = RequestBooksAction | ReceiveBooksAction;

export const actionCreators = {
    requestBooks: (startIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        const appState = getState();
        if(appState && appState.books && startIndex !== appState.books.startIndex) {
            fetch(`books`)
                .then(response => response.json() as Promise<Book[]>)
                .then(data => {
                    dispatch({
                        type: 'RECEIVE_BOOKS',
                        startIndex: startIndex,
                        books: data
                    });
                });
            dispatch({
                type: 'REQUEST_BOOKS',
                startIndex: startIndex
            });
        }
    }
}

const unloadedState: BookState = {books: [], isLoading: false};

export const reducer: Reducer<BookState> = (state: BookState | undefined, incomingAction: Action): BookState => {
    if (state === undefined) {
        return unloadedState;
    }
    
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case "REQUEST_BOOKS":
            return {
                startIndex: action.startIndex,
                books: state.books,
                isLoading: true
            }
        case "RECEIVE_BOOKS":
            if (action.startIndex === state.startIndex) {
                return {
                    startIndex: action.startIndex,
                    books: action.books,
                    isLoading: false
                }
            }
            break;
    }
    
    return state;
};
