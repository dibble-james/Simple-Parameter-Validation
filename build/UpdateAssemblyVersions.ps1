Get-ChildItem -Filter project.json -Recurse | ForEach-Object 
{
    $json = (Get-Content -Raw -Path $_.FullName | ConvertFrom-Json)

    $originalVersion = $json.version
    $newVersion = $env:GitVersion_NuGetVersion

    $json.version = $newVersion
    
    $json | ConvertTo-Json | Set-Content $_.FullName

    Write-Host "DEBUG: Changed " + $_.FullName + " from $originalVersion to $newVersion"
}