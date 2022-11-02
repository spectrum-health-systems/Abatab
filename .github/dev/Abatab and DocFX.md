# Abatab and DocFX

1. Create a new .NET Framework 4.8 Class Library project named "DocFX"
2. Add the docfx.console NuGet package
3. Remove "DocFX/Class1.cs"
3. Add DocFX/ to Abatab/Libraries/"
4. Add the DocFX project to Abatab, in the Libraries/ solution folder

The *docfx.json" file should look like this

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
          "api/**.yml",
          "index.md",
          "toc.md"
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
    "dest": "../../../doc/srcdoc/",
    "template": [
      "default",
      "templates/darkfx"
    ]
  }
}
```
