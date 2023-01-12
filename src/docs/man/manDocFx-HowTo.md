<div align="center">

  <img src="../images/Logo/AbatabManualLogo.png" alt="Abatab Manual" width="512">
  <br>
  <br>
  <h1>
    Version 23.0
  </h1>

</div>

# Abatab and DocFX

The Abatab implementation of DocFX, which is included in the official Abatab release, is non-standard.

This document will detail how the Abatab implementation of DocFX was created.

# Creating a new DocFX project

DocFX is integrated directly to Abatab via a class library:

1. Create a new .NET Framework 4.8 Class Library project named **DocFX**
2. Add the `docfx.console` NuGet package
3. Add the *DocFX/* folder to the *src/ThirdParty/* folder
4. Add a reference to the **DocFX** project to Abatab

# Modifying the DocFX project

By default, *most* of the data that DocFX needs to generate documentation is located at `src/ThirdParty/DocFX/`.

For Abatab, I wanted that information a little closer to the rest of the code, so I've moved it to `src/docs/`.

## Moving required files and folders

There are some standard folders and files in `src/ThirdParty/DocFX/` that DocFX expects, and will need to be moved to `src/docs/`:

```bash
images/*
obj/*
index.md
toc.yml
```

## Creating Abatab-specific files and folders

Abatab needs a few non-standard files and folders located in `src/docs/`:

```bash
api/*
doc/*
man/*
favicon.ico
logo.svg
```

# Modifying the `docfx.json` configuration file

The `src/ThirdParty/DocFX/docfx.json` file contains the configuration information for DocFX.

For reference, the default docfx.json configuration looks like [this](https://github.com/spectrum-health-systems/Abatab/blob/main/src/ThirdParty/DocFX/docfx_default.json).

We will need to make a few modifications to `docfx.json` in order for it to work with Abatab.

## Targeting all Abatab projects

Since want to target all of the current/future projects in Abatab, we will point DocFX to Abatab.sln by changing the `{"metadata" {"src:" {"files:"}}}` section of the `docfx.json` file from `*.csproj` to `Abatab.sln` by changing this:

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

We also need to let DocFX know where to find `Abatab.sln` by changing this:

```bash
"cwd": ".",
```

to

```bash
"src": "../../",
```

## Pointing DocFX to *src/docs/*

We need to let DocFX know will be storing the information used to generate API documentation in *src/docs/*, and we will do that by changing the `{"metadata" {"dest:"}}` section of the `docfx.json` file from `"obj/api"` to `"../../docs/obj/api"` by changing this:

```bash
"dest": "obj/api"
```

to this:

```bash
"dest": "../../docs/obj/api"
```

## Modifying where data to generate API documentation is located

The data that DocFX needs to generate documentation is found in `src/docs/`, so we need to change the following in `{"build" {"content"}}` from this:

```bash
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
          "toc.yml",
          "*.md"
        ],
        "exclude": [
          "obj/**",
          "_site/**"
        ]
      }
    ],
```

to this:

```bash
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
```

## Creating required resources

There are a few file and folder resources that we'll need to setup so we need to change the following in `{"build" {"resource"}}` from this:

```bash
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
```

to this:

```bash
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
```

You'll also need the [Abatab logo]() and [favicon]().

## Defining the output directory

DocFX will output documentation to the `/docs` directory in the Abatab repository, so we need to change the following in `{"build" {"dest"}}` from this:

```bash
"dest": "_site",
```

to this:

```bash
"dest": "../../../docs/",
```

### GitHub Pages

DocFX outputs to `/docs` because that is one of the options when setting up GitHub Pages with the Abatab repository.

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
