import axios from 'axios';

export function useRegister() {
  async function Register({ username, password, email }) {
    const res = await axios.post('/api/Auth/register', {
      username,
      password,
      email
    });
    return res.data;
  }

  return { Register };
}
