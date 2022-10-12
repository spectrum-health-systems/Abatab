> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **AbatabLogging.csproj**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h2>
    AbatabLogging.csproj<br>
    <b>v0.90.0</b>
  </h2>

</div>

***
## Content

### BuildContent.cs<br>

[BuildContent.LogTextWithTrace()](#buildcontentlogtextwithtrace)<br>
[BuildContent.LogTextWithoutTrace](#buildcontentlogtextwithouttrace)<br>
[BuildContent.LogHeader](#buildcontentlogheader)<br>
[BuildContent.LogDetailsWithTrace](#buildcontentlogdetailswithtrace)<br>
[BuildContent.LogDetailsWithoutTrace](#buildcontentlogdetailswithouttrace)<br>
[BuildContent.LogBody](#buildcontentlogbody)<br>
[BuildContent.BodyAllOptObjInformation](#buildcontentbodyalloptobjinformation)<br>
[BuildContent.BodyOptObjInformation](#buildcontentbodyoptobjinformation)<br>
[BuildContent.BodySessionInformation](#buildcontentsessioninformation)<br>
[BuildContent.LogFooter()](#buildcontentlogfooter)<br>

### LogEvent.cs<br>

[LogEvent.AllOptionObjectInformation()](#logeventalloptionobjectinformation)<br>
[LogEvent.SessionData()](#logeventsessiondata)<br>
[LogEvent.Trace()](#logeventtrace)<br>

***

# BuildContent.LogTextWithTrace()

Build the logfile content with trace information.

## Operation

1. **Build the log header**  

2. **Build the log details**  

3. **Build the log body**

4. **Build the log footer**

5. **Return the completed log content**

## Notes

* None

> [Back to top](#content)

# BuildContent.LogTextWithoutTrace()

Build the logfile content without trace information.

## Operation

1. **Build the log header**  

2. **Build the log details**  

3. **Build the log body**

4. **Build the log footer**

5. **Return the completed log content**

## Notes

* None

> [Back to top](#content)

# BuildContent.LogHeader()

Build the logfile content header.

## Operation

1. **Build the log header**  

2. **Return the completed log header**

## Notes

* None

> [Back to top](#content)

# BuildContent.LogDetailsWithTrace()

Build standard log details with trace information.

## Operation

1. **Build the log details**  

2. **Return the completed log details**

## Notes

* None

> [Back to top](#content)

# BuildContent.LogDetailsWithoutTrace()

Build standard log details without trace information.

## Operation

1. **Build the log details**  

2. **Return the completed log details**

## Notes

* None

> [Back to top](#content)

# BuildContent.LogBody()

Build standard log body for different log events.

## Operation

1. **Build the logfile body for each type of event**  

2. **Return the completed log body**

## Notes

* None

> [Back to top](#content)

# BuildContent.BodyAllOptObjInformation()

Build information for all OptionObject types.

## Operation

1. **Build the logfile body for all types of OptionObject**  

2. **Return the completed log body**

## Notes

* None

> [Back to top](#content)

# BuildContent.BodyOptObjInformation()

Build information for a specific OptionObject type.

## Operation

1. **Build the logfile body for a specific type of OptionObject**  

2. **Return the completed log body**

## Notes

* None

> [Back to top](#content)


# BuildContent.SessionInformation()

Build standard session information log body.

## Operation

1. **Build the logfile body for session information**  

2. **Return the completed log body**

## Notes

* None

> [Back to top](#content)

# BuildContent.LogFooter()

Build the logfile content footer.

## Operation

1. **Build the log footer**  

2. **Return the completed log footer**

## Notes

* None

> [Back to top](#content)

# LogEvent.AllOptionObjectInformation()

Build a OptionObject information log.

## Operation

1. **Build logs for each OptionObject**

## Notes

* None

> [Back to top](#content)

# LogEvent.SessionData()

Build a session information log.

## Operation

1. **Build a session data log**

## Notes

* None

> [Back to top](#content)

# LogEvent.Trace()

Build a trace log.

## Operation

1. **Build a trace log**

## Notes

* Basic troubleshooting, these are all over the place.

> [Back to top](#content)

<br>

***

<br>

> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **AbatabLogging.csproj**

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