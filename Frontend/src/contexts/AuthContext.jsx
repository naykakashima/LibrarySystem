import { createContext, useState, useEffect } from 'react';
import { useContext } from 'react';
import authService from '../api/auth';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    // Check if user is logged in on initial load
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
      setUser(user);
    }
    setIsLoading(false);
  }, []);

  // const register = async (userData) => {
  //   const response = await authService.register(userData);
  //   setUser(response);
  //   return response;
  // };

  const login = async (userData) => {
    const response = await authService.login(userData);
    setUser(response);
    return response;
  };

  const logout = () => {
    authService.logout();
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, isLoading, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
export default AuthContext;