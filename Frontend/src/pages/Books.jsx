import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { bookService } from '../api/booksService';

export default function Books() {
  const [books, setBooks] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const data = await bookService.getAllBooks();
        setBooks(data);
      } catch (err) {
        setError('Failed to fetch books');
        console.error(err);
      } finally {
        setIsLoading(false);
      }
    };

    fetchBooks();
  }, []);

  if (isLoading) return <div>Loading books...</div>;
  if (error) return <div>{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-2xl font-bold">Books</h2>
        <Link 
          to="/books/add" 
          className="bg-indigo-600 text-white px-4 py-2 rounded-md hover:bg-indigo-700"
        >
          Add Book
        </Link>
      </div>
      
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {books.map(book => (
          <div key={book.id} className="border rounded-lg p-4 hover:shadow-md transition-shadow">
            <h3 className="font-bold text-lg">{book.title}</h3>
            <p className="text-gray-600">{book.author}</p>
            <Link 
              to={`/books/${book.id}`} 
              className="mt-2 inline-block text-indigo-600 hover:text-indigo-800"
            >
              View Details
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}