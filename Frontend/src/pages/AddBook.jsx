import React, { useState } from 'react';
import * as Form from '@radix-ui/react-form';
import { bookService } from '../api/booksService';


export default function AddBook() {
    const [form, setForm] = useState({ title: '', author: '' });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        setLoading(true);
        setError('');
        setSuccess('');
        try {
            await bookService.addBook(form);
            setSuccess('Book added successfully!');
            setForm({ title: '', author: '' });
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <Form.Root onSubmit={handleSubmit} style={{ maxWidth: 400, margin: '2rem auto' }}>
            <Form.Field name="title">
                <Form.Label>Title</Form.Label>
                <Form.Control asChild>
                    <input
                        name="title"
                        value={form.title}
                        onChange={handleChange}
                        required
                        disabled={loading}
                        style={{ width: '100%', marginBottom: 12 }}
                    />
                </Form.Control>
            </Form.Field>
            <Form.Field name="author">
                <Form.Label>Author</Form.Label>
                <Form.Control asChild>
                    <input
                        name="author"
                        value={form.author}
                        onChange={handleChange}
                        required
                        disabled={loading}
                        style={{ width: '100%', marginBottom: 12 }}
                    />
                </Form.Control>
            </Form.Field>
            <Form.Submit asChild>
                <button type="submit" disabled={loading}>
                    {loading ? 'Adding...' : 'Add Book'}
                </button>
            </Form.Submit>
            {error && <div style={{ color: 'red', marginTop: 10 }}>{error}</div>}
            {success && <div style={{ color: 'green', marginTop: 10 }}>{success}</div>}
        </Form.Root>
    );
};