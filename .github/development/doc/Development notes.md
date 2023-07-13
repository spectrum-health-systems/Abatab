# Development notes

>This is a collection of Abatab development notes.

***

<br>

# Script Parameters

## Syntax

The Script Parameter sent from Avatar contains all of the information Abatab needs to do what it needs to do, including:

* The `Module` component
* The `Command` component
* The `Action` component
* The `Option` component

Script Parameters have the following syntax:

    `Module-Command-Action-Option`

For example:

    `ProgNote-VfyLoc-IndiCounselingNote`

The maximum length of a script parameter is 48 characters.

* The `MODULE` component is 8 characters, or less
* The `COMMAND` component is 12 characters, or less (see below)
* The `ACTION` component is 16 characters, or less
* The `OPTION` component is 2 characters, or less

```
12345678-123456789012-1234567890123456-12
MODULE__-COMMAND_____-ACTION__________-OP
```


The `COMMAND` can consist of a *command prefix*, which is 3 characters, leaving 9 characters for the rest of the command.

```
123
   123456789
PreCommand__
```

## Scr

`Testing-DataDump-SessionInformation`  
`Testing-ErrorCode-ErrorCode1`  

### PROGRESSNOTE
`MODULE__-COMMAND_____-ACTION__________-OP`
`ProgNote-VfyLoc-IndiCounselingNote`  
`ProgNote-VfyLoc-GroupIndiNote`

### QUICKMEDICATIONORDER
`QMedOrdr-vfyAmount-Dose`


## Abbreviations

### Module

Module abbreviations are 8 characters.

* ProgNote = Progress Note
* Proto    = Prototype
* QMedOrdr = Quick Medication Order
* Testing  = Testing

### Keywords

Keyword abbreviations are 4 characters.

* Vfy  = Verify  

### Other abbreviations

* Loc  = Location
* Indi = Individual/Individualized
* Inde = Independent



# Flowchart colors

`F94144`: Abatab  
`277DA1`: Core.Catalog, Module.ProgressNote  
`F3722C`: Core.DataExport, Module.Prototype  
`577590`: Core.Framework, Module.QuickMedicationOrder  
`F8961E`: Core.Logger, Module.Testing
`4D908E`: Core.Session  
`F9844A`: Core.Utilities  
`43AA8B`: ScriptLinkStandard  
`F9C74F`:  
`90BE6D`:  


# New deployment

See "Abatab Lieutenant" for more info



# Comments

## Types of comments

`// Documentation`  
`/* Narrative */`  
`/// XML`

## Better Comments

Abatab uses the [Better Comments VS2022](https://marketplace.visualstudio.com/items?itemName=OmarRwemi.BetterCommentsVS2022) extension.

### Developer notes

Developer notes are contained in `/* DEVELOPER_NOTE */`

Example:

```csharp
/* DEVELOPER_NOTE
 * This is an example of a developer note.
 * More info.
 * Even more info
 */
```

### Questions

Questions are contained in `/* QUESTION */`

Example:

```csharp
/* QUESTION
 * This is a question
 */
```

### TODO

Todos are contained in `/* TODO */`

```csharp
/* TODO
 * Refactor this thing.
 * GitHub issue #123
 */
```

# Headers

## Source code header

Each source code file has the following header, defined in the .editorconfig `file_header_template`

```csharp
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
```
## Class header

```csharp
// -----------------------------------------------------------------------------
// Abatab.asmx.cs
// Entry point for Abatab.
// b230713.1524
// -----------------------------------------------------------------------------
```












/// <summary>
/// Class summary goes here.
/// </summary>

/// <summary>
/// Method summary goes here.
/// </summary>

/// <summary>
/// Executing assembly name for log files.
/// </summary>
/// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>



`/* *****************************************************************************`

`/* =============================================================================`

`/* -----------------------------------------------------------------------------`

 * Abatab v23.7.0.0
 * A custom web service/framework for Netsmart's myAvatar EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * -----------------------------------------------------------------------------
 * Developed by A Pretty Cool Program (https://github.com/APrettyCoolProgram)
 * Apache 2.0 (https://www.apache.org/licenses/LICENSE-2.0.html)
 * #############################################################################