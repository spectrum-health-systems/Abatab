# Web.config file

The Web.config file contains the local settings for Abatab. These settings are also in Settings.settings.

## Mode
> `Mode=enabled`

Abatab can operate in the following modes:

* `enabled`  
All Abatab functionality is available.

* `disabled`  
Abatab is disabled, and its functionality is not available.

* `passthrough`
Abatab is enabled, and all functionality is available, but no changes are made to Avatar.

## AbatabEnvironment

## AbatabRoot

## DebugMode

> `DebugMode=off`

* `on`  
Debug logs will be written. This may affect performance, and should not be enabled in production environments.

* `off`
Debug logs will not be written.

## DebugValidUsers

*Not currently used*

## DebugLogRoot

## LogMode

> `LogMode=session`

* `all`  
All log types will be written

* `none`  
No log files will be written

* `session`
Only session logs will be written.

* `%logType01%-%logType02%-%logType03%`  
Log types included in this string will be written.  
For example, to write `error` and `trace` logs:  
`LogMode=error-trace`  

## LogDetail

*Not currently used*

## LogWriteDelay

## AbatabFallbackUserName

## ModTestingMode

## ModQuickMedOrderMode

## ModQuickMedOrderValidUsers

## ModQuickMedOrderDoseMaxPercentIncrease

## ModQuickMedOrderDoseMaxMilligramIncrease

## ModPrototypeMode