
kubectl create namespace vehicletracking 
kubectl -n vehicletracking apply -f .\deployment\sqlserver.yaml
kubectl -n vehicletracking apply -f .\deployment\vehicletracking-api.yaml


