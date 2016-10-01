[CmdletBinding()]
param(
    [Parameter(Mandatory)][string] $Version
)

$projectFiles = Get-ChildItem -Filter project.json -Recurse

ForEach($project in $projectFiles) 
{
    $json = (Get-Content -Raw -Path $project.FullName | ConvertFrom-Json)

    $originalVersion = $json.version

    $json.version = $Version
    
    $json | ConvertTo-Json | Set-Content $project.FullName

    Write-Host "DEBUG: Changed " + $project.FullName + " from $originalVersion to $Version"
}