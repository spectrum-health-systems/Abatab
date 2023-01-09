> [Abatab][AbatabRepoUrl] &gt; **Source code documentation**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h1>
    Abatab<br>
    <b>v0.92.0</b>
  </h1>

</div>

# About

I would like to keep the Abatab source code pretty clean, so this documentation will provide details of what everthing does.

<br>

# Sourcecode headers

Every class has a standard header:

```#bash
/* Abatab.AbatabSettings.cs 0.92.0+221011.093856
 * https://github.com/spectrum-health-systems/Abatab
 * (c)2016-2022 A Pretty Cool Program
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocHome.md
 */
```

## Versions

[Semantic versioning](https://semver.org/) is used to indicate the current version of Abatab components.

`<X>.<Y>.<Z>-<build type>+<yyMMdd.HHmmss>`

Where:
* **`<X>`** is a the major version
* **`<Y>`** is a the minor version
* **`<Z>`** is a the patch version
* **`<build type>`** is a the (optional) release build type
* **`<yyMMdd.HHmmss>`** is a the date/timestamp of the release (using 24-hour time)

Examples:

* v1.0.0+210717.123033
* v1.1.1-rc.1+210717.123033
* v2.0.0-devbuild+210717.123033

<br>

# Comments

Attempts have been made to make the Abatab source code as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

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
 * narrative
 * comment  
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

Most logic in Abatab is checked against lowercase values without any leading/trailing whitespace, so (in general) Abatab will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_ AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", Abayab will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

## Multiple value strings

Multiple values are stored in strings, with each value seperated by a `-`" character. For example, the following values:

```#bash
Apple  
Pear
Orange
```

would apprear as:

`Apple-Pear-Orange`

# Projects and Modules

Abatab is comprised of Abatab *projects*, and Abatab *modules*.

## Projects

Abatab projects make up the core functionality of Abatab, and most likely won't change that often.

* [Abatab.csproj][SrcDocAbatab]  
The main entry point for Abatab.

* [AbatabData.csproj][SrcDocAbatabData]  
TBD

* [AbatabLogging.csproj][SrcDocAbatabLogging]  
TBD

* [AbatabOptionObject.csproj][SrcDocAbatabOptionObject]  
TBD

* [AbatabSession.csproj][SrcDocAbatabSession]  
Logic for Abatab sessions.

* [AbatabSystem.csproj][SrcDocAbatabSystem]  
TBD

## Modules

Abatab modules make up the extended functionality of Abatab.

* [Module: Common][SrcDocModCommon]  
TBD

* [Module: Prototype][SrcDocModPrototype]  
TBD

* [Module: QuickMedOrder][SrcDocModQuickMedOrder]  
TBD

* [Module: Testing][SrcDocModTesting]  
TBD

<br>

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
[SrcDocAbatabData]: /doc/srcdoc/SrcDocAbatabData.md
[SrcDocAbatabLogging]: /doc/srcdoc/SrcDocAbatabLogging.md
[SrcDocAbatabOptionObject]: /doc/srcdoc/SrcDocAbatabOptionObject.md
[SrcDocAbatabSession]: /doc/srcdoc/SrcDocAbatabSession.md
[SrcDocAbatabSystem]: /doc/srcdoc/SrcDocAbatabSystem.md
[SrcDocModCommon]: /doc/srcdoc/SrcDocModCommon.md
[SrcDocModPrototype]: /doc/srcdoc/SrcDocModPrototype.md
[SrcDocModQuickMedOrder]: /doc/srcdoc/SrcDocModQuickMedOrder.md
[SrcDocModTesting]: /doc/srcdoc/SrcDocModTesting.md