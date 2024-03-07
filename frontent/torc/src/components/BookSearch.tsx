import React, { useState } from 'react';
import axios from 'axios';

interface Book {
  title: string;
  publisher: string;
  author: string;
  coverType: string;
  isbn: string;
  availableCopies: string;
  category: string;
}

const BookSearch: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchType, setSearchType] = useState<number>(0);
  const [books, setBooks] = useState<Book[]>([]);

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    try {
      const response = await axios.get('https://localhost:7121/BookSearch', {
        params: {
          searchTem: searchTerm,
          searchType: searchType,
          skip: 0,
          top: 10
        }
      });

      setBooks(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label>
          Search Term:
          <input
            type="text"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </label>
        <label>
          Search Type:
          <select
            value={searchType}
            onChange={(e) => setSearchType(Number(e.target.value))}
          >
            <option value={0}>Option 0</option>
            <option value={1}>Option 1</option>
            {/* Add more options as needed */}
          </select>
        </label>
        <button type="submit">Search</button>
      </form>

      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Publisher</th>
            <th>Author</th>
            <th>Cover Type</th>
            <th>ISBN</th>
            <th>Available Copies</th>
            <th>Category</th>
          </tr>
        </thead>
        <tbody>
          {books.map((book, index) => (
            <tr key={index}>
              <td>{book.title}</td>
              <td>{book.publisher}</td>
              <td>{book.author}</td>
              <td>{book.coverType}</td>
              <td>{book.isbn}</td>
              <td>{book.availableCopies}</td>
              <td>{book.category}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BookSearch;
