import { bookService } from "../api/booksService";
import { Button } from "@radix-ui/themes"
import { useState } from "react";
import { useNavigate, useParams } from 'react-router-dom';

export default function DeleteBook({ className }) {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');
    const navigate = useNavigate();
    const { id } = useParams(); 

    const handleDelete = async () => {
        setIsLoading(true)

        try{
            await bookService.deleteBook(id);
            alert("Book Deleted Succesfully")
            navigate('/books'); 
        } catch (err) {
            setError("Failed to delete book")
            console.error(err);
        } finally {
            setIsLoading(false)
        }

        if (error) return <div>{error}</div>;
    };

    return(
        <>
        {error && <div>{error}</div>}
        <Button
            size="3"
            variant="solid"
            className={`bg-red-600 hover:bg-red-700 text-white px-5 py-2 rounded-xl shadow-md transition-all duration-200 ${className}`}
            onClick={handleDelete}
            disabled={isLoading}
            >
            {isLoading ? "Processing..." : "Delete Book"}
        </Button>
        </>
    )
}