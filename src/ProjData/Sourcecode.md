<br>
<div align="center">

  <!-- PROJECT LOGO
      - Project logo should be located at "./.github/Logos/ProjectLogo.png".
      - Short description of the project.
  -->

  ![SourceCodeDocumentationLogo][SourceCodeDocumentationLogo]

  <h2>

  Home&nbsp;&bull;&nbsp;[Getting started][MANUAL-GETTING-STARTED]&nbsp;&bull;&nbsp;[Hosting][MANUAL-HOSTING]&nbsp;&bull;&nbsp;[Importing][MANUAL-IMPORTING]&nbsp;&bull;&nbsp;[Using][MANUAL-USING]&nbsp;&bull;&nbsp;[ScriptLink][MANUAL-SCRIPTLINK]&nbsp;&bull;&nbsp;[Additional information][MANUAL-ADDITIONAL-INFORMATION]

  </h2>
</div>

# Namespace

The Abatab namespace is the entry point for Abatab. When you make a Abatab request via a ScriptLink event, this is where that request ends up.

As it is mostly a "clearing house" for Abatab requests, this namespace should only contain the required classes/methods that Abatab needs to function. In addition, it is designed to be fairly generic - most of the heavy-lifting is done by external namespaces/classes/methods. This way the required functionality rarely changes, and ScriptLink will have a known, stable target.

# Classes

## AbatabC.asmx.cs

> Important!  
Please note that both the `GetVersion()` and `RunScript()` methods are required by myAvatar™, and Abatab (or any web service that myAvatar references) cannot function without them.

<br>

***

## `GetVersion()`

Returns the Abatab version.

### Operation

Uh, not much to say here. This method is pretty simple.

### Notes

* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return `VERSION 2.0`.
* You can find more information about the `GetVersion()` method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method).

### Warnings

* This method is required by myAvatar.

***

## `RunScript()`

Execute a Abatab Request.

## Operation

1. **Create a SessionData object with everything we need**
The SessionData object contains:
    * Configuration settings from the local web.config file
    * Settings created at runtime
    * Necessary OptionObjects
<br>

2. **Process the Abatab Request**  
* **\[4]** The AbatabMode can be one of the following:
    * `enabled`  
    This is the default setting, which processes Abatab requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    * `disabled`  
    Skip all Abatab functionality. Essentially Abatab will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call Abatab, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    * `passthrough`  
    Use Abatab, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since Abatab will actually go through the motions and write logs normally.


3. **Return an OptionObject2015 object to myAvatar**  
The returned OptionObject2015 may - or may not - be modified, depending on the AbatabMode and/or the Abatab Request.

### Notes

* There is a commented line is at the start of the method that enables troubleshooting logs. This line should remain commented in production.
* You can find more information about the `RunScript()` method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method).
* **\[1]** We need to get the configuration settings in the external `Web.config` file at the beginning, then build the rest of the setting values that will stay in `AbatabSettings`.
* **\[2]** You can read more about why we create these values in this way [here][4].
* **\[4]** The AbatabMode can be one of the following:
    - `enabled`  
    This is the default setting, which processes Abatab requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    - `disabled`  
    Skip all Abatab functionality. Essentially Abatab will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call Abatab, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    - `passthrough`  
    Use Abatab, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since Abatab will actually go through the motions and write logs normally.


### Warnings

* This method is required by myAvatar.

<!-- REFERENCE LINKS -->

[SourceCodeDocumentationLogo]: ./Images/ManualLogo.png