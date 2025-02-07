# Stage 1: Build the React app
FROM node:18.20.1 as build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

# Stage 2: Create the Nginx image
FROM nginx:latest

WORKDIR /etc/nginx

COPY nginx.conf .

# Copy the built React app into the Nginx image
COPY --from=build /app/build /usr/share/nginx/html

EXPOSE 3000

CMD ["nginx", "-g", "daemon off;"]


#docker build -t frontend .
#docker run -p 80:80 frontend
