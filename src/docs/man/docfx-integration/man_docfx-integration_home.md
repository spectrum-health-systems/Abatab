<div align="center">

  <img src="../../images/man-logo.png" alt="Abatab Manual" width="512">

  <h4>
    Abatab v22.11.0
  </h4>

</div>

***

# Abatab and DocFX

Abatab uses [DocFX](https://dotnet.github.io/docfx/) for documentation.

# Creating a new DocFX project

DocFX is integrated directly to Abatab via a class library.

You can use the included [DocFX project](../dep/DocFX-for-Abatab.7z), or create your own by following these steps:

1. Create a new .NET Framework 4.8 Class Library project named "DocFX"
2. Add the docfx.console NuGet package
3. Remove "DocFX/Class1.cs"
3. Add DocFX/ to Abatab/Libraries/"
4. Add the DocFX project to Abatab, in the Libraries/ solution folder

# Configuring DocFX

There are a few changes that need to be made to the following files:

* DocFx/docfx.json
* DocFX/index.md
* DocFX/toc.yml

> When documentation is built, it will be created in Abatab/docs/. This makes it easy to use GitHub Pages to host the documentation on the repository.

## DocFx/docfx.json

### Targeting the solution

We want to target all of the projects in Abatab, so we will point DocFX to Abatab.sln by changing

```bash
"metadata": [
    {
      "src": [
        {
          "files": [
            "*.csproj"
          ],
          "cwd": ".",
          "exclude": [
            "**/obj/**",
            "**/bin/**",
            "_site/**"
          ]
        }
      ],
      "dest": "obj/api"
    }
```

to

```bash
"metadata": [
    {
      "src": [
        {
          "files": [
            "*.sln"
          ],
          "src": "../../",
          "exclude": [
            "**/obj/**",
            "**/bin/**",
            "_site/**"
          ]
        }
      ],
      "dest": "obj/api"
    }
```

### Adding the manual

The Abatab Manual will be created by DocFX, so in the "build" section we need to change

```bash
 {
        "files": [
          "api/*.md",
          "articles/**.md",
          "toc.yml",
          "*.md"
        ],
```

to 

```bash
 {
        "files": [
          "api/*.md",
          "articles/**.md",
          "manual/**.md",
          "toc.yml",
          "*.md"
        ],
```

### Changing the destination

We want to host all of the documentation using GitHub Pages, so all of the data DocFX creates needs to be available in docs/, so change

```bash
    "dest": "_site",
```

to

```bash
    "dest": "../../../docs/",
```

### The final docfx.json file

The final docfx.json file should look like this:

```bash
{
  "metadata": [
    {
      "src": [
        {
          "files": [
            "*.sln"
          ],
          "src": "../../",
          "exclude": [
            "**/obj/**",
            "**/bin/**",
            "_site/**"
          ]
        }
      ],
      "dest": "obj/api"
    }
  ],
  "build": {
    "content": [
      {
        "files": [
          "api/**.yml"
        ],
        "cwd": "obj"
      },
      {
        "files": [
          "api/*.md",
          "articles/**.md",
          "manual/**.md",
          "toc.yml",
          "*.md"
        ],
        "exclude": [
          "obj/**",
          "_site/**"
        ]
      }
    ],
    "resource": [
      {
        "files": [
          "images/**"
        ],
        "exclude": [
          "obj/**",
          "_site/**"
        ]
      }
    ],
    "overwrite": [
      {
        "files": [
          "apidoc/**.md"
        ],
        "exclude": [
          "obj/**",
          "_site/**"
        ]
      }
    ],
    "dest": "../../../docs/",
    "template": [
      "default"
    ]
  }
}
```

## DocFx/index.html

TBD

## DocFx/toc.yml

DocFx/toc.yml should look like this:

```bash
- name: Manual
  href: manual/
- name: Articles
  href: articles/
- name: API Documentation
  href: obj/api/
  homepage: api/index.md

```

# Building/rebuilding the documentation

To build/rebuild the Abatab documentation:

1. Clean the Abatab solution
2. Rebuild the Abatab solution

The documentation is created in https://github.com/spectrum-health-systems/Abatab/docs

# Verifying the documentation

DocFx allows you to host the documentation via localhost, which makes it easy to verify any modifications.

1. Open a terminal in the `docs/` folder
2. Type "`docfx serve`"
3. Point a web browser to http://localhost:8080/

# GitHub Pages

If you use GitHub pages, and point to /docs, the documentation will be available on the GitHub repository.

***

Abatab is developed by [A Pretty Cool Program][a-pretty-cool-program-url]

[abatab-repository-url]: https://github.com/spectrum-health-systems/Abatab
[netsmart-avatar-url]: https://www.ntst.com/Offerings/myAvatarg
[man-getting-started]: ./man-getting-started.md
[man-hosting]: ./man-hosting.md
[man-importing]: ./man-importing.md
[man-configuration]: ./man-configuration.md
[man-using]: ./man-using.md
[man-additional-information]: ./man-additional-information.md
[a-pretty-cool-program-url]: https://github.com/APrettyCoolProgram
