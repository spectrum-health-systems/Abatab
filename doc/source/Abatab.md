> [Abatab][AbatabRepositoryUrl] &gt; [Sourcecode][AbatabSourcecodeDocumentation] &gt; **Abatab.csproj**

<br>

<div align="center">

  <!-- PROJECT LOGO
      - Project logo should be located at "./.github/Logos/ProjectLogo.png".
      - Short description of the project.
  -->

  ![SourceCodeDocumentationLogo][SourceCodeDocumentationLogo]

  <h1>
    Abatab.csproj
  </h1>

  **v0.5.0 - Last updated 9/27/22**

</div>

The Abatab project is the entry point for Abatab. When you make a Abatab request via a ScriptLink event, this is where that request ends up.

As it is mostly a "clearing house" for Abatab requests, this namespace should only contain the required classes/methods that Abatab needs to function. In addition, it is designed to be fairly generic - most of the heavy-lifting is done by external namespaces/classes/methods. This way the required functionality rarely changes, and ScriptLink will have a known, stable target.

***

### Classes
* [Abatab.asmx.cs](#abatabasmxcs)  
Main Abatab class that contains the required methods that Abatab needs to function.

***

# Abatab.asmx.cs

## `GetVersion()`

Returns the Abatab version.

### Operation

1. **Return the current version of Abatab**  
The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return `VERSION 2.0`.

### Notes

* The `GetVersion()` method is required by myAvatar™.
* You can find more information about the `GetVersion()` method [here][GetVersionMethodDocumenation].

***

## `RunScript()`

Execute a Abatab Request.

### Operation

1. **Create a SessionData object with everything we need**  
The SessionData object contains:
    * Configuration settings from the local web.config file
    * Settings created at runtime
    * Necessary OptionObjects

2. **Process the Abatab Request**  
The AbatabMode can be one of the following:
    * `enabled`  
    This is the default setting, which processes Abatab requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    * `disabled`  
    Skip all Abatab functionality. Essentially Abatab will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call Abatab, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    * `passthrough`  
    Use Abatab, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since Abatab will actually go through the motions and write logs normally.


3. **Return an OptionObject2015 object to myAvatar**  
The returned OptionObject2015 may - or may not - be modified, depending on the AbatabMode and/or the Abatab Request.

### Notes

* The `RunScript()` method is required by myAvatar™.
* You can find more information about the `RunScript()` method [here][RunScriptMethodDocumentation].

<br>

***

> [Abatab][AbatabRepositoryUrl] &gt; [Sourcecode][AbatabSourcecodeDocumentation] &gt; **Abatab.csproj**


<!-- REFERENCE LINKS -->

[AbatabRepositoryUrl]: https://github.com/spectrum-health-systems/Abatab
[AbatabSourcecodeDocumentation]: Sourcecode.md
[SourceCodeDocumentationLogo]: ./Images/SourceCodeDocumentationLogo.png
[GetVersionMethodDocumenation]: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method
[RunScriptMethodDocumentation]: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method
