# Introduction

Practice project for kuberenetes with some .NET services

```bash
docker login -u <your-username>
docker tag backend:latest <your-username>/backend:latest
docker push <your-username>/backend:latest
```

```bash
docker login -u <your-username>
docker tag practicek8s-appgw:latest jmsalonen/appgw:latest
docker push jmsalonen/appgw:latest
```

## create certs

On windows, you may need to use wsl to run this bash script.

```bash
./script/setup_ssl.sh
```
