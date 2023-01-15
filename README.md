## StiToStix

This project is based on the code by Carlos Lubbers (Deltares) who was so kind to put me in the right direction for the following automation task;

**Convert D-GeoStability sti files to the new D-GEO Suite D-Stability stix files.**

Deltares has changed the DStability software line from the old D-GeoStability to the new D-GEO Suite D-Stability and the old file format (sti) can be imported 
into the new software and saved as the new format (stix) but if you have thousands of calculations which are in need of an update the manual process will be challenging (and boring!) so I asked Deltares for a solution. Carlos sent me sample code and I adjusted the code to make it work for multiple files. 

You will need;

* Windows
* An installation of D-GEO Suite D-Stability (free)
* An installation of [https://github.com/microsoft/WinAppDriver/releases/download/v1.2.99/WindowsApplicationDriver-1.2.99-win-x64.exe](WinAppDriver)
* Visual Studio 2022 (community edition is free)
* A little programming experience

Follow the next instructions to get it to work on your PC.

* Put your computer into developer mode, [use any tutorial for that](https://www.republicworld.com/technology-news/apps/how-to-enable-or-disable-developer-mode-in-windows-10-know-details.html)
* Run WinAppDriver.exe, usually found under C:\Program Files\Windows Application Driver\
* Make sure to adjust the paths to your own path (see next code)

```
// ADJUST TO YOUR OWN PATHS
public string stiDir = @"C:\Users\brein\Documents\Deltares\sti"; <- ADJUST
public string dstabExe = "C:\\Program Files (x86)\\Deltares\\D-GEO Suite\\D-Stability 2022.01.2\\bin\\D-Stability.exe"; <- MAYBE ADJUST
```

* run the programme
* **don't touch the pc until it is done!**

## Slow!

Note that the process is slow (approx 100 files per hour).. nothing you can do about that though.. and computers don't mind to do stupid stuff!
You could probably speed up the code by trying smaller sleep pauses but be careful with that. Another thing would be to limit the path length, the shorter,
the better!

## A big thank you...

...goes to Carlos Lubbers for helping me with the initial c-sharp code 

## And note..

...I am not a regular c-sharp programmer and have not checked the code to see if it is clean or according to the c-sharp standards

Rob van Putten, jan 2023


