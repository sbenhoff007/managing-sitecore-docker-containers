Clear-Host

$namespace = "sitecore"

kubectl create -k ./k8s-sitecore-xm1 -n $namespace

kubectl create -k ./k8s-sitecore-xm1/ingress-nginx -n $namespace