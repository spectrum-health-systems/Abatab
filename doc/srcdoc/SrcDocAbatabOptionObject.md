> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **AbatabOptionObject.csproj**

<br>

<div align="center">

  ![SrcDocPng][SrcDocPng]

  <h2>
    AbatabOptionObject.csproj<br>
    <b>v0.6.0</b>
  </h2>

</div>

***
## Content
### Finalize.cs<br>
[Finalize.ForPassthrough()](#finalizeforpassthrough)<br>
### Verify.cs<br>
[Verify.NotModified()](#verifynotmodified)<br>

***

# Finalize.ForPassthrough()

Finalizes an OptionObject for passthrough mode.

## Operation

1. **Set the ErrorCode**  
ErrorCode 0 is the default error code.

2. **Set the ErrorMesg**  
This is decriptive so it's easy to tell we are in passthrough mode.

## Notes

* None

> [Back to top](#content)

# Verify.NotModified()

Verify that the sentOptObj has not been modified.

## Operation

1. **Verify that the `sentOptObj` matches the `alternateOptObj`**

2. **Return the result**  
If the two OptionObjects match, return true. Otherwise, return false.

## Notes

* None

> [Back to top](#content)

<br>

***

<br>

> [Abatab][AbatabRepoUrl] &gt; [Source code documentation][SrcDocHome] &gt; **AbatabOptionObject.csproj**

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