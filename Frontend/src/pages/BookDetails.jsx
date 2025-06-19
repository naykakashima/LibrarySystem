import React, { useState, useEffect } from 'react';
import { bookService } from '../api/booksService';
import { useParams } from 'react-router-dom';
import BookDetailsCard from '../components/BookDetailsCard';


export default function BookDetails() {
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState('');

    const [book, setBook] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        const fetchBookDetails = async () => {
            try {
                const data = await bookService.getBookById(id);
                setBook(data);
            } catch (err) {
                setError('Failed to fetch book details');
                console.error(err);
            } finally {
                setIsLoading(false);
            }
        };

        fetchBookDetails();
    }, [id]);

        if (isLoading) return <div>Loading book details...</div>;
        if (error) return <div>{error}</div>;

    return(
        <div className="max-w-2xl mx-auto mt-10">
            <h1 className="text-3xl font-bold mb-6">Book Details</h1>
            
            <BookDetailsCard 
            book={book}
            author={book.author}
            title={book.title}
            available={book.available}
             />

        </div>
    )
}