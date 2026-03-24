# Build PSFileIcons and install to the user's PowerShell module path
[CmdletBinding()]
param(
    [switch]$Install
)

$ErrorActionPreference = 'Stop'

$src = Join-Path $PSScriptRoot 'src'
$out = Join-Path $src 'bin\Release\netstandard2.0'

Write-Host 'Building PSFileIcons...'
dotnet build $src -c Release --nologo -v q
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

if ($Install) {
    $moduleDir = Join-Path ([Environment]::GetFolderPath('MyDocuments')) 'PowerShell\Modules\PSFileIcons'
    Write-Host "Installing to $moduleDir ..."
    $null = New-Item -ItemType Directory -Path $moduleDir -Force
    Copy-Item "$out\PSFileIcons.dll"          $moduleDir -Force
    Copy-Item "$src\PSFileIcons.psm1"         $moduleDir -Force
    Copy-Item "$src\PSFileIcons.psd1"         $moduleDir -Force
    Copy-Item "$src\PSFileIcons.format.ps1xml" $moduleDir -Force
    Write-Host 'Done. Run: Import-Module PSFileIcons'
} else {
    Write-Host "Build complete. Run with -Install to deploy to module path."
}
