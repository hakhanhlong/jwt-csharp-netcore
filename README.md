# Generate JSON WEB TOKEN with C# 

## Information brief jwt-csharp-netcore
- Program write on Visual studio 2017, Console App (Core)
- Used .net core 3.0 (.net core 2.2 is option)
- Package Library use to program:
	BouncyCastle 1.8.5
	jose-jwt 2.4.0

## Switch between .net core 3.0 and .net core 2.2
- Edit file jwt-csharp-netcore.csproj
- Find "TargetFramework" and switch 3.0 to 2.2 or 2.2 to 3.0

## Build with Visual Studio Code: 
- Download .net core 3.0 (https://dotnet.microsoft.com/download/dotnet-core)
- Download Visual Studio Code (https://code.visualstudio.com/)
- Install Extension C# for VS Code (Extension: C# for Visual Studio Code (powered by OmniSharp).
- From VS Code Open Folder jwt-csharp-netcore
- Click View -> Terminal
- Type for Build:
  ``` bash
    dotnet build
  ```
- Type for Run:
  ``` bash
    dotnet run --key=e:/jwtprivate.key --issuer=0098bef0-c3644110-9a8f-4021-b361-c3060de235f6
  ```
  or
  ``` bash
    dotnet run --key=e:/jwtprivate.key --issuer=0098bef0-c3644110-9a8f-4021-b361-c3060de235f6 --username=hklong
  ```


## Publish for window OS usaged under command line (build the code to an executable)
- Build to .exe
  - Debug build (/bin/Debug)
    ``` bash
        dotnet publish -c Debug -r win10-x64
    ```
  - Release build (/bin/Release)
    ``` bash
        dotnet publish -c Release -r win10-x64
    ```
  - Run:
   ``` bash
       jwt-csharp-core.exe --key=<private key path> --issuer=<your issuer id>
   ```

## Publish for Mac OS usaged under command line (build the code to an executable)
- Build to .exe
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
       dotnet jwt-csharp-core.dll --key=<private key path> --issuer=<your issuer id>
   ```
## Publish for Ubuntu OS usaged under command line (build the code to an executable)
- Build to .exe
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
       dotnet jwt-csharp-core.dll --key=<private key path> --issuer=<your issuer id>
   ```



