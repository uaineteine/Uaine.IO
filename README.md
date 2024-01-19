# Uaine.IO

A C# .NET standard project for managing collections of JSON file stores.

## Getting Started

Add source project to solution with reference to get started or install via [NuGet](https://www.nuget.org/packages/Uaine.Archive/)

## Version 0.1

See the [changelog](changelog.txt) for details.

## Getting Started

```bash
dotnet add package Uaine.Archive
```

```csharp
using Uaine.Archive;

// Create an archive
var archive = new Archive<int>("MyIntCollection");

// Create file stores
var fileStore1 = new JsonFileStore<int>("file1.json", "data1", new int[] { 1, 2, 3 });
var fileStore2 = new JsonFileStore<int>("file2.json", "data2", new int[] { 4, 5, 6 });

// Add file stores to the archive
archive.AddFileStore(fileStore1);
archive.AddFileStore(fileStore2);

// Load files by index or data name
var loadedFileByIndex = archive.LoadFileByIndex(0);
var loadedFileByDataName = archive.LoadFileByDataName("data2");
```

## Authors

* **Daniel Stamer-Squair** - *UaineTeine*

## Donate

If you like my work and are feeling generous, you can leave me tip on ko-fi. Even the smallest donation is more than welcome and will make my day :)

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/C0C43PQ0I)

<!--Alternatively you can become a patron :D

[![patroen](https://i.imgur.com/SWniXXj.png)](https://www.patreon.com/bePatron?u=51145413)-->

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
