

```
 # Install both
  Install-Module -Name Terminal-Icons -Repository PSGallery -Scope CurrentUser
  Install-Module -Name PSFileIcons -Repository PSGallery -Scope CurrentUser

  # Benchmark
  pwsh -NoProfile -Command '@("Terminal-Icons","PSFileIcons") | ForEach-Object { $ms = (Measure-Command { Import-Module $_
  }).TotalMilliseconds; [PSCustomObject]@{ Module = $_; Ms = [math]::Round($ms) } } | Format-Table -AutoSize'
```
