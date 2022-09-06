<!-- A generic README template for a GitHub repository [b220906]
-->

<!-- README HEADER
     - Everything that should be centered and at the top of the README should be inside these <div> tags.
-->
<div align="center">

  <!-- BRANCH WARNINGS
       Syntax: ![BRANCH-WARNING][%branch-warning%]

               Replace %branch-warning% with one of the following:
               - [BRANCH-ALPHA]
               - [BRANCH-BETA]

       This component:
       - Is optional.
       - Lets the reader know this is a non-stable branch.
       - Should not be used in production.
  -->
  ![REPOSITORY-WARNING][BRANCH-BETA]
  
  ***

  <!-- REPOSITORY LOGO
      - The repository logo should be located at "./.github/Logos/RepositoryLogo.png".
  -->
  [![REPOSITORY-LOGO][REPOSITORY-LOGO]][CURRENT-BRANCH-URL]

  <!-- SHORT DESCRIPTION OF REPOSITORY
      - A short, one-line description of the project.
      - By default this uses H1, but you can use H2 if you need more space.
  -->
  # A custom web service for Netsmart's myAvatar™ EHR

  <!-- REPOSITORY BADGE
       Syntax: ![REPOSITORY-STATUS][%repository-status%]

               Replace %repository-status% with one of the following:
               - [STATUS-ACTIVE]
               - [STATUS-DEPRECIATED]
               - [STATUS-ARCHIVED]
  -->
  ![REPOSITORY-STATUS][STATUS-ACTIVE]&nbsp;&nbsp;[![REPOSITORY-LICENSE][REPOSITORY-LICENSE]][REPOSITORY-LICENSE-URL]&nbsp;&nbsp;[![CURRENT-RELEASE][CURRENT-RELEASE]][CURRENT-RELEASE-URL]

  <!-- REPOSITORY PRIMARY MENU
       - Links to:
          - Repository changelog
          - Repository roadmap
          - Repository manual
          - Repository sourcecode documentation
  -->
  ***
  ### [Changelog][CHANGELOG]&nbsp;&bull;&nbsp;[Roadmap][ROADMAP]&nbsp;&bull;&nbsp;[Manual][MANUAL]&nbsp;&bull;&nbsp;[Sourcecode documentation][SOURCECODE-DOCUMENTATION]
  ***

<table align="left">
    <thead>
        <tr>
            <th>CONTENTS</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>About</td>
        </tr>
        <tr>
            <td>Getting started</td>
        </tr>
    </tbody>
</table>


</div>

<!--  ABOUT
-->
# About Abatab

[Netsmart's myAvatar™][MYAVATAR] is a behavioral health EHR that offers a recovery-focused suite of solutions that leverage real-time analytics and clinical decision support to drive value-based care.

While myAvatar™ is a robust platform, like most things in life (except [Heroes of Might and Magic III][HOMM3]), it isn't perfect.

The good news is that you can extend myAvatar™ functionality via Netsmart's myAvatar™ Web Services, and/or custom web services that are written by other myAvatar™ users.

**Abatab** is one such custom web service which includes various tools and utilities for myAvatar™ that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

<!-- FEATURES
-->
## Features

* Several built-in tools and utilities for use with myAvatar™
* Does not require Java to be installed
* A solid foundation to build additional myAvatar™ custom tools and utilities

<!--  PREREQUISITES
-->
## Prerequisites

* A location to host the Abatab which meets the following requirements:
  * .NET Framework 4.8+ installed
  * Access to your myAvatar™ environments via HTTPS

# The Abatab Manual

This README is short and sweet because the [Abatab Manual][MANUAL], which is updated with each release, contains everything you need to know about Abatab.

<!-- REFERENCE LINKS -->

<!-- REPOSITORY -->
[REPOSITORY-URL]: https://github.com/spectrum-health-systems/Abatab
[CURRENT-BRANCH-URL]: README.md

<!-- BRANCH WARNINGS -->
[BRANCH-ALPHA]: https://img.shields.io/badge/WARNING-THIS%20IS%20ALPHA%20SOFTWARE-FF160C?style=for-the-badge
[BRANCH-BETA]: https://img.shields.io/badge/WARNING-THIS%20IS%20BETA%20SOFTWARE-FF160C?style=for-the-badge

<!-- REPOSITORY LOGO -->
[REPOSITORY-LOGO]: ./.github/Logos/RepositoryLogo.png

<!-- REPOSITORY STATUS -->
[STATUS-ACTIVE]: https://img.shields.io/badge/status-active-brightgreen?style=flat-square
[STATUS-DEPRECIATED]: https://img.shields.io/badge/status-depreciated-red?style=flat-square
[STATUS-ARCHIVED]: https://img.shields.io/badge/status-archived-yellow?style=flat-square

<!-- REPOSITORY LICENSE -->
[REPOSITORY-LICENSE]: https://img.shields.io/github/license/spectrum-health-systems/Abatab?style=flat-square
[REPOSITORY-LICENSE-URL]: https://www.apache.org/licenses/LICENSE-2.0

<!-- CURRENT RELEASE -->
[CURRENT-RELEASE]: https://img.shields.io/github/v/release/spectrum-health-systems/Abatab?style=flat-square
[CURRENT-RELEASE-URL]: https://github.com/spectrum-health-systems/Abatab/releases






<!-- README
     - Available to the repository README.
-->
[README-SCREENSHOT]: ./.github/Screenshots/ReadmeScreenshot.png





<!-- REFERENCE LINKS: REPOSITORY DOCUMENTATION
     These reference links should be standard across all project documentation.
-->
[MANUAL]: ./Documentation/Manual/Manual.md
[SOURCECODE-DOCUMENTATION]: ./Documentation/Sourcecode/Sourcecode.md
[CHANGELOG]: ./Documentation/CHANGELOG.md
[ROADMAP]: ./Documentation/ROADMAP.md
[AUTHORS]: ./.github/Documentation/Repository/AUTHORS.md
[BUILT-WITH]: ./.github/Documentation/Repository/BUILT-WITH.md
[CODE-OF-CONDUCT]: ./.github/Documentation/Repository/CODE-OF-CONDUCT.md
[CONTRIBUTING-GUIDELINES]: ./.github/Documentation/Repository/CONTRIBUTING.md
[SECURITY]: ./.github/Documentation/Repository/SECURITY.md
[SUPPORT]: ./.github/Documentation/Repository/SUPPORT.md



[CONTINUED-DEVELOPMENT]: https://github.com/spectrum-health-systems/Abatab

<!-- REFERENCE LINKS: DOCUMENT SPECIFIC
     These reference links should be standard across all project documentation.
-->
[MYAVATAR]: https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar
[HOMM3]: https://www.gog.com/game/heroes_of_might_and_magic_3_complete_edition


<br>

<!-- FOOTER
-->
***

<br>
<div align="center">

  <!-- PROJECT BADGES
       - Project badges that give the following mostly static information:
          - The project issues
          - The project pull requests
  -->
  [![Issues](https://img.shields.io/github/issues/spectrum-health-systems/MAWSC?style=flat)](https://github.com/spectrum-health-systems/MAWSC/issues)&nbsp;
  [![Pulls](https://img.shields.io/github/issues-pr/spectrum-health-systems/MAWSC?style=flat)](https://github.com/spectrum-health-systems/MAWSC/pulls)

</div>