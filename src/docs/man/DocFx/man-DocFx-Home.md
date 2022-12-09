<div align="center">

  <img src="../../images/man-logo.png" alt="Abatab Manual" width="512">

  <h4>
    Abatab v23.0.0
  </h4>

</div>

***

# Abatab and DocFX

Abatab uses [**DocFX**](https://dotnet.github.io/docfx/) to generate documentation. DocFX is a cross-platform, extensible, scalable static documentation generator that can produce documentation from source code as well as raw Markdown files.

By default, *most* of the data that DocFX needs to generate documentation is located at `src/ThirdParty/DocFX/`.

For Abatab, I wanted that information a little closer to the rest of the code, so I've moved it to `src/docs/`.

This document will walk through what you need to get DocFX working in Abatab.

## Creating a new DocFX project

The official release of Abatab already contains DocFX

DocFX is integrated directly to Abatab via a class library.

You can use the pre-built [DocFX for abatab][docfx-for-abatab] project, or create your own by following these steps:

1. Create a new .NET Framework 4.8 Class Library project named **DocFX**
2. Add the `docfx.console` NuGet package
3. Add the *DocFX/* folder to the *src/ThirdParty/* folder
4. Add a reference to the **DocFX** project to Abatab



# 

 Most of these changes will involve moving data from the default DocFX folder and creating folders and files specific to Abatab.

The one file that will stay in the default DocFx location is the DocFX configuration file, `docfx.json`.

## Creating a folder for documentation


## Copying existing data to *src/docs/*

There are some standard folders and files in *src/ThirdParty/DocFX/* that DocFX expects, and will need to be moved to *src/docs/*:

```bash
images/*
obj/*
index.md
toc.yml
```

# Modifying the *docfx.json* configuration file

The *src/ThirdParty/DocFX/docfx.json* file contains the configuration information for DocFX.

For reference, the default docfx.json configuration looks like [this](https://github.com/spectrum-health-systems/Abatab/blob/main/src/ThirdParty/DocFX/docfx_default.json).

We will need to make a few modifications to *docfx.json* in order for it to work with Abatab.

## Targeting all Abatab projects

Since want to target all of the current/future projects in Abatab, we will point DocFX to Abatab.sln by changing the `{"metadata" {"src" {"files:"}}}` section of the `docfx.json` file from `*.csproj` to `Abatab.sln` by changing this:

```bash
"files": [
  "*.csproj"
],
```

to this:

```bash
"files": [
  "*.sln"
],
```

### Pointing DocFX to *src/docs/*

We need to let DocFX knowe will be storing the information used to generate DocFX documentation in *src/docs/*, and we will do that by changing the `{"metadata" {"dest:"}}` section of the `docfx.json` file from `"obj/api"` to `"../../docs/obj/api"` by changing this:

```bash
"dest": "obj/api"
```

to this:

```bash
"dest": "../../docs/obj/api"
```








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




## Creating Abatab-specific data in *src/docs/*

Create the following files and folders in *src/docs/*:

```bash
api/*
doc/*
man/*
favicon.ico
logo.svg
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
