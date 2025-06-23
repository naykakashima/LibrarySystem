import React, { useState } from 'react';
import * as Form from '@radix-ui/react-form';
import { bookService } from '../api/booksService';
import { motion } from 'motion/react';

export default function AddBook() {
  const [form, setForm] = useState({ title: '', author: '' });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    setSuccess('');
    try {
      await bookService.addBook(form);
      setSuccess('Book added successfully!');
      setForm({ title: '', author: '' });
    } catch (err) {
      setError(err.message || 'Something went wrong');
    } finally {
      setLoading(false);
    }
  };

  return (
    <motion.div
      initial={{ opacity: 0, y: 30 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.4 }}
      className="max-w-xl mx-auto mt-12 p-8 bg-white/60 backdrop-blur-md rounded-2xl shadow-md"
    >
      <h1 className="text-3xl font-bold text-gray-800 mb-6">Add New Book</h1>

      <Form.Root onSubmit={handleSubmit} className="space-y-6">
        <Form.Field name="title">
          <Form.Label className="block text-gray-700 font-medium mb-1">Title</Form.Label>
          <Form.Control asChild>
            <input
              type="text"
              name="title"
              value={form.title}
              onChange={handleChange}
              disabled={loading}
              className="w-full px-4 py-2 rounded-lg border border-gray-300 focus:outline-none focus:ring-2 focus:ring-indigo-500"
              required
            />
          </Form.Control>
        </Form.Field>

        <Form.Field name="author">
          <Form.Label className="block text-gray-700 font-medium mb-1">Author</Form.Label>
          <Form.Control asChild>
            <input
              type="text"
              name="author"
              value={form.author}
              onChange={handleChange}
              disabled={loading}
              className="w-full px-4 py-2 rounded-lg border border-gray-300 focus:outline-none focus:ring-2 focus:ring-indigo-500"
              required
            />
          </Form.Control>
        </Form.Field>

        <Form.Submit asChild>
          <button
            type="submit"
            disabled={loading}
            className="w-full bg-indigo-600 hover:bg-indigo-700 text-white font-medium py-2 px-6 rounded-lg transition"
          >
            {loading ? 'Adding...' : 'Add Book'}
          </button>
        </Form.Submit>

        {error && <p className="text-red-600 text-sm mt-2">{error}</p>}
        {success && <p className="text-green-600 text-sm mt-2">{success}</p>}
      </Form.Root>
    </motion.div>
  );
}
