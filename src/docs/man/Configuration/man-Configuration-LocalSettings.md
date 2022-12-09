<div align="center">

  <img src="../../images/man-logo.png" alt="Abatab Manual" width="512">

  <h4>
    Abatab v23.0.0
  </h4>

</div>

***

The Web.config file contains the local settings for Abatab. These settings are also in Settings.settings.

# AbatabMode

**DESCRIPTION**  
Determines which mode Abatab is currently using.

**OPTIONS** 
| Value              | Description                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------|
| **`enabled`**      | All Abatab functionality is available.                                                             |
| `disabled`         | Abatab is disabled, and its functionality is not available.                                        |
| `passthrough`      | Abatab is enabled, and all functionality is available, but no changes are made to Avatar.          |

**NOTES** 
* None.

***

# AbatabRoot

**DESCRIPTION**  
The base Abatab root directory.

**NOTES** 
* At runtime The `AvatarEnvironment` value is added to the end of `AbatabRoot` to form the complete path.  
For example, `AbatabRoot` is "C:\Abatab_", and `AvatarEnvironment` is "LIVE", the root directory at runtime would be "C:\Abatab_LIVE".
* This should be left at `C:\Abatab_`

***

# AvatarEnvironment

**DESCRIPTION**  
Defines the Avatar environment where Abatab will be used.

**OPTIONS** 
| Value              | Description                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------|
| **`LIVE`**         | Production environment.                                                                            |
| `UAT`              | Testing environment.                                                                               |
| `SBOX`             | Sandbox environment.                                                                               |

**NOTES** 
* None.

***

# DebugMode

**DESCRIPTION**  
Indicates if Abatab is in debugging mode.

**OPTIONS** 
| Value              | Description                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------|
| **`disabled`**          | Debugging mode is disabled.                                                                   |
| `enabled`               | Debugging mode is enabled.                                                                    |

**NOTES** 
* Debug mode can have a significant impact on performance, and should not be enabled in production environments.

***

# DebugLogRoot

**DESCRIPTION**  
The debugging root directory.

**NOTES** 
* This should be left at `logs\debug`

***

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

# AbatabFallbackUserName

**DESCRIPTION**  
Ensures there is valid Abatab user.

**NOTES** 
* The AbatabUserName is the same as the Avatar Username stored in `sentOptObj.OptionUserId`, and is used to create session information/folders.
* If for some reason the `sentOptObj.OptionUserId` is empty, the AbatabUserName will be set to this fallback value.
* This should be left at `_Abatab`

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
