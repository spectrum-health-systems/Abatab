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

You can use the pre-built [DocFX for abatab][docfx-for-abatab] project, or create your own by following these steps:

1. Create a new .NET Framework 4.8 Class Library project named "DocFX"
2. Add the `docfx.console` NuGet package
3. Add the DocFX/ folder to the src/ThirdParty/" folder
4. Add a reference to the DocFX project to Abatab

# Configuring DocFX for Abatab

Abatab doesn't use the defauly DocFX locations, so we'll make a few changes.

## Creating a folder for documentation

Create a folder named "src/docs/".

This is where the content that DocFX will build from is located.

## Copying existing data to *src/docs/*

Copy the following files and folders located in *src/ThirdParty/DocFX/* to *src/docs/*:

```bash
images/*
obj/*
index.md
toc.yml
```

## Creating Abatab-specific data in *src/docs/*

Create the following files and folders in *src/docs/*:

```bash
api/*
doc/*
man/*
favicon.ico
logo.svg
```

## Modifying *src/ThirdParty/DocFX/docfx.json*

The docfx.json file is the only file that stays in the default location.

### Modifying the `metadata` sextion

We want to target all of the projects in Abatab, so we will point DocFX to Abatab.sln by changing the metadata section of the docfx.json file to:

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
    "dest": "../../docs/obj/api"
  }
],
```

### Modifying the `build` section

Since we be storing the conceptual data and building the documentation in a non-standard locations, change the `build` section to:

```bash
"build": {
    "content": [
      {
        "files": [
          "api/**.yml"
        ],
        "src": "../../docs/obj"
      },
      {
        "files": [
          "api/*.md",
          "doc/**.md",
          "man/**.md",
          "toc.yml",
          "*.md"
        ],
        "exclude": [
          "obj/**",
          "_site/**"
        ],
        "src": "../../docs"
      }
    ],
    "resource": [
      {
        "files": [
          "images/**",
          "logo.svg",
          "favicon.ico"
        ],
        "exclude": [
          "obj/**",
          "_site/**"
        ],
        "src": "../../docs"
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
```

## Modifying *src/docs/toc.yml*

The src/docs/toc.yml file should look like this:

```bash
- name: Abatab Manual
  href: man/
  homepage: man/index.md
- name: Abatab Documentation
  href: doc/
  homepage: doc/index.md
- name: API Documentation
  href: obj/api/
  homepage: api/index.md
  ```

  ## Modifying *src/docs/index.md*

TBD

# Building (or rebuilding) the documentation

To build (or rebuild!) the Abatab documentation:

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

[docfx-url]: https://dotnet.github.io/docfx/
[docfx-for-abatab]: https://github.com/spectrum-health-systems/Abatab/blob/main/dep/DocFX/DocFX-for-Abatab.7z
