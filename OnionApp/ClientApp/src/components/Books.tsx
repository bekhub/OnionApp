import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as BooksStore from '../store/Books';
import {Link} from "react-router-dom";

type BooksProps = 
    BooksStore.BookState 
    & typeof BooksStore.actionCreators
    & RouteComponentProps<{startIndex: string}>;

class Books extends React.PureComponent<BooksProps> {
    public componentDidMount() {
        this.ensureDataFetched();
    }
    
    public componentDidUpdate() {
        this.ensureDataFetched();
    }
    
    public render() {
        return (
            <React.Fragment>
                <h1 id="tabelLabel">Books</h1>
                {this.renderBooksTable()}
                {this.renderPagination()}
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        const startIndex = parseInt(this.props.match.params.startIndex, 10) || 0;
        this.props.requestBooks(startIndex);
    }

    private renderBooksTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Price</th>
                </tr>
                </thead>
                <tbody>
                {this.props.books.map((book: BooksStore.Book) =>
                    <tr key={book.id}>
                        <td>{book.id}</td>
                        <td>{book.name}</td>
                        <td>{book.price}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    private renderPagination() {
        const prevStartIndex = (this.props.startIndex || 0) - 5;
        const nextStartIndex = (this.props.startIndex || 0) + 5;

        return (
            <div className="d-flex justify-content-between">
                <Link className='btn btn-outline-secondary btn-sm'
                      to={`/books/${prevStartIndex}`}>Previous</Link>
                {this.props.isLoading && <span>Loading...</span>}
                <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-data/${nextStartIndex}`}>Next</Link>
            </div>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.books,
    BooksStore.actionCreators
)(Books as any);
