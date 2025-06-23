import { Button } from "@radix-ui/themes"
import { bookService } from '../api/booksService';
import { useState } from "react";
import { useNavigate, useParams } from 'react-router-dom';

export default function ReturnButton ({ className }) {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');
    const navigate = useNavigate();
    const { id } = useParams(); 

    const handleReturn = async () => {
        setIsLoading(true)
    try {
        await bookService.returnBook(id);
        alert("Book returned successfully");
        navigate('/books');
    } catch (err) {
        setError('Failed to return book');
        console.error(err);
    } finally {
        setIsLoading(false);
    }
    if (error) return <div>{error}</div>;
};

    
    return (
        <>
        <Button
            size="3"
            variant="solid"
            className={`bg-yellow-500 hover:bg-yellow-600 text-white px-5 py-2 rounded-xl shadow-md transition-all duration-200 ${className}`}
            onClick={handleReturn}
            disabled={isLoading}
            >
            {isLoading ? "Processing..." : "Return Book"}
        </Button>
        </>
    )
}