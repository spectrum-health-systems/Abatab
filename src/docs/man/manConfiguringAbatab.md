<div align="center">

  <img src="../images/Logos/AbatabManualLogo.png" alt="Abatab Manual" width="512">

</div>

# Overview

The Web.config file contains the local settings for Abatab. These settings are also in Settings.settings.

# Web.config settings

Blurb here






# LogMode

**DESCRIPTION**  
Defines the Avatar environment where Abatab will be used.

**OPTIONS** 
| Value              | Description                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------|
| **`session`**      | Create session logs.                                                                               |
| `trace`            | Create trace logs.                                                                                 |
| `error`            | Create error logs.                                                                                 |
| `warning`          | Create warning logs.                                                                               |
| `all`              | Create all log types.                                                                              |
| `none`             | Do not create any log files.                                                                       |

**NOTES** 
* You can create multiple log types by separating them with a '-'.  
For example, `LogMode=error-trace` will create both error *and* trace logs.

***

# LogDetail

**DESCRIPTION**  
Defines the level of logging detail

**OPTIONS** 
| Value              | Description                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------|
| Not used yet       |                                                                                                    |

**NOTES** 
* None.

# LogWriteDelay

**DESCRIPTION**  
Sets a delay (in milliseconds) before writing a log file.

**NOTES** 
* Inserting a delay before writing a log file ensures that the timestamp in the filename is unique, and all logs are captured.
* Since this delay is applied to all log types, setting this too high will have a significant impact on performance.
* This should be left at `10`

***

***

# ModTestingMode

**DESCRIPTION**  
Indicates if the Abatab Testing Module functionality is enabled.

**OPTIONS** 
| Value              | Description                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------|
| **`enabled`**      | The Testing Module functionality is enabled.                                                       |
| `disabled`         | The Testing Module functionality is disabled.                                                      |

**NOTES** 
* The Testing Module is generally used while developing Abatab, but may have some use in production.
* There are no performance issues when the Testing Module functionality is enabled.

***

# ModQuickMedOrderMode

# ModQuickMedOrderAuthorizedUsers

# ModQuickMedOrderDosePercentBoundary

# ModQuickMedOrderDoseMilligramsBoundary

# ModPrototypeMode
