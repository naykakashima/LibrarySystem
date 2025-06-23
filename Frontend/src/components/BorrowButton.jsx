import { Button } from "@radix-ui/themes"
import  { bookService } from '../api/booksService';
import { useState } from "react";
import { useNavigate, useParams } from 'react-router-dom';

export default function BorrowButton ({ className }) {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');
    const navigate = useNavigate();
    const { id } = useParams(); 

    const handleBorrow = async () => {
        setIsLoading(true)
    try {
        console.log('bookService:', bookService);
        console.log('borrowBook function:', bookService.borrowBook);
        await bookService.borrowBook(id);
        alert("Book borrowed successfully");
        navigate('/books');
    } catch (err) {
        setError('Failed to borrow book');
        console.error(err);
    } finally {
        setIsLoading(false);
    }
    if (error) return <div>{error}</div>;
};

    
    return (
        <>
        {error && <div>{error}</div>}
        <Button
            size="3"
            variant="solid"
            className={`bg-indigo-600 hover:bg-indigo-700 text-white px-5 py-2 rounded-xl shadow-md transition-all duration-200 ${className}`}
            onClick={handleBorrow}
            disabled={isLoading}
            >
            {isLoading ? "Processing..." : "Borrow Book"}
        </Button>
        </>
    )
}