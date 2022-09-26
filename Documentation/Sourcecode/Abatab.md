# Abatab.csproj

Primarily focuses on the processing the initial ScriptLink call from myAvatar™. This class should remain fairly static and rely external source code to do the heavy lifting.

The Abatab.csproj version number increments with the Abatab application version number.

## Abatab.asmx.cs

## GetVersion()

This method is required by myAvatar™, so don't remove it. During development, the "VERSION" number will always be whatever the development branch is targeting. For example, while developing v1.1, this method will return "VERSION 1.1".

## RunScript(OptionObject2015 sentOptionObject, string abatabRequest)

This method is required by myAvatar™, so don't remove it. In addition, since most of the heavy lifting is done by external projects/classes, this method should remain fairly static.

1. Create and `abatabSession` object that contains all of the information that Abatab needs to do its job. This is the "one source of truth", and will be referenced/modified by other Abatab components.

2. Depending on the `AbatabMode`, do something.

* If `AbatabMode` is set to `enabled`, call...
* If `AbatabMode` is set to `disabled`, call...
* If `AbatabMode` is set to `passthrough`, call...

If `AbatabMode` doesn't match any of the above, gracefully exit.

3. Return the finalized OptionObject2015 to myAvatar™.