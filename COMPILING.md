# Compiling and Building from Source Code

## Prerequisites
1. Clone this repository or download the source codes. 
2. Download **.NET SDK 8.0**.

### Clone the Repository
The repository is uploaded in GitHub clone the repository to get started.
```zsh
git clone https://github.com/mrwnmncd/peter-parking.git
```

### Build and Compile the Program
The program is non-dependent to any library except those built into .NET. Simply open the project folder and you should be able to build the app. It will create a `bin` folder if not yet existing in the Parking folder.
```zsh
dotnet build
```
If you want to build the program for distribution, run the following command below. By default, the compilation will target your system's environment.
```sh
dotnet publish -c Release
```
##### Other Compilation Methods 
Compiling from source allows you to select an operting system to target. See the options below for other operating system: <br />
- Windows (64 bit): `dotnet publish -c Release -r win-x64`
- Windows (32 bit): `dotnet publish -c Release -r win-x86`
- macOS (Intel-based chips): `dotnet publish -c Release -r osx-x64`
- macOS (M-series SOCs): `dotnet publish -c Release -r osx-arm64`
- Linux: `dotnet publish -C Release -r linux-x64`
- Linux (ARM-based): `dotnet publish -C Release -r linux-arm64`
