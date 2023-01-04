> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **Abatab.csproj**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h2>
    Abatab.csproj<br>
    <b>v0.92.0</b>
  </h2>

</div>

***

## Content
[Abatab settings file](#abatab-settings-file)
### Abatab.cs<br>
[Abatab.GetVersion()](#abatabgetversion)<br>
[Abatab.RunScript()](#abatabrunscript)<br>
### AbatabSettings.cs<br>
[AbatabSettings.Build()]()<br>
[AbatabSettings.LoadWebConfig()]()<br>
### Roundhouse.cs<br>
[Roundhouse.ParseRequest()]()<br>

***

<br>

# Abatab settings file

The Abatab Settings.settings file contains the following settings:

* **AbatabMode**  
  - `disabled`  
  Abatab does nothing
  - `enabled`  
  Abatab executes and functions normally
  - `passthrough`  
  Abatab write logfiles

* **AbatabRoot**  
  The Abatab root directory (e.g., `C:\WebServerFiles\Abatab_UAT`  )


<br>

# Abatab.GetVersion()

Returns the Abatab version.

## Operation

1. **Return the current version of Abatab**  

## Notes

* The `GetVersion()` method is required by myAvatar™.
* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return *"VERSION 2.0"*.
* You can find more information about the `GetVersion()` method [here][GetVersionMethodDocumentation].

> [Back to top](#content)

# Abatab.RunScript()

Execute a Abatab Request.

## Operation

1. **Write a debug logfile**  
If `DebugMode` is set to `on`, a logfile will be written indicating that Abatab was started.

2. **Build a new `abatabSession` object**  
The `abatabSession` object contains all of the settings and data Abatab needs to do it's job.

3. **Process the Abatab request**  
Where the request is sent depends on what the request is.

4. **Return an OptionObject2015 object to myAvatar**  
The returned OptionObject2015 may - *or may not* - be modified, depending on the AbatabMode and/or the Abatab request.

## Notes

* The `RunScript()` method is required by myAvatar™.
* This method is the entry point for Abatab. When you make a Abatab request via a ScriptLink event, this is where that request ends up. It is designed to be fairly generic, since most of the heavy-lifting is done by external namespaces/classes/methods. This way the required functionality rarely changes, and ScriptLink will have a known, stable target.  
* You can find more information about the `RunScript()` method [here][RunScriptMethodDocumentation].

> [Back to top](#content)

# Roundhouse.ParseRequest()

Parse an Abatab Request.

## Operation

1. **Write a debug logfile**  
If `DebugMode` is set to `on`, a logfile will be written indicating that Abatab was started.

2. **Build a new `abatabSession` object**  
The `abatabSession` object contains all of the settings and data Abatab needs to do it's job.

3. **Process the Abatab request**  
Where the request is sent depends on what the request is.

4. **Return an OptionObject2015 object to myAvatar**  
The returned OptionObject2015 may - *or may not* - be modified, depending on the AbatabMode and/or the Abatab request.

## Notes

* The `RunScript()` method is required by myAvatar™.
* This method is the entry point for Abatab. When you make a Abatab request via a ScriptLink event, this is where that request ends up. It is designed to be fairly generic, since most of the heavy-lifting is done by external namespaces/classes/methods. This way the required functionality rarely changes, and ScriptLink will have a known, stable target.  
* You can find more information about the `RunScript()` method [here][RunScriptMethodDocumentation].

> [Back to top](#content)



<br>

***

<br>

> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **Abatab.csproj**

<!-- REFERENCE LINKS -->

[AbatabRepoUrl]: https://github.com/spectrum-health-systems/Abatab
[SrcDocPng]: ./res/img/SrcDocPng.png
[SrcDocHome]: SrcDocHome.md
[GetVersionMethodDocumentation]: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method
 <!-- Need specific link -->
[ManConfigure]: /doc/man/ManConfigure.md
[RunScriptMethodDocumentation]: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method
