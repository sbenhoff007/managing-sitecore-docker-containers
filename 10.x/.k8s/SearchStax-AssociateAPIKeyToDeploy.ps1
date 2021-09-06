$TOKEN = "ff32b56950102b0d6621995f9943bb2f20f3c96e"
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Authorization", "Token $TOKEN")

$ACCOUNT = "B7V474AYBD"
$uid = "ss941981"
$APIKEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI3NDNhMjA1NDMxNWY1NzMwNmM1ODY5MThiZWRkZmUxNzhlNGI2ZTM2IiwiaWF0IjoxNjI3MDYzNTAxLCJ0ZW5hbnRfYXBpX2FjY2Vzc19rZXkiOiJXUlkxcW5KQVF5cU1UZW1INlRCd1ZRIiwic2NvcGUiOlsiZGVwbG95bWVudC5kZWRpY2F0ZWRkZXBsb3ltZW50Il19.74xPtgOKjM2TtEwgBI25AS4ca7BpSnCDQ9Ucd63_6W8"
 
$body = @{
    apikey=$APIKEY
    deployment=$uid
}
 
$body = $body | ConvertTo-Json
 
$RESULT = Invoke-RestMethod  -Method Post -body $body -ContentType 'application/json' -Headers $headers `
         -uri "https://app.searchstax.com/api/rest/v2/account/$ACCOUNT/apikey/associate/"
 
$RESULT = $RESULT | ConvertTo-Json
Write-Host $RESULT