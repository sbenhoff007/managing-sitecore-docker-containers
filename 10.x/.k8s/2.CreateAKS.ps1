param(
    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$Region = 'eastus',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$ResourceGroup = 'sitecondockerk8sdemo',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$AksName = 'sitecondockerk8sdemo',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$AcrName = 'sitecondockerk8sdemo',

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$AzureWindowsPassword="Password12345!"
)

# Setup CLI & Parameters for AKS creation
Write-Host "--- Setting up CLI & Params ---" -ForegroundColor Blue

$aksVersion = "1.19.11" #$(az aks get-versions -l $Region --query 'orchestrators[-1].orchestratorVersion' -o tsv)
Write-Host "--- Complete: CLI & Params Configured ---" -ForegroundColor Green

# create AKS instance
# Write-Host "--- Creating AKS Instance K8s version $aksVersion ---" -ForegroundColor Blue

############################################################################################
# RUN THE FOLLOWING COMMANDS MANUALLY
# az ad sp create-for-rbac --skip-assignment --name myAKSClusterServicePrincipal

# SET THE FOLLOWING VALUES
# service-principal = appId
# client-secret = password

# az aks create --resource-group $ResourceGroup `
#     --name $AksName `
#     --kubernetes-version $aksVersion `
#     --location $Region `
#     --windows-admin-password $AzureWindowsPassword `
#     --windows-admin-username azureuser `
#     --vm-set-type VirtualMachineScaleSets `
#     --node-count 2 `
#     --generate-ssh-keys `
#     --network-plugin azure `
#     --enable-addons monitoring `
#     --nodepool-name 'linux' `
#     --service-principal [appId] `
#     --client-secret '[password]'
############################################################################################
# Write-Host "--- Complete: AKS Created ---" -ForegroundColor Green

# link AKS to ACR
Write-Host "--- Linking AKS to ACR ---" -ForegroundColor Blue
#--- Linking AKS to ACR ---

$clientID = $(az aks show --resource-group $ResourceGroup --name $AksName --query "servicePrincipalProfile.clientId" --output tsv)
$acrId = $(az acr show --name $AcrName --resource-group $ResourceGroup --query "id" --output tsv)
az role assignment create --assignee $clientID `
    --role acrpull `
    --scope $acrId
Write-Host "--- Complete: AKS & ACR Linked ---" -ForegroundColor Green

# Add windows server nodepool
Write-Host "--- Creating Windows Server Node Pool ---" -ForegroundColor Blue
az aks nodepool add --resource-group $ResourceGroup `
    --cluster-name $AksName `
    --os-type Windows `
    --name win `
    --node-vm-size Standard_D8s_v3 `
    --node-count 1 
Write-Host "--- Complete: Windows Server Node Pool Created ---" -ForegroundColor Green

# authenticate AKS instance
Write-Host "--- Authenticate with AKS ---" -ForegroundColor Blue
az aks get-credentials -a `
    --resource-group $ResourceGroup `
    --name $AksName `
    --overwrite-existing

Write-Host "--- Complete: Windows Server Node Pool Created ---" -ForegroundColor Green