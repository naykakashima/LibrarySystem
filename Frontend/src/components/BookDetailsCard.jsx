import React, { useState, useEffect } from 'react';
import { motion } from 'motion/react';
import BorrowButton from '../components/BorrowButton';
import ReturnButton from '../components/ReturnButton';
import DeleteBook from './DeleteBook';
import { getCurrentUserId, getCurrentUserRole } from '../api/auth';
import { Flex, Text, Badge } from '@radix-ui/themes';

export default function BookDetailsCard({ book }) {
  const [hasBorrowed, setHasBorrowed] = useState(false);
  const [currentUserId, setCurrentUserId] = useState(null);
  const [isAdmin, setIsAdmin] = useState(false);

  useEffect(() => {
    const id = getCurrentUserId();
    const role = getCurrentUserRole();
    setCurrentUserId(id);
    setHasBorrowed(book.borrowedByUserId === id);
    setIsAdmin(role === 'Admin');
  }, [book]);

  const showBorrow = book.available && !hasBorrowed;
  const showReturn = !book.available && hasBorrowed;

  return (
    <motion.div
      initial={{ opacity: 0, y: 40 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.5 }}
      className="max-w-3xl mx-auto p-6 bg-white/60 backdrop-blur-md rounded-2xl shadow-sm"
    >
      <div className="mb-6">
        <h1 className="text-4xl font-extrabold text-gray-900">{book.title}</h1>
        <h2 className="text-xl text-gray-700 mt-2">by {book.author}</h2>
      </div>

      <div className="mb-6">
        <Badge
          size="3"
          color={book.available ? 'green' : 'red'}
          radius="full"
          variant="solid"
          className="text-sm tracking-wide"
        >
          {book.available ? 'Available to borrow' : 'Currently borrowed'}
        </Badge>
      </div>

      <Flex gap="8" justify="start" align="justify" wrap="wrap">
        {showBorrow && (
          <BorrowButton className="mb-2 bg-indigo-600 hover:bg-indigo-700 text-white font-medium px-10 py-2 rounded-lg transition" />
        )}
        {showReturn && (
          <ReturnButton className="mb-2 bg-yellow-500 hover:bg-yellow-600 text-white font-medium px-10 py-2 rounded-lg transition" />
        )}
        {isAdmin && (
          <DeleteBook className="mb-2 bg-red-600 hover:bg-red-700 text-white font-medium px-10 py-2 rounded-lg transition" />
        )}
      </Flex>
    </motion.div>
  );
}
