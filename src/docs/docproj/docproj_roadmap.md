# Abatab Roadmap

## Refactors

### **Abatab.asmx**.RunScript()

Consider creating the AbSession object in the if...then statement, and just returning an OptionObject.

```csharp
[WebMethod]
public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
{
    Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);
 
    var returnOptionObject = new OptionObject();

    if (Settings.Default.AbatabMode == "enabled")
    {
        AbSession abSession = new AbSession();

        Flightpath.InitializeAbatab(abSession, scriptParameter, sentOptionObject);
        Roundhouse.ParseModule(abSession);
        Flightpath.WrapUpAbatab(abSession);

        returnOptionObject = abSession.ReturnOptionObject // And whatever needs to be done to complete this.
    }
    else
    {
        Debuggler.PrimevalLog("disabled");

        returnOptionObject = abSession.ReturnOptionObject // And whatever needs to be done to complete this.
    }

    return returnOptionObject;
}
```
