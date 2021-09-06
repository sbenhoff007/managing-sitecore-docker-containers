$certificatePassword = "cLVrqGoJndZt"

$newCert = New-SelfSignedCertificate -DnsName "sitecondocker.globalhost" -FriendlyName "Sitecore Identity Token
Signing" -NotAfter (Get-Date).AddYears(5)

Export-PfxCertificate -Cert $newCert -FilePath .\SitecoreIdentityTokenSigning.pfx -Password (ConvertTo-SecureString -String $certificatePassword -Force -AsPlainText)

[System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes((Get-Item .\SitecoreIdentityTokenSigning.pfx))) | Out-File -Encoding ascii -NoNewline -Confirm -FilePath .\k8s-sitecore-xm1\secrets\sitecore-identitycertificate.txt