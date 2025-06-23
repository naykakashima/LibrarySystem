import axios from 'axios';
import { jwtDecode } from "jwt-decode";

const API_URL = 'https://localhost:7237/api/Auth';

// Register user
const register = async (userData) => {
  const response = await axios.post(`${API_URL}/register`, userData);
  return response.data;
};

// Login user
const login = async (userData) => {
  const response = await axios.post(`${API_URL}/login`, userData);
  if (response.data.token) {
    localStorage.setItem('user', JSON.stringify(response.data));
  }
  return response.data;
};

const logout = () => {
  localStorage.removeItem('user');
}

const getProtectedData = async (token) => {
    const config = {
        headers : {
            Authorization: `Bearer ${token}`
        },
    };

    const response = await axios.get(`${API_URL}/protected`, config);
    return response.data;
};

export const getCurrentUserId = () => {
  try {
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user?.token) return null;

    const decoded = jwtDecode(user.token); // ✅ note this change
    return decoded.sub;
  } catch (error) {
    console.error("Failed to get current user ID", error);
    return null;
  }
};

export const getCurrentUserRole = () => {
  try {
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user?.token) return null;

    const decoded = jwtDecode(user.token); // ✅ note this change
    console.log(decoded.role)
    return decoded.role;
  } catch (error) {
    console.error("Failed to get current user role", error);
    return null;
  }
};

export default {
  register,
  login,
  logout,
  getProtectedData,
  getCurrentUserId,
  getCurrentUserRole
};