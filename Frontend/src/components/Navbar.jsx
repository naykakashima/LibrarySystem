import { Link } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';

export default function Navbar() {
  const { user, logout } = useAuth();

  return (
    <nav className="bg-white shadow-sm">
      <div className="container mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-xl font-bold text-indigo-600">Library</Link>
        <div className="flex space-x-4">
          {user ? (
            <>
              <Link to="/books" className="px-3 py-2 text-gray-700 hover:text-indigo-600">Books</Link>
              <Link to="/protected" className="px-3 py-2 text-gray-700 hover:text-indigo-600">Protected</Link>
              <button
                onClick={logout}
                className="px-3 py-2 text-gray-700 hover:text-indigo-600"
              >
                Logout
              </button>
            </>
          ) : (
            <>
              <Link to="/login" className="px-3 py-2 text-gray-700 hover:text-indigo-600">Login</Link>
              <Link to="/register" className="px-3 py-2 text-gray-700 hover:text-indigo-600">Register</Link>
            </>
          )}
        </div>
      </div>
    </nav>
  );
}