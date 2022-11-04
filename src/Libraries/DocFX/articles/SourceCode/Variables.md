# Variables

## Prefixes

* `sent`  
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.
* `work`  
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 
* `final`  
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

## Casing and trimming

Most logic in Abatab is checked against lowercase values without any leading/trailing whitespace, so (in general) Abatab will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_ AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", Abayab will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

## Multiple values

Multiple values are stored in strings, with each value seperated by a `-`" character. For example, the following values:

```#bash
Apple  
Pear
Orange
```

would apprear as:

`Apple-Pear-Orange`
