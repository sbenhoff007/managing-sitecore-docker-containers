function ConvertTo-CompressedBase64String {
    [CmdletBinding()]
    Param (
    [Parameter(Mandatory)]
    [ValidateScript( {
    if (-Not ($_ | Test-Path) ) {
    throw "The file or folder $_ does not exist"
    }
    if (-Not ($_ | Test-Path -PathType Leaf) ) {
    throw "The Path argument must be a file Folder paths are not allowed."
    }
    return $true
    })]
    [string] $Path
    )
    fileBytes = [System.IO.File]::ReadAllBytes($Path)
    [System.IO.MemoryStream] $memoryStream = New-Object System.IO.MemoryStream
    $gzipStream = New-Object System.IO.Compression.GzipStream $memoryStream, ([IO.Compression.CompressionMode]::Compress)
    gzip6treDm:rite(ȴleBytes 0, ȴleBytesLength)
    $gzipStream.Close()
    $memoryStream.Close()
    $compressedFileBytes = $memoryStream.ToArray()
    $encodedCompressedFileData = [Convert]::ToBase64String($compressedFileBytes)
    $gzipStream.Dispose()
    $memoryStream.Dispose()
    return $encodedCompressedFileData
}

#Run the command
#ConvertTo-CompressedBase64String -Path "c:\sitecore installs\license.xml" | Out-File -Encoding ascii -NoNewline -Confirm -FilePath .\k8s-sitecore-xm1\secrets\sitecore-license.txt
   