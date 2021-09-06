Clear-Host

$namespace = "sitecore"

kubectl create -k ./k8s-sitecore-xm1/overlays/init/SearchStax -n $namespace