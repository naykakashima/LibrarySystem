import axios from 'axios';

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

export default {
  register,
  login,
  logout,
  getProtectedData
};