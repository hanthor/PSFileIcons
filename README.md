# PSFileIcons

A fast reimplementation of [Terminal-Icons](https://github.com/devblackops/Terminal-Icons) for PowerShell. I wanted the same Nerd Font file icons and ANSI colors in `Get-ChildItem`, but Terminal-Icons was adding ~580ms to my shell startup. PSFileIcons loads in ~32ms — **18× faster** — by compiling all icon mappings into a C# dictionary with no runtime file I/O.

> PSFileIcons is included in [bluefin-cli](https://github.com/hanthor/bluefin-cli), a cross-platform terminal enhancement suite that brings your terminal experience to any computer you go to.

## Benchmark

```powershell
# Install both
Install-Module -Name Terminal-Icons -Repository PSGallery -Scope CurrentUser
Install-Module -Name PSFileIcons -Repository PSGallery -Scope CurrentUser

# Compare import time
pwsh -NoProfile -Command '@("Terminal-Icons","PSFileIcons") | ForEach-Object { $ms = (Measure-Command { Import-Module $_ }).TotalMilliseconds; [PSCustomObject]@{ Module = $_; Ms = [math]::Round($ms) } } | Format-Table -AutoSize'
```

```
Module             Ms
------             --
Terminal-Icons    580
PSFileIcons        32
```

## Requirements

- PowerShell 5.1 or later
- A [Nerd Font](https://www.nerdfonts.com/) installed in your terminal

## Installation

```powershell
Install-Module -Name PSFileIcons -Repository PSGallery -Scope CurrentUser
```

Add to your PowerShell profile (`$PROFILE`):

```powershell
Import-Module PSFileIcons
```

## Features

- Nerd Font icons for files and directories based on name and extension
- ANSI color coding by file type:
  - **Bold cyan** — directories
  - **Bold green** — executables & scripts (`.ps1`, `.sh`, `.exe`, …)
  - **Green** — source code (`.go`, `.rs`, `.py`, `.js`, …)
  - **Yellow** — config files (`.json`, `.yaml`, `.toml`, …)
  - **Bold magenta** — archives (`.zip`, `.tar.gz`, …)
  - **Magenta** — images & media
  - **Red** — native binaries (`.dll`, `.so`, …)
  - **White** — docs & text

## License

MIT
