# Creating a new DocFX project

DocFX is integrated directly to Abatab via a class library.

You can use the included DocFX project, or create your own by following these steps:

1. Create a new .NET Framework 4.8 Class Library project named "DocFX"
2. Add the docfx.console NuGet package
3. Remove "DocFX/Class1.cs"
3. Add DocFX/ to Abatab/Libraries/"
4. Add the DocFX project to Abatab, in the Libraries/ solution folder

## DocFX/docfx.json

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

## DocFX/toc.yml

```bash
- name: Articles
  href: articles/
- name: API Documentation
  href: obj/api/
  homepage: api/index.md
```

## DocFX/index.html

```bash
# Abatab documentation
```

## DocFX/api/index.html

```bash
# Source code documentation
```

## DocFX/articles/intro.md

```bash
# Add your introductions here!
```

## DocFX/articles/toc.md

```bash
#[Introduction](intro.md)
#[Something else](details1.md)
##[Another thing](details2.md)
```