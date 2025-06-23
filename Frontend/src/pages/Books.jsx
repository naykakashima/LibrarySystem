import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { bookService } from '../api/booksService';
import  { getCurrentUserRole }  from '../api/auth';
import { motion } from "motion/react";

export default function Books() {
  const [books, setBooks] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState('');
  const [ isAdmin, setIsAdmin ] = useState(false); 

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const role = getCurrentUserRole();
        setIsAdmin(role === 'Admin')
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

        { isAdmin && 
        
        <Link 
          to="/books/add" 
          className="bg-indigo-600 text-white px-4 py-2 rounded-md hover:bg-indigo-700"
        >
          Add Book
        </Link> 
        
        }
        
      </div>
      
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {books.map((book, i) => (
          <motion.div
            key={book.id}
            initial={{ y: 30, opacity: 0 }}
            animate={{ y: 0, opacity: 1 }}
            transition={{ delay: i * 0.1, duration: 0.4 }}
            className="bg-white rounded-xl p-5 border border-gray-200 shadow-[inset_0_1px_0_rgba(255,255,255,0.1),0_4px_6px_-1px_rgba(0,0,0,0.05)] hover:shadow-md transition-shadow"
          >
            <h3 className="font-bold text-lg text-gray-800">{book.title}</h3>
            <p className="text-gray-600">{book.author}</p>
            <Link 
              to={`/books/${book.id}`} 
              className="mt-2 inline-block text-indigo-600 hover:text-indigo-800"
            >
              View Details
            </Link>
          </motion.div>
        ))}
      </div>
    </div>
  );
}