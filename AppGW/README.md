## Generate self-signed certs 

```bash
# create certs to the ssl folder
mkdir ssl
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout ./ssl/nginx.key -out ./ssl/nginx.crt

# test with curl
curl https://localhost/health -k
```


