Clear-Host

$namespace = "sitecore"

kubectl create -k ./k8s-sitecore-xm1/external -n $namespace
