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
  ![REPOSITORY-LOGO][REPOSITORY-LOGO]

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
  ![REPOSITORY-STATUS][STATUS-ACTIVE]&nbsp;&nbsp;&nbsp;[![REPOSITORY-LICENSE][REPOSITORY-LICENSE]][REPOSITORY-LICENSE-URL]&nbsp;&nbsp;&nbsp;[![CURRENT-RELEASE][CURRENT-RELEASE]][CURRENT-RELEASE-URL]
  <br>
  >

  <!-- PROJECT MENU
       - The menu bar should have links to:
          - The project repository
          - The project changelog
          - The project roadmap
          - The project manual
          - The project sourcecode documentation
       - The menu bar color scheme should match the color scheme of the project.
  -->
  ***
  <br>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-FFEE00?style=for-the-badge)][REPOSITORY-URL]&nbsp;&nbsp;&nbsp;[![CHANGELOG](https://img.shields.io/badge/CHANGELOG-FF8D00?style=for-the-badge)][CHANGELOG]&nbsp;&nbsp;&nbsp;[![ROADMAP](https://img.shields.io/badge/ROADMAP-FF8D00?style=for-the-badge)][ROADMAP]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-FF8D00?style=for-the-badge)][MANUAL]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-FF8D00?style=for-the-badge)][SOURCECODE-DOCUMENTATION]
  
  <br>

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

<br>

# The Abatab Manual

This README is short and sweet because the [Abatab Manual][MANUAL], which is updated with each release, contains everything you need to know about Abatab.

<!-- REFERENCE LINKS -->

<!-- BRANCH WARNINGS -->
[BRANCH-ALPHA]: https://img.shields.io/badge/WARNING-THIS%20IS%20ALPHA%20SOFTWARE-FF160C?style=for-the-badge
[BRANCH-BETA]: https://img.shields.io/badge/WARNING-THIS%20IS%20BETA%20SOFTWARE-FF160C?style=for-the-badge

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


<!-- REPOSITORY
     - These should be vailable across all project documentation.
-->
[REPOSITORY-URL]: https://github.com/spectrum-health-systems/Abatab
[REPOSITORY-LOGO]: ./.github/Logos/RepositoryLogo.png



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