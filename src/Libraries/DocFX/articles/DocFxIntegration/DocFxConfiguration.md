# DocFX configuration

There are a few changes that need to be made to the following files:

* DocFx/docfx.json
* DocFX/index.md
* DocFX/toc.yml

#### DocFX output

When documentation is built, it will be created in Abatab/docs/. This makes it easy to use GitHub Pages to host the documentation on the repository.

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
