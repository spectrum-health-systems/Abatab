<div align="center">

  <img src="../../images/man-logo.png" alt="Abatab Manual" width="512">

  <h4>
    Abatab v22.11.0
  </h4>

</div>

***

# About the Abatab source code

Detailed documentation found here:

# Versioning

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

# Headers

Every class has a standard header:

```#bash
// Abatab X.Y.Z
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// bYYMMDD.HHMMSS
```

# Comments

Attempts have been made to make the Abatab source code as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWSC sourcecode:

### XML comments

XML comments are used by DocFx to create the source code documentation.

```#bash
/// <summary>
/// The main Abatab project, and where the magic starts.
/// </summary>
```

### Developer comments

```#bash
// Comments starting with `"//"` are developer comments that are intended to provide important information about source code that may not be clear. Developer comments should not be removed.
```

### Narrative comments

```#bash
/* Comments that start with `"/*"` and end with `"*/"` are narrative comments that provide additional details about source code that may be interesting to the reader, and may be removed. */
```

```#bash
/* Narrative comments can 
 * also be
 * multi-line. 
 */
```

# Variables

## Prefixes

* `sent`  
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.
* `work`  
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 
* `final`  
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

## Casing and trimming

Most logic in Abatab is checked against lowercase values without any leading/trailing whitespace, so (in general) Abatab will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_ AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", Abayab will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

## Multiple values

Multiple values are stored in strings, with each value seperated by a `-`" character. For example, the following values:

```#bash
Apple  
Pear
Orange
```

would apprear as:

`Apple-Pear-Orange`

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
