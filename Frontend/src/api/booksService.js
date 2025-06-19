const API_BASE_URL = 'https://localhost:7237/api';

function getToken() {
  try {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user?.token && user.token !== 'fake-token') {
      return user.token;
    }
  } catch (e) {
    console.error('Invalid user in localStorage', e);
  }
  return null;
}

function authHeader() {
  const user = JSON.parse(localStorage.getItem('user'));
  if (user && user.token) {
    return { Authorization: `Bearer ${user.token}` };
  }
  return {};
}

const token = getToken();

class BookService {
  async getAllBooks() {
    const response = await fetch(`${API_BASE_URL}/Books`, {
      headers: {
        ...authHeader()
      }
  });
    if (!response.ok) {
      console.log('Headers:', authHeader());
      throw new Error('Failed to fetch books');
    }
    return response.json();
  }



  async getBookById(id) {
    const response = await fetch(`${API_BASE_URL}/Books/${id}`, {
      headers: {
        ...authHeader()
      }
    }
  );
    if (!response.ok) {
      throw new Error('Failed to fetch book');
    }
    return response.json();
  }

  async addBook(bookData) {
    const response = await fetch(`${API_BASE_URL}/Books/AddBook`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        ...authHeader(),
      },
      body: JSON.stringify({
        title: bookData.title,
        author: bookData.author,
      }),
    });
    
    if (!response.ok) {
      const errorData = await response.text();
      throw new Error(errorData || 'Failed to add book');
    }
    return response.json();
  }

  async addAudioBook(bookData) {
    const response = await fetch(`${API_BASE_URL}/Books/AddAudioBook`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        title: bookData.title,
        author: bookData.author,
        runtimeMinutes: parseInt(bookData.runtimeMinutes),
      }),
    });
    
    if (!response.ok) {
      const errorData = await response.text();
      throw new Error(errorData || 'Failed to add audiobook');
    }
    return response.json();
  }

  async updateBook(id, bookData) {
    const response = await fetch(`${API_BASE_URL}/Books/UpdateBook/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        title: bookData.title,
        author: bookData.author,
        available: bookData.available,
      }),
    });
    
    if (!response.ok) {
      const errorData = await response.text();
      throw new Error(errorData || 'Failed to update book');
    }
    return response.text();
  }

  async deleteBook(id) {
    const response = await fetch(`${API_BASE_URL}/Books/DeleteBook/${id}`, {
      method: 'DELETE',
    });
    
    if (!response.ok) {
      const errorData = await response.text();
      throw new Error(errorData || 'Failed to delete book');
    }
    return response.text();
  }
}

export const bookService = new BookService();