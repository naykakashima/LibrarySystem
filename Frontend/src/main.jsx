// src/main.jsx
 
import React from 'react'; // <--- Add this line
import ReactDOM from 'react-dom/client';
import App from './App.jsx'; // Or App.tsx
import './index.css';
 
ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
);
 