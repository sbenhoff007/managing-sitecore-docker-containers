param(
    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$Region = 'eastus',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$ResourceGroup = 'sitecondockerk8sdemo',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$MyRegistry = 'sitecondockerk8sdemo',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string]$SkuAcr = 'Standard'  
)

# Setup CLI & Parameters for AKS creation
Write-Host "--- Setting up CLI & Params ---" -ForegroundColor Blue

# Create resource group
Write-Host "--- Creating resource group ---" -ForegroundColor Blue
az group create --name $ResourceGroup --location $Region
Write-Host "--- Complete: resource group ---" -ForegroundColor Green

# Create Azure Container Registry
Write-Host "--- Creating ACR ---" -ForegroundColor Blue
az acr create -n $MyRegistry -g $ResourceGroup --sku $SkuAcr --location $Region
Write-Host "--- Complete: ACR ---" -ForegroundColor Green

