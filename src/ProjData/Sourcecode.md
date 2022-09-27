# Abatab project sourcecode documentation

## Namespace

The Abatab namespace is the entry point for Abatab. When you make a Abatab request via a ScriptLink event, this is where that request ends up.

As it is mostly a "clearing house" for Abatab requests, this namespace should only contain the required classes/methods that Abatab needs to function. In addition, it is designed to be fairly generic - most of the heavy-lifting is done by external namespaces/classes/methods. This way the required functionality rarely changes, and ScriptLink will have a known, stable target.

## Classes

This namespace has a single class that contains a two methods that are required by myAvatar.

<details>
<summary>
  <b>AbatabC.asmx.cs</b><br>
  &nbsp;&nbsp;&nbsp;&nbsp;Methods required by myAvatar
</summary>
<br

> Important!  
Please note that both the `GetVersion()` and `RunScript()` methods are required by myAvatar™, and Abatab (or any web service that myAvatar references) cannot function without them.

***

### `GetVersion()`

Returns the Abatab version.

#### Operation

Uh, not much to say here. This method is pretty simple.

#### Notes

* This method is required by myAvatar.
* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return `VERSION 2.0`.
* You can find more information about the `GetVersion()` method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method).

***

### `RunScript()`

Execute a Abatab Request.

#### Operation

1. Load configuration settings and create the necessary OptionObjects.
2. Process the Abatab Request
3. Return an OptionObject2015 object to myAvatar.

#### Notes

* This method is required by myAvatar.
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
* **\[6]** The returned OptionObject2015 may - or may not - be modified, depending on the AbatabMode and/or the Abatab Request.

</details>