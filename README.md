# Generate JSON WEB TOKEN with C# 

Generates/Mints a JWT and prints it to shell's standard output.

## Build with Visual Studio Code: 
- Download .net core 3.0 (https://dotnet.microsoft.com/download/dotnet-core)
- Download Visual Studio Code (https://code.visualstudio.com/)
- Install Extension C# for VS Code (Extension: C# for Visual Studio Code (powered by OmniSharp).
- From VS Code Open Folder jwt-csharp-netcore
- Click View -> Terminal
- Build:
  ``` bash
    dotnet build
  ```
- Run:
  ``` bash
  #generate an app token
  dotnet run --key=path/to/private/key.pem --issuer_id=YOUR_ISSUER_ID

  # generate a user token
   dotnet run --key=path/to/private/key.pem --issuer_id=YOUR_ISSUER_ID --username=a_username
  ```

## Publish for Windows OS
- Debug build (/bin/Debug)
  ```bash
  dotnet publish -c Debug -r win10-x64
  ```
- Release build (/bin/Release)
  ```bash
  dotnet publish -c Release -r win10-x64
  ```
- Run:
  ```bash
  jwt-csharp-core.exe --key=<private key path> --issuer_id=<your issuer id>
  ```

## Publish for Mac OS
- Debug build (/bin/Debug)
  ``` bash
  dotnet publish -c Debug -r osx.10.12-x64
  ```
- Release build (/bin/Release)
  ``` bash
  dotnet publish -c Release -r osx.10.12-x64
  ```
- Run:
   ``` bash
   dotnet jwt-csharp-core.dll --key=<private key path> --issuer_id=<your issuer id>
   ```
## Publish for Ubuntu OS
- Debug build (/bin/Debug)
  ``` bash
  dotnet publish -c Debug -r ubuntu.18.04-x64
  ```
- Release build (/bin/Release)
  ``` bash
  dotnet publish -c Release -r ubuntu.18.04-x64
  ```
- Run:
   ``` bash
   dotnet jwt-csharp-core.dll --key=<private key path> --issuer_id=<your issuer id>
   ```

## About jwt-csharp-netcore
- Uses .net core 3.0 (.net core 2.2 is an option)
- Package Libraries used:
	- BouncyCastle 1.8.5
	- jose-jwt 2.4.0

## How to switch between .net core 3.0 and .net core 2.2
- Edit jwt-csharp-netcore.csproj
- Find "TargetFramework" and switch 3.0 to 2.2 or 2.2 to 3.0
