Clear-Host

Write-Host "--- rollback ---" -ForegroundColor Blue

kubectl rollout undo deployments/cm -n sitecore
kubectl rollout undo deployments/cd -n sitecore