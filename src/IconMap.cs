using System;
using System.Collections.Generic;

namespace PSFileIcons
{
    /// <summary>
    /// Provides Nerd Font icon glyphs for file extensions and directory names.
    /// All mappings are compiled in — no file I/O at runtime.
    /// </summary>
    public static class IconMap
    {
        // Default icons — use universally-present Font Awesome glyphs (U+F000 range)
        public const string DefaultFile = "\uf15b";       //  nf-fa-file
        public const string DefaultDir  = "\uf07b";       //  nf-fa-folder
        public const string DefaultExe  = "\uf013";       //  nf-fa-cog

        private static readonly Dictionary<string, string> ByExtension =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // Shell / scripting
            { ".ps1",    "\ue796" }, //
            { ".psm1",   "\ue796" }, //
            { ".psd1",   "\ue796" }, //
            { ".sh",     "\uf489" }, //
            { ".bash",   "\uf489" }, //
            { ".zsh",    "\uf489" }, //
            { ".fish",   "\ue795" }, //
            { ".bat",    "\ue629" }, //
            { ".cmd",    "\ue629" }, //

            // Go
            { ".go",     "\ue627" }, //

            // Rust
            { ".rs",     "\ue7a8" }, //

            // Python
            { ".py",     "\ue73c" }, //
            { ".pyc",    "\ue73c" }, //
            { ".pyw",    "\ue73c" }, //

            // JavaScript / TypeScript
            { ".js",     "\ue74e" }, //
            { ".mjs",    "\ue74e" }, //
            { ".cjs",    "\ue74e" }, //
            { ".ts",     "\ue628" }, //
            { ".tsx",    "\ue7ba" }, //
            { ".jsx",    "\ue7ba" }, //

            // Web
            { ".html",   "\ue736" }, //
            { ".htm",    "\ue736" }, //
            { ".css",    "\ue749" }, //
            { ".scss",   "\ue749" }, //
            { ".sass",   "\ue749" }, //
            { ".less",   "\ue749" }, //
            { ".svg",    "\ufc1f" }, //

            // C family
            { ".c",      "\ue61e" }, //
            { ".h",      "\ue61e" }, //
            { ".cpp",    "\ue61d" }, //
            { ".cc",     "\ue61d" }, //
            { ".cxx",    "\ue61d" }, //
            { ".hpp",    "\ue61d" }, //
            { ".cs",     "\ue77f" }, //

            // JVM
            { ".java",   "\ue738" }, //
            { ".class",  "\ue738" }, //
            { ".jar",    "\ue738" }, //
            { ".kt",     "\ue634" }, //
            { ".kts",    "\ue634" }, //
            { ".scala",  "\ue737" }, //
            { ".gradle", "\ue70e" }, //

            // Ruby / Elixir / Erlang
            { ".rb",     "\ue791" }, //
            { ".ex",     "\ue62d" }, //
            { ".exs",    "\ue62d" }, //
            { ".erl",    "\ue7b1" }, //

            // PHP
            { ".php",    "\ue73d" }, //

            // Swift / Objective-C
            { ".swift",  "\ue755" }, //
            { ".m",      "\uf302" }, //

            // Data / config
            { ".json",   "\ue60b" }, //
            { ".yaml",   "\ue6a8" }, //
            { ".yml",    "\ue6a8" }, //
            { ".toml",   "\ue6b2" }, //
            { ".xml",    "\ue619" }, //
            { ".csv",    "\uf1c3" }, //
            { ".ini",    "\uf17a" }, //
            { ".conf",   "\uf17a" }, //
            { ".cfg",    "\uf17a" }, //
            { ".env",    "\uf462" }, //
            { ".editorconfig", "\ue615" }, //
            { ".gitignore",    "\ue702" }, //
            { ".gitmodules",   "\ue702" }, //
            { ".gitattributes","\ue702" }, //

            // Docs / text
            { ".md",     "\ue609" }, //
            { ".mdx",    "\ue609" }, //
            { ".txt",    "\uf15c" }, //
            { ".log",    "\uf18d" }, //
            { ".pdf",    "\uf1c1" }, //
            { ".doc",    "\uf1c2" }, //
            { ".docx",   "\uf1c2" }, //
            { ".xls",    "\uf1c3" }, //
            { ".xlsx",   "\uf1c3" }, //
            { ".ppt",    "\uf1c4" }, //
            { ".pptx",   "\uf1c4" }, //

            // Images
            { ".png",    "\uf1c5" }, //
            { ".jpg",    "\uf1c5" }, //
            { ".jpeg",   "\uf1c5" }, //
            { ".gif",    "\uf1c5" }, //
            { ".bmp",    "\uf1c5" }, //
            { ".webp",   "\uf1c5" }, //
            { ".ico",    "\uf1c5" }, //

            // Audio / video
            { ".mp3",    "\uf001" }, //
            { ".wav",    "\uf001" }, //
            { ".flac",   "\uf001" }, //
            { ".mp4",    "\uf03d" }, //
            { ".mkv",    "\uf03d" }, //
            { ".avi",    "\uf03d" }, //
            { ".mov",    "\uf03d" }, //

            // Archives — nf-fa-file_archive_o (U+F1C6, Font Awesome, universal)
            { ".zip",    "\uf1c6" }, //
            { ".tar",    "\uf1c6" }, //
            { ".gz",     "\uf1c6" }, //
            { ".bz2",    "\uf1c6" }, //
            { ".xz",     "\uf1c6" }, //
            { ".7z",     "\uf1c6" }, //
            { ".rar",    "\uf1c6" }, //
            { ".zstd",   "\uf1c6" }, //
            { ".zst",    "\uf1c6" }, //

            // Executables / binaries
            { ".exe",    "\uf013" }, //
            { ".dll",    "\uf013" }, //
            { ".so",     "\uf013" }, //
            { ".dylib",  "\uf013" }, //
            { ".wasm",   "\uf013" }, //

            // Containers / infra
            { ".dockerfile", "\uf308" }, //
            { ".tf",     "\ue69a" }, //
            { ".tfvars", "\ue69a" }, //
            { ".nix",    "\uf313" }, //

            // Lockfiles / generated
            { ".lock",   "\uf023" }, //
            { ".sum",    "\uf023" }, //
        };

        // Well-known file names that override extension-based lookup
        private static readonly Dictionary<string, string> ByName =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Dockerfile",       "\uf308" }, //
            { "Makefile",         "\uf489" }, //
            { "CMakeLists.txt",   "\ue61d" }, //
            { ".gitignore",       "\ue702" }, //
            { ".gitmodules",      "\ue702" }, //
            { ".gitattributes",   "\ue702" }, //
            { "go.mod",           "\ue627" }, //
            { "go.sum",           "\ue627" }, //
            { "Cargo.toml",       "\ue7a8" }, //
            { "Cargo.lock",       "\ue7a8" }, //
            { "package.json",     "\ue74e" }, //
            { "package-lock.json","\ue74e" }, //
            { "tsconfig.json",    "\ue628" }, //
            { "requirements.txt", "\ue73c" }, //
            { "Pipfile",          "\ue73c" }, //
            { "pyproject.toml",   "\ue73c" }, //
            { "LICENSE",          "\uf48a" }, //
            { "README.md",        "\ue609" }, //
            { "CHANGELOG.md",     "\ue609" }, //
        };

        // Well-known directory names
        private static readonly Dictionary<string, string> ByDirName =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".git",        "\ue702" }, //
            { ".github",     "\ue702" }, //
            { "node_modules","\ue74e" }, //
            { ".vscode",     "\ue70c" }, //
            { ".idea",       "\ue7b5" }, //
            { "bin",         "\uf017" }, //
            { "src",         "\uf121" }, //
            { "dist",        "\uf121" }, //
            { "build",       "\uf121" }, //
            { "docs",        "\uf02d" }, //
            { "test",        "\uf0c3" }, //
            { "tests",       "\uf0c3" }, //
            { ".config",     "\uf013" }, //
            { "vendor",      "\uf187" }, //
        };

        public static string GetFileIcon(string? name, string? extension)
        {
            if (name != null && ByName.TryGetValue(name, out var nameIcon))
                return nameIcon;
            if (extension != null && ByExtension.TryGetValue(extension, out var extIcon))
                return extIcon;
            return DefaultFile;
        }

        public static string GetDirIcon(string? name)
        {
            if (name != null && ByDirName.TryGetValue(name, out var dirIcon))
                return dirIcon;
            return DefaultDir;
        }
    }
}
