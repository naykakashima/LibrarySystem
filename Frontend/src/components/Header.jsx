import { Link, useLocation } from "react-router-dom";
import { motion } from "motion/react";
import { useAuth } from "../contexts/AuthContext"; // Adjust path as needed
import { useNavigate } from "react-router-dom";
import { useState } from 'react';

function Header() {
  const { pathname } = useLocation();
  const { user } = useAuth(); // user is null or user object
  const [isLoading] = useState(false);
  const navigate = useNavigate();
  const { logout } = useAuth();

  const handleLogout = () => {
  logout();
  navigate("/"); 
  };

  return (
    <motion.header
      initial={{ y: -20, opacity: 0 }}
      animate={{ y: 0, opacity: 1 }}
      transition={{ duration: 0.6 }}
      className="bg-white/70 backdrop-blur-sm border-b border-gray-200 shadow-sm"
    >
      <div className="container mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-xl font-bold text-gray-800">
          Kay's Bookstore
        </Link>
        <nav className="flex space-x-4">
          <Link
            to="/"
            className={`text-gray-700 hover:text-gray-900 transition font-medium ${
              pathname === "/" ? "underline underline-offset-4" : ""
            }`}
          >
            Home
          </Link>

          {/* Conditionally show Books if logged in */}
          {user && (
            <>
            <Link
              to="/books"
              className={`text-gray-700 hover:text-gray-900 transition font-medium ${
                pathname.startsWith("/books") ? "underline underline-offset-4" : ""
              }`}
            >
              Books
            </Link>
            <button
                onClick={handleLogout}
                className="text-gray-700 hover:text-gray-900 transition font-medium"
              >
                Logout
            </button>
            </>
          )}

          {/* Show Login/Register only if NOT logged in */}
          {!user && (
            <>
              <Link
                to="/login"
                className={`text-gray-700 hover:text-gray-900 transition font-medium ${
                  pathname === "/login" ? "underline underline-offset-4" : ""
                }`}
              >
                Login
              </Link>
              <Link
                to="/register"
                className={`text-gray-700 hover:text-gray-900 transition font-medium ${
                  pathname === "/register" ? "underline underline-offset-4" : ""
                }`}
              >
                Register
              </Link>
            </>
          )}
        </nav>
      </div>
    </motion.header>
  );
}

export default Header;
