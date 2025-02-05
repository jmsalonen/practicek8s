FROM nginx:latest
COPY nginx.conf /etc/nginx/nginx.conf
COPY ./ssl/nginx.crt /etc/nginx/ssl/nginx.crt
COPY ./ssl/nginx.key /etc/nginx/ssl/nginx.key
EXPOSE 443
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
