# Deploy to Azure

```bash
# login to az
az login
az account set --subscription <subscription id>
az account show

# resource group
az group create --name rg-practicek8s-temp-westeu-1 --location westeurope

# AKS cluster
az aks create \
    --resource-group rg-practicek8s-temp-westeu-1 \
    --name aks-practicek8s-temp-westeu-1 \
    --node-count 1 \
    --generate-ssh-keys

# set kubectl to your newly created cluster
az aks get-credentials --resource-group rg-practicek8s-temp-westeu-1 --name aks-practicek8s-temp-westeu-1

# test kubectl
kubectl get all -A

# make sure kubectl is configured to use the right cluster
kubectl config get-contexts
kubectl config use-context aks-practicek8s-temp-westeu-1

# create kubernetes resources
kubectl apply -f deviceeventhandler.deployment.yaml
kubectl apply -f deviceeventhandler.service.yaml
kubectl apply -f backend.deployment.yaml
kubectl apply -f backend.service.yaml
kubectl apply -f appgw.deployment.yaml
kubectl apply -f appgw.service.yaml

# observe kubernetes resources
kubectl get deployments -o wide
kubectl get services -o wide

# dotnet logs
kubectl logs deployment/deviceeventhandler -f
kubectl logs deployment/backend --tail 100
```
