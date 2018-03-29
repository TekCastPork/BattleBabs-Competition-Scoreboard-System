---
title: Changelog - BattleBots Scoreboard Competitiob System
description: A program originally coded for highschool battlebot competitions.
layout: alternate
---


# Changelog:

## Version 2.4.0 Build 114

Additions!

### Additions:
* Added a "Whats New" popup to the Scoreboard program, so you don't have to come here every time to see whats changed between the latest version and its previous.

#### Notes:
Somehow this broke the font system on the scoreboard much like how the sorter broke it on the leaderboard. I do not know why this happened again so like the leaderboard all required font files are going to be placed in your Windows Fonts folder instead of with the executable.

## Version 2.3.0 Build 109

Bug fixes and Additions!

### Fixes:
* The Change teams button on the scoreboard disappeared at some point. Its back and now found under the general tab on the toolbar.
* The Leaderboard wouldn't show session 2 when I changed it up because of the new feature, that's fixed.
* Fixed some typos on the updater on the scoreboard
* Both the scoreboard and leaderboard would crash on startup if the computer did not have internet when it went to check for a new version. That's fixed...

### Additions:
* Leaderboard has a Rank system again! No longer do you need to manually look and see who is in first, the leaderboard does that for you now!

### General Changes:
* The font used in this program (GodOfWar.ttf) is now placed into the fonts folder on your Windows Machine. This is done because for some reason the just added sorter code broke the code that changes the font of the labels so I didn't have to specify a font on the GUI designer. So, for now, it's placed there instead of in the application folder and I will look into why that code is broken later.

#### Notes:
I'm working on making a splash screen that tells you the changes between versions so you don't have to read these while the installers download, and so that if you forget you don't have to navigate here.

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