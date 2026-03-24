function Format-PSFileIcon {
    param([System.IO.FileSystemInfo]$Item)

    $e = [char]27

    if ($Item.PSIsContainer) {
        $icon = [PSFileIcons.IconMap]::GetDirIcon($Item.Name)
        # Directories: bold cyan
        return "${e}[1;36m${icon} $($Item.Name)${e}[0m"
    }

    $icon = [PSFileIcons.IconMap]::GetFileIcon($Item.Name, $Item.Extension)
    $ext = $Item.Extension.ToLower()

    # Color by file type
    $color = switch -Regex ($ext) {
        '^\.exe$|^\.cmd$|^\.bat$|^\.ps1$|^\.psm1$|^\.psd1$|^\.sh$|^\.bash$|^\.zsh$|^\.fish$' { '1;32' } # bold green   — executables/scripts
        '^\.md$|^\.txt$|^\.rst$|^\.log$'                                                        { '0;37' } # white        — docs/text
        '^\.json$|^\.yaml$|^\.yml$|^\.toml$|^\.xml$|^\.ini$|^\.cfg$|^\.conf$|^\.env$'         { '0;33' } # yellow       — config
        '^\.zip$|^\.tar$|^\.gz$|^\.bz2$|^\.xz$|^\.7z$|^\.rar$|^\.zst$|^\.zstd$'              { '1;35' } # bold magenta  — archives
        '^\.jpg$|^\.jpeg$|^\.png$|^\.gif$|^\.svg$|^\.webp$|^\.ico$|^\.bmp$'                    { '0;35' } # magenta       — images
        '^\.mp3$|^\.wav$|^\.flac$|^\.ogg$|^\.mp4$|^\.mkv$|^\.avi$|^\.mov$'                    { '0;35' } # magenta       — media
        '^\.go$|^\.rs$|^\.py$|^\.js$|^\.ts$|^\.cs$|^\.cpp$|^\.c$|^\.rb$|^\.java$|^\.kt$'     { '0;32' } # green         — source code
        '^\.dll$|^\.so$|^\.dylib$|^\.wasm$'                                                     { '0;31' } # red           — native binaries
        '^\.lock$|^\.sum$'                                                                       { '2;37' } # dim white     — lockfiles
        default                                                                                  { '0'    } # default
    }

    return "${e}[${color}m${icon} $($Item.Name)${e}[0m"
}

# Explicitly prepend our format so it takes priority over the built-in "children" view.
# FormatsToProcess in the manifest uses AppendPath by default, so we need this.
$_formatFile = Join-Path $PSScriptRoot 'PSFileIcons.format.ps1xml'
Update-FormatData -PrependPath $_formatFile
Remove-Variable _formatFile
