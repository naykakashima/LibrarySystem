import React, { useState, useEffect } from 'react';
import  BorrowButton  from '../components/BorrowButton';
import  ReturnButton  from '../components/ReturnButton';
import  { getCurrentUserId }  from '../api/auth';
import { Flex, Text, Box, Card, Inset, Strong, Checkbox } from "@radix-ui/themes";


export default function BookDetailsCard({ book }) {
  const [hasBorrowed, setHasBorrowed] = useState(false);
  const [ currentUserId, setCurrentUserId ] = useState(null);

  useEffect(() => {
    const id = getCurrentUserId();
    setCurrentUserId(id);
    setHasBorrowed(book.borrowedByUserId === id );
    console.log("book:", book);
    console.log("currentUserId:", id);
    console.log("borrowedByUserId:", book?.borrowedByUserId);
    console.log("hasBorrowed:", book?.borrowedByUserId === id);
  }, [book]);

  const showBorrow = book.available && !hasBorrowed;
  const showReturn = !book.available && hasBorrowed;

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

                <Flex mt="3" justify='center'>
                    { showReturn && <ReturnButton/> }
                    { showBorrow && <BorrowButton/> }
                </Flex>
            </Card>
        </Box>  
    </div>
  )
}
