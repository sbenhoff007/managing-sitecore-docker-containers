$TOKEN = "ff32b56950102b0d6621995f9943bb2f20f3c96e"
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Authorization", "Token $TOKEN")

$ACCOUNT = "B7V474AYBD"
 
$body = @{
    scope=@('deployment.dedicateddeployment')   # Force single-value to be a list
}
$body = $body | ConvertTo-Json
 
$RESULT = Invoke-RestMethod -Method Post -body $body -ContentType 'application/json' -Headers $headers `
         -uri "https://app.searchstax.com/api/rest/v2/account/$ACCOUNT/apikey/"
$RESULT = $RESULT | ConvertTo-Json
Write-Host $RESULT