# Directory structure

## Overview

```#text
+---Abatab                      Abatab
+---Core                        Abatab Core components
+---Module                      Abatab Module components
+---ThirdParty                  Abatab third-party components
```

# Abatab

```#text
+---Abatab
|   +---.github                 Abatab repository data, documents, and other resources
|   +---docs                    DocFX data output (for GitHub pages)
|   +---src                     Abatab source code
```

## Abatab\\.github\

The `.github\` directory contains repository resources that don't necessarily need to be visible to the end user.

```#text
+---.github
|   +---dev                     Development data
|   |   +---doc                 Development documenation and notes
|   |   +---palettes            Application color palettes
|   +---res                     Repository resources
|       +---image               Repository images
|       |   +---docfx           DocFX images
|       |   +---logo            Abatab logos
|       |   |   +---app         Application logos
|       |   |   \---man         Manual logos
|       |   +---screenshot      Screenshots
```

## Abatab\docs\

The `docs\` directory contains the output from DocFX when Abatab is built, and is used as the source for GitHub pages.

```#text
+---docs
|   +---api               API documentation sources
|   +---doc               Abatab documentation sources
|   |   \---ReleaseNotes  Abatab version release notes
|   +---fonts             Fonts for DocFX documents
|   +---images            Images for DocFX documents
|   +---man               Abatab Manual sources
|   \---styles            Styles for DocFX documents
```

## Abatab\src\

The `src\` directory contains the main Abatab source code. Some standard project directories are not listed here.

```#text
|   \---src                               Abatab main source code
|       +---bin                           Abatab build results
|       +---docs                          DocFX documenation sources
|       |   \---Documentation Project     The Abatab Documentation Project
|       +---Documentation                 XML documentation
|       +---Properties                    Local Settings.settings file located here
```

***

<div align="center">

  This document is part of the [Abatab Documentation Project](../Abatab%20Documentation%20Project.md).

  <h5>
    Last updated: 230316.0938
  </h5>

</div>
