import { bookService } from "../api/booksService";
import { Button } from "@radix-ui/themes"
import { useState } from "react";
import { useNavigate, useParams } from 'react-router-dom';

export default function DeleteBook() {
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
        <Button size="3" variant="soft" onClick={handleDelete} disabled={isLoading}>
        {isLoading ? "Processing..." : "Delete Book"}
        </Button>
        </>
    )
}