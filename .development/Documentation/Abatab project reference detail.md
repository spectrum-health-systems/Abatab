<div align="center">

![Logo][Logo]

# PROJECT REFERENCE

<h3>
  Last updated December 12, 2022
</h3>

</div>


























***

# Abatab project reference detail

* `X`: Would result in a circular reference
* `**REF**` This project is referenced
* `NoRef` This project is not currently referenced
* `*Dep*` This project is depreciated

|             PROJECT            | Abatab | AbatabData | AbatabLogging | AbatabOptionObject | AbatabRoundhouse | AbatabSession | AbatabSettings | AbatabSystem | ModCommon | ModPrototype | ModQuickMedOrder | ModTesting |   Du  | NTST.ScriptLinkService.Objects |
| ------------------------------:|:------:|:----------:|:-------------:|:------------------:|:----------------:|:-------------:|:--------------:|:------------:|:---------:|:------------:|:----------------:|:----------:|:-----:|:------------------------------:|
|                         Abatab |    X   |   **REF**  |    **REF**    |       **REF**      |       _Dep_      |    **REF**    |      _Dep_     |     NoRef    |  **REF**  |    **REF**   |      **REF**     |   **REF**  | NoRef |             **REF**            |
|                     AbatabData |  NoRef |      X     |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |             **REF**            |
|                  AbatabLogging |  NoRef |   **REF**  |       X       |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |    **REF**   |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |             **REF**            |
|             AbatabOptionObject |  NoRef |   **REF**  |    **REF**    |          X         |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |             **REF**            |
|               AbatabRoundhouse |  NoRef |    NoRef   |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |              NoRef             |
|                  AbatabSession |  NoRef |   **REF**  |    **REF**    |       **REF**      |       _Dep_      |       X       |      _Dep_     |    **REF**   |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |             **REF**            |
|                 AbatabSettings |  NoRef |    NoRef   |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |        X       |     NoRef    |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |              NoRef             |
|                   AbatabSystem |  NoRef |    NoRef   |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |       X      |   NoRef   |     NoRef    |       NoRef      |    NoRef   | NoRef |              NoRef             |
|                      ModCommon |  NoRef |    NoRef   |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |     X     |     NoRef    |       NoRef      |    NoRef   | NoRef |              NoRef             |
|                   ModPrototype |  NoRef |   **REF**  |    **REF**    |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |       X      |       NoRef      |    NoRef   | NoRef |              NoRef             |
|               ModQuickMedOrder |  NoRef |   **REF**  |    **REF**    |       **REF**      |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |  **REF**  |     NoRef    |         X        |    NoRef   | NoRef |             **REF**            |
|                     ModTesting |  NoRef |   **REF**  |    **REF**    |       **REF**      |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |     NoRef    |       NoRef      |      X     | NoRef |              NoRef             |
|                             Du |  NoRef |    NoRef   |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |     NoRef    |       NoRef      |    NoRef   |   X   |              NoRef             |
| NTST.ScriptLinkService.Objects |  NoRef |    NoRef   |     NoRef     |        NoRef       |       _Dep_      |     NoRef     |      _Dep_     |     NoRef    |   NoRef   |     NoRef    |       NoRef      |    NoRef   |       |                X               |

[Logo]: ../../resources/images/logos/AbatabLogo.png