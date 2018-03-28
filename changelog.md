---
title: Changelog - BattleBots Scoreboard Competitiob System
description: A program originally coded for highschool battlebot competitions.
layout: alternate
---


# Changelog:

## Version 2.2.1 Build 99

General Fix Update

### Fixes:
* Default entries placed by the updater if a file cannot be verified were out of order. They are now in order
* Build number was fixed due to merge to master branch

## Version 2.2.0 Build 73 - PRE RELEASE

New Feature Update

### Additions:
* Added an update checker to both server and client. From this version on if a new version if released to the github the program will notify you.
* Added the ability to edit scoring methods for the scoreboard
* Persistent files for the client and server have their contents validated to ensure that 99% of the time it wont crash because of bad input.

### Fixes:
* General bug fixes applied to client and server

#### Notice:
This version is a pre-release. I am still adding some features and fixes to this version so it isn't marked as a full release yet.

I am also switching to a new versioning tactic. The first number is the major version, the second number is the sub-version, the last number is revision, then the build number.

## Version 2.1.1.5

General Bug Fix plus one addition

### Fixes:
* Fixed bugs that caused session system to not actually work properly with the played status flags

### Additions:
* Added a minimum size to the scoreboard so it can't be squished in such a way where the buttons and labels overlap eachother

## Version 2.1.1.0

General Bug Fixes

### Fixes:
* Settings window game duration box now shows the current duration instead of a default value.

## Version 2.1.0.0

General Fixes and improvements

## Version 2.0.0.0

Initial C# version release