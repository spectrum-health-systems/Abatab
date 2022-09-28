> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **Abatab.csproj**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h2>
    Abatab.csproj<br>
    <b>v0.6.0</b>
  </h2>

</div>

***

## Content
### Abatab.cs<br>
[Abatab.GetVersion()](#abatabgetversion)<br>
[Abatab.RunScript()](#abatabrunscript)<br>

***

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

1. **Build a new `abatabSession` object**  
The `abatabSession` object contains all of the settings and data Abatab needs to do it's job.

2. **Process the Abatab request**  
Where the request is sent depends on which [AbatabMode][ManConfigure] is active.

3. **Return an OptionObject2015 object to myAvatar**  
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
