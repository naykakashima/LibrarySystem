import React, { useState, useEffect } from 'react';
import { bookService } from '../api/booksService';
import { useParams } from 'react-router-dom';
import { Flex, Text, Box, Card, Inset, Strong, Checkbox } from "@radix-ui/themes";


export default function BookDetailsCard(){

    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState('');
    const [book, setBook] = useState(null);

    const { id } = useParams(); 
    const [ available, setAvailable ] = useState(false);

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

  return (
    <div>
        <Box maxWidth="240px">
            <Card size="2">
                <Inset clip="padding-box" side="top" pb="current">
                </Inset>
                <Text as="p" size="3">
                    <Strong className="justify center"> {book.title} </Strong> 
                </Text>
                <Text>
                    <Strong>Author:</Strong> {book.author}
                </Text>
                <Text as="label" size="10">
                    <Flex gap="10" align="center">
                        <Strong> {book.available ? "Available" : "Unavailable"} </Strong>
                        <Checkbox checked={book.available} readOnly />
                    </Flex>
                </Text>
            </Card>
        </Box>  
    </div>
  )
}
