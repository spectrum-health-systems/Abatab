> [Abatab][AbatabRepoUrl] &gt; **Source code documentation**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h1>
    Abatab<br>
    <b>v0.90.0</b>
  </h1>

</div>

# About

I would like to keep the Abatab source code pretty clean, so this documentation will provide details of what everthing does.

# Sourcecode headers

Every class has a standard header that provides details about the Abatab application, the specific project, and the current class.

```#bash
/* ========================================================================================================
 * Abatab v0.0.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabData v0.0.0
 * AbatabData.SessionData.cs bYYMMDD.HHMMSS
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabData.md
 * ===================================================================================================== */
```

## Versions

[Semantic versioning](https://semver.org/) is used to indicate the current version of abatab.

`<X>.<Y>.<Z>-<build type>.<build version+<yyMMdd.HHmmss>`

Where:
* **`<X>`** is a the major version
* **`<Y>`** is a the minor version
* **`<Z>`** is a the patch version
* **`<build type>`** is a the (optional) release build type
* **`<build version>`** is a the release build type version (if `<build type>` is used)
* **`<yyMMdd.HHmmss>`** is a the date/timestamp of the release (using 24-hour time)

Examples:

* v1.0.0+210717.123033
* v1.1.1-rc.1+210717.123033
* v2.0.0-development.47+210717.123033

## Builds

Each class has a `<build number>`, indicating when the class was last modified. The \<build number\> is located in sourcode headers, and can differ between classes.

When classes are updated, the build number in the sourcecode header is updated, following this format:

```#bash
b<yyMMdd.HHmmss>
```

Examples:

* `b210717.123033`
* `b220404.221001`

# Comments

Attempts have been made to make the MAWSC sourcecode as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWSC sourcecode:

```#bash
/// XML comments used by Visual Studio
```

```#bash
// Additional code description comment
```

```#bash
/* Single-line narrative comment */
```

```#bash
/* Multiple-line  
 * narrative comment  
 */
```

# Variables

## Variable prefixes

* `sent`  
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.
* `work`  
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 
* `final`  
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

## Standard casing/trimming of values

Most logic in MAWSC is checked against lowercase values without any leading/trailing whitespace, so (in general) MAWSC will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", MAWSC will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

# Projects

Abatab consists of the following projects:

* [Abatab.csproj][SrcDocAbatab]  
The main entry point for Abatab.

* [AbatabSession.csproj][SrcDocAbatabSession]  
Logic for Abatab sessions.

# Additional reading

There is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](https://github.com/myAvatar-Development-Community/).

<br>

***

> [Abatab][AbatabRepoUrl] &gt; **Source code documentation**

<!-- REFERENCE LINKS -->
[AbatabRepoUrl]: https://github.com/spectrum-health-systems/Abatab
[SrcDocPng]: ./res/img/SrcDocPng.png
[SrcDocHome]: /doc/srcdoc/SrcDocHome.md
[SrcDocAbatab]: /doc/srcdoc/SrcDocAbatab.md
[SrcDocAbatabSession]: /doc/srcdoc/SrcDocAbatabSession.md
