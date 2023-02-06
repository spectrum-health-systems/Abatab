# Abatab Roadmap Queue

# Dose warnings

* Public name needs to be formatted better
* Public log data should be different
* Private name should include a timestamp

## ModQuickMedOrder

### Dose

#### VerifyAmount

We should be writing a bunch of this stuff to logs, even when successful.


## Web Server directories
There should be three directories on the web server:

1. AbatabWebService - the web service

* Abatab_LIVE
* Abatab_UAT
* Abatab_SBOX

2. AbatabData - data such as Lieutenant stuff, Abatab logs, etc.

3. AbatabPublic - data available to the public.

## Issue when an environment is refreshed

When an environment is refreshed, the WSDLs come down from LIVE, and need to be recreated in the refreshed environment.

Is there a better way to do this?

## New images

We have:

* Changelog
* Logo
* Manual Logo
* Release Notes
* Roadmap

We may need:

* Blank
* Flowchart
* Development notes

# Hmmm...

* We are currently lowercasing lots of stuff (e.g., stuff in the Web.config)...should we?

# Verifications

* Verify that the avatar fallback username works
