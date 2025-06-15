const API_BASE_URL = 'https://localhost:7237/api';

class BookService {
  async getAllBooks() {
    const response = await fetch(`${API_BASE_URL}/Books`);
    if (!response.ok) {
      throw new Error('Failed to fetch books');
    }
    return response.json();
  }

  async getBookById(id) {
    const response = await fetch(`${API_BASE_URL}/Books/${id}`);
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