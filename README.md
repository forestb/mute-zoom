# mute-zoom<!-- omit in toc -->
A simple Windows console app that will toggle "mute" and "unmute" when Zoom is running by simulating the `Alt + A` key combination.

# Table of Contents<!-- omit in toc -->
- [Getting Started](#getting-started)
  - [Notice](#notice)
  - [Dependencies](#dependencies)
  - [Installing](#installing)
- [Version History](#version-history)
- [Acknowledgments](#acknowledgments)

## Project Goals
* The app can toggle mute/un-mute during Zoom meetings regardless of whether or not the Window has focus.
* The app should always bring the Zoom Window to the forefront (top-most). This makes it natural to find the window and re-engage in the conversation.
* The app should return focus to the last application being used. This makes it easy to continue typing in a Google Doc, for example.
* The app can be mapped to some shortcut and run without additional input (e.g. keyboard shortcut).

## Getting Started

### Notice
* It seems like this might be a bug in Zoom: the keyboard shortcuts for muting/un-muting (e.g. `Spacebar`, or `Alt + A`) do not work until you've clicked the button with your mouse first.

### Dependencies

* Windows 10 (At least, the only system it was tested on)
* .NET 4.8

### Installing

* Map the executable to some trigger (e.g. keyboard shortcut)

## Version History
* 1.1.0
  * After Zoom is muted, the calling application receives focus again
* 1.0.0
  * Initial Release

## Acknowledgments

* Lots of Google searches
{"mode":"full","isActive":false}