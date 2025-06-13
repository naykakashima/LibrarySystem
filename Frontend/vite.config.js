import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [
    react({
      // Enable Fast Refresh (React)
      fastRefresh: true,
    }),
  ],
  server: {
    // Faster file watching (Linux/macOS)
    watch: {
      usePolling: true, // Needed for Docker/WSL2
      interval: 100,    // Check for changes every 100ms
    },
    // Improve HMR connection stability
    hmr: {
      overlay: true, // Show errors in browser
      clientPort: 3000, // Match dev server port
    },
  },
  optimizeDeps: {
    // Force dependency pre-bundling (faster startup)
    include: ['react', 'react-dom'],
  },
});