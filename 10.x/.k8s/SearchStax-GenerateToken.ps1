$USER = "shelley@hoffstech.com"
$PASSWORD = "Searchstax5191!"
$TFA = "123456"
 
$body = @{
    username=$USER
    password=$PASSWORD
    tfa_token=$TFA
}
 
$body = $body | ConvertTo-Json
 
$TOKEN = Invoke-RestMethod -Method Post -Body $body -ContentType 'application/json' `
        -uri "https://app.searchstax.com/api/rest/v2/obtain-auth-token/"
Write-Host $TOKEN