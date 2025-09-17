# Build Your Own wc Tool (ccwc)

This project is a command-line utility built with C# and .NET 8 that replicates the functionality of the Unix `wc` (word count) command.

It allows you to count lines, words, characters, and bytes in a text file, supporting both direct file input and piped input using the `cat` command style.

---

## Table of Contents

- [Technologies Used](#technologies-used)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)

---

## Technologies Used

- [C# 12.0](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12)
- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/dotnet-eight)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

---

## Features

- Supports the following options, just like the Unix `wc` command:<br>
  -> `-l`: Count the number of lines in a file.<br>
  -> `-c`: Count the number of bytes in a file.<br>
  -> `-m`: Count the number of characters in a file.<br>
  -> `-w`: Count the number of words in a file.<br>

- - Can be used with or without the `cat` command (e.g., `cat file.txt | ccwc -l`).
- If only a filename is provided, the tool searches for the file in the `src` directory.
- If a full path is provided, the tool searches for the file at the specified path.

---

## Installation

1. **Clone the repository:**
```sh
git clone https://github.com/MohammadRokib/WC-Tool-DotNet.git
```
2. **Open the solution in Visual Studio 2022:**
3. **Place your text files:**
- If you want to use just the filename, put your text files in the `src` directory inside the project.
- If you want to use a full path, place your file anywhere and provide the full path when running the tool.

---

## Usage

You can use the WC Tool in two ways:

```bash
ccwc <option> <filepath>
cat <filepath> | ccwc <option>
```

The following options can be used with this tool:

- `-c` → Count the number of **bytes** in the file  
- `-m` → Count the number of **characters** in the file  
- `-l` → Count the number of **lines** in the file  
- `-w` → Count the number of **words** in the file
- **Default (no flags)** → Show **lines, words, and bytes**

> **Note:**  
> - If `<filepath>` is just a filename (e.g., `sample.txt`), the tool will look for the file in the `src` directory of the project.  
> - If `<filepath>` is a full path, the tool will use the file at that location.