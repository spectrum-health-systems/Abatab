> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **AbatabSession.csproj**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h2>
    AbatabSession.csproj<br>
    <b>v0.6.0</b>
  </h2>

</div>

***

## Instance.cs<br>
[Instance.Build()](#instancebuild)<br>
[Instance.Initialize()](#instanceinitialize)<br>
[Instance.VerifyAvatarUserName()](#instanceverifyavatarusername)<br>

***

# Instance.Build()

Build configuration settings for an Abatab session.

## Operation

1. **Initialize a new `abatabSession` object**  
The `abatabSession` object contains all of the settings and data Abatab needs to do it's job.

2. **Verify various components of the `abatabSession` object.**  
Some components are required, or need to meet specific paramaters.

3. **Return the completed `abatabSession` object.**  

## Notes

* None

# Instance.Initialize()

Initialize the Abatab session configuration settings.

## Operation

1. **Initialize a new `abatabSession` object**  
The `abatabSession` object is a [SessionData][ManAbatabData] object that contains:
    * Settings from the local web.config file
    * Settings created at runtime
    * Necessary OptionObjects

2. **Return the `abatabSession` object**  

## Notes

* More information about the web.config settings can be found in the [Abatab Manual][ManConfigure].
* OptionObjects naming conventions can be found [here][VariablePrefixes].

# Instance.VerifyAvatarUserName()

Verify the session AvatarUserName is valid.

## Operation

1. **Check if the username is blank**  
The AvatarUserName is used to keep track of various session information, such as logs. If sentOptionObject.OptionUserId is blank, we will force it to be the AvatarFallbackUserName defined in the local configuration settings file.

2. **Return the `abatabSession` object**  

## Notes

* None

</details>

<br>

***

<br>

> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **AbatabSession.csproj**

<!-- REFERENCE LINKS -->

[AbatabRepoUrl]: https://github.com/spectrum-health-systems/Abatab
[SrcDocPng]: ./res/img/SrcDocPng.png
[SrcDocHome]: SrcDocHome.md
 <!-- Need specific link -->
[ManConfigure]: /doc/man/ManConfigure.md
 <!-- Need specific link -->
[ManAbatabData]: /doc/man/ManAbatabData.md
 <!-- Need specific link -->
[VariablePrefixes]: /doc/srcdoc/SrcDocHome.md#variable-prefixes