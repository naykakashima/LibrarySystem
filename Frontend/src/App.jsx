import React, { useState, useEffect } from 'react';
import BookList from './components/BookList';
import AddBookModal from './components/AddBookModal';
import EditBookModal from './components/EditBookModal';
import Header from './components/Header';
import { bookService } from './services/bookService';
import './App.css';

function App() {
  const [books, setBooks] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showAddModal, setShowAddModal] = useState(false);
  const [editingBook, setEditingBook] = useState(null);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    loadBooks();
  }, []);

  const loadBooks = async () => {
    try {
      setLoading(true);
      const data = await bookService.getAllBooks();
      setBooks(data);
      setError(null);
    } catch (err) {
      setError('Failed to load books. Please try again.');
      console.error('Error loading books:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleAddBook = async (bookData) => {
    try {
      if (bookData.type === 'audiobook') {
        await bookService.addAudioBook(bookData);
      } else {
        await bookService.addBook(bookData);
      }
      await loadBooks();
      setShowAddModal(false);
    } catch (err) {
      setError('Failed to add book. Please try again.');
      console.error('Error adding book:', err);
    }
  };

  const handleEditBook = async (id, bookData) => {
    try {
      await bookService.updateBook(id, bookData);
      await loadBooks();
      setEditingBook(null);
    } catch (err) {
      setError('Failed to update book. Please try again.');
      console.error('Error updating book:', err);
    }
  };

  const handleDeleteBook = async (id) => {
    if (window.confirm('Are you sure you want to delete this book?')) {
      try {
        await bookService.deleteBook(id);
        await loadBooks();
      } catch (err) {
        setError('Failed to delete book. Please try again.');
        console.error('Error deleting book:', err);
      }
    }
  };

  const filteredBooks = books.filter(book =>
    book.title?.toLowerCase().includes(searchTerm.toLowerCase()) ||
    book.author?.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="min-h-screen bg-gray-50">
      <Header 
        onAddBook={() => setShowAddModal(true)}
        searchTerm={searchTerm}
        onSearchChange={setSearchTerm}
      />
      
      <main className="container mx-auto px-4 py-8">
        {error && (
          <div className="mb-6 p-4 bg-red-50 border border-red-200 rounded-lg text-red-700">
            {error}
            <button 
              onClick={() => setError(null)}
              className="ml-4 text-red-500 hover:text-red-700"
            >
              ×
            </button>
          </div>
        )}

        <BookList
          books={filteredBooks}
          loading={loading}
          onEdit={setEditingBook}
          onDelete={handleDeleteBook}
        />
      </main>

      {showAddModal && (
        <AddBookModal
          onClose={() => setShowAddModal(false)}
          onSubmit={handleAddBook}
        />
      )}

      {editingBook && (
        <EditBookModal
          book={editingBook}
          onClose={() => setEditingBook(null)}
          onSubmit={handleEditBook}
        />
      )}
    </div>
  );
}

export default App;