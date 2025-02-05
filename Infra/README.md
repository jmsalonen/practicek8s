# Deploy to Azure

## Create AKS and deploy images

```bash
# login to az
az login
az account set --subscription <subscription id>
az account show

# resource group
az group create --name rg-practicek8s-temp-westeu-2 --location westeurope

# AKS cluster
az aks create \
    --resource-group rg-practicek8s-temp-westeu-2 \
    --name aks-practicek8s-temp-westeu-2 \
    --node-count 1 \
    --enable-app-routing \
    --generate-ssh-keys

# set kubectl to your newly created cluster
az aks get-credentials --resource-group rg-practicek8s-temp-westeu-2 --name aks-practicek8s-temp-westeu-2

# test kubectl
kubectl get all -A

# make sure kubectl is configured to use the right cluster
kubectl config get-contexts
kubectl config use-context aks-practicek8s-temp-westeu-2

# create kubernetes resources
kubectl apply -f deviceeventhandler.deployment.yaml
kubectl apply -f deviceeventhandler.service.yaml
kubectl apply -f backend.deployment.yaml
kubectl apply -f backend.service.yaml

# apply appgw as an alternative to ingress for testing
# kubectl apply -f appgw.deployment.yaml
# kubectl apply -f appgw.service.yaml

# observe kubernetes resources
kubectl get deployments -o wide
kubectl get services -o wide

# dotnet logs
kubectl logs deployment/deviceeventhandler -f
kubectl logs deployment/backend --tail 100
```

## Add Ingress to AKS with self-signed HTTPS certs

```bash
# Attach container registry to AKS
az acr create --name practicek8sregistry --resource-group rg-practicek8s-temp-westeu-2 --sku basic
az aks update --name aks-practicek8s-temp-westeu-2 --resource-group rg-practicek8s-temp-westeu-2 --attach-acr practicek8sregistry

# Attach keyvault to AKS
az keyvault create --resource-group rg-practicek8s-temp-westeu-2 --location westeurope --name practicek8skeyvault --enable-rbac-authorization true

# generate self-signed certs
openssl req -new -x509 -nodes -out aks-ingress-tls.crt -keyout aks-ingress-tls.key -subj "/CN=practicek8s.westeurope.cloudapp.azure.com" -addext "subjectAltName=DNS:practicek8s.westeurope.cloudapp.azure.com"
openssl pkcs12 -export -in aks-ingress-tls.crt -inkey aks-ingress-tls.key -out aks-ingress-tls.pfx

# you may need to grant access to yourself at azure portal access control (IAM)
az keyvault certificate import --vault-name practicek8skeyvault --name practicek8-cert --file aks-ingress-tls.pfx

az keyvault show --name practicek8skeyvault --query "id" --output tsv
# command above should give you the value needed for --attach-kv
az aks approuting update --resource-group rg-practicek8s-temp-westeu-2 --name aks-practicek8s-temp-westeu-2 --enable-kv --attach-kv <az keyvault show... result>

az network dns zone create --resource-group rg-practicek8s-temp-westeu-2 --name practicek8s.westeurope.cloudapp.azure.com

az keyvault certificate show --vault-name practicek8skeyvault --name practicek8-cert --query "id" --output tsv

## update and apply ingress.yaml
kubectl apply -f ingress.yaml
```
