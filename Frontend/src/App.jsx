import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import  Home  from './pages/Home';
import  Login  from './pages/Login';
import  Register  from './pages/Register';
import  ProtectedRoute  from './components/ProtectedRoute';
import  Books  from './pages/Books';
import  BookDetails  from './pages/BookDetails';
import AddBook from './pages/AddBook';
import { AuthProvider } from './contexts/AuthContext';
import React from 'react';
import './App.css';


function App() {
  return(
    <Router>
      <div className='min-h-screen bg-gray-100'>
        {/* Header Component */}
        <main className='container mx-auto px-4 py-8'>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
          
            {/* Protected routes */}
            <Route element={<ProtectedRoute />}>
            <Route path="/books" element={<Books />} />
            <Route path="/books/:id" element={<BookDetails />} />
            <Route path="/protected" element={<ProtectedRoute />} />
            <Route path="/books/add" element={<AddBook />} />
            </Route>
          </Routes>
        </main>
      </div>
    </Router>
  )
}

export default App;