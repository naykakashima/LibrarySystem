# Use lightweight Node
FROM node:22-alpine

WORKDIR /app

# Copy package files first (cache npm install)
COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

# Install static server to serve build files
RUN npm install -g serve

#Exposes and serves on port 5173.
EXPOSE 5173

CMD ["serve", "-s", "dist", "-l", "5173"]
