import axios from 'axios';

const API_BASE_URL = `${import.meta.env.VITE_API_URL}/api`;
if (import.meta.env.DEV) {
  console.log("📡 API_BASE_URL:", API_BASE_URL);
}


export function useRegister() {
  async function Register({ username, password, email }) {
    const res = await axios.post(`${API_BASE_URL}/Auth/register`, {
      username,
      password,
      email
    });
    return res.data;
  }

  return { Register };
}
