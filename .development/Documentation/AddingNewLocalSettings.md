# DEVELOPMENT NOTES - Adding new local settings

> Last updated 1-27-23

# Adding new local settings

1. Add the setting to Properties/Settings.settings
2. Open Web.config and copy/paste the setting where it belongs
3. Add an entry in Abatab.WebConfig.Load()
4. Add the setting to Abatab.Core.AbatabData.Session.cs
5. Add the proper logic to Abatab.Core.AbatabSession.Build()
