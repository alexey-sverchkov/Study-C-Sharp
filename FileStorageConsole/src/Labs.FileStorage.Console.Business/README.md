# File Storage Console app

Simple storage, which supports single user and files upload /
manipulation capabilities.

## Prerequisites

This sample **requires** prerequisities in order to run

### Install .NET Core CLI

- [.NET Core SDK](https://dotnet.microsoft.com/download) version 3.1

    ```bash
    # determine dotnet version
    dotnet --version
    ```

## To try this sample

- In a terminal navigate to `Labs.FileStorage.Console`

    ```bash
    # change into project folder
    cd Labs.FileStorage.Console
    ```

- Run app from a terminal or from [Visual Studio](https://visualstudio.microsoft.com/downloads/)

    A) From a terminal
    ```bash
    # run the app
    dotnet run --l "login of user" --p "password of user"
    ```
    See all available users in `appsettings.json` file.

    B) From Visual Studio
    
    - Launch Visual Studio
    - File -> Open -> Project/Solution
    - Navigate to `Labs.FileStorage.Console` folder
    - Select `Labs.FileStorage.Console.csproj` file
    - Press `Ctrl + F5` to run the project

## Available commands

### User

- `user info` - command shows information about user (login, creation date, storage used)

    ```bash
    > user info

    login: example@gmail.com
    creation Date: 2017-05-12
    storage used: 564 MB
    ```

### Files

- `file upload <path-to-file>` - uploading a file located 
along the path `<path-to-file>` in the storage

    ```bash
    > file upload "~/movies/sci-fi/k-pax.mkv"

    The file "~/movies/sci-fi/k-pax.mkv" has been uploaded
    - file name: "k-pax.mkv"
    - file size: 4.3 Gb
    - extension: "mkv"
    ```

- `file download <file-name> <destination-path>` - download
file with name `file-name` from the storage to the directory
`destination-path`. 

    ```bash
    > file download "k-pax.mkv" "~/movies/best"

    The file "k-pax.mkv" has been downloaded
    ```

- `file move <source-file-name> <destination-file-name>` -
rename file in the storage - from path `source-file-name`
into `destination-file-name`

    ```bash
    > file move "k-pax.mkv" "k-pax-the-best.mkv"

    The file "k-pax.mkv" has been moved to "k-pax-the-best.mkv"
    ```

- `file remove <file-name>` - delete file `file-name` from the storage *beyond recovery*

    ```bash
    > file remove "k-pax.mkv"

    The file "k-pax.mkv" has been removed
    ```

- `file info <file-name>` - display info about file `file-name`

    ```bash
    > file info "k-pax.mkv"

    - file name: "k-pax.mkv"
    - file extension: "mkv"
    - file size: 4.3 Gb
    - creation date: 2017-09-09
    - number of downloads: 12
    ```

### Export

- `file export <destination-path> --format <format>` - save all metainformation about files along the given `destination-path` in format `format`

    ```bash
    > file export "~/work/meta-info.json" --format json

    The meta-information has been exported, path = "~/work/meta-info.json"
    ```

    *Remark:* if option `format` is not specified, than it will save in default `json` format.

- `file export --info` - display all available export formats

    ```bash
    > file export --info

    Available export formats:
    - json
    - xml    
    ```

### Other

- `exit` - to exit from app.