$TOKEN = "ff32b56950102b0d6621995f9943bb2f20f3c96e"
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Authorization", "Token $TOKEN")

$ACCOUNT = "B7V474AYBD"

$DEPLOYMENTS = Invoke-RestMethod -Method Get -ContentType 'application/json' -Headers $headers `
              -uri "https://app.searchstax.com/api/rest/v2/account/$ACCOUNT/deployment/"
$DEPLOYMENTS = $DEPLOYMENTS | ConvertTo-Json
Write-Host $DEPLOYMENTS