Clear-Host

Write-Host "--- deployments ---" -ForegroundColor Blue
kubectl get deployments -n sitecore
Write-Host "--- pods ---" -ForegroundColor Blue
kubectl get pods -n sitecore
Write-Host "--- update pod ---" -ForegroundColor Blue
kubectl set image deployments/cm sitecondocker-xm1-cd=[myacr].azurecr.io/xm1/sitecondocker-xm1-cm:10.1.0-ltsc2019-v2 -n sitecore --record
kubectl set image deployments/cd sitecondocker-xm1-cd=[myacr].azurecr.io/xm1/sitecondocker-xm1-cd:10.1.0-ltsc2019-v2 -n sitecore --record
#./kubectl get pods -n sitecore
kubectl rollout status deployments/cm -n sitecore
kubectl rollout status deployments/cd -n sitecore
Write-Host "--- status ---" -ForegroundColor Blue
#./kubectl rollout undo deployments/cd -n sitecore