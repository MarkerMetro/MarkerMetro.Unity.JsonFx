Unity Editor (.Net 3.5), Windows 8.1 and Windows Phone 8 plugin libraries for JsonFX (the A * Pathfinding fork) https://bitbucket.org/TowerOfBricks/jsonfx-for-unity3d

Latest code taken from this commit: https://bitbucket.org/TowerOfBricks/jsonfx-for-unity3d/commits/866e6402be15

This should be a drop in replacement for JsonFX within a Unity project.

Build the solution and copy the resultant dlls into the following folder structure in your Unity project EXACTLY as follows:

MarkerMetro.Unity.JsonFx Project > /Assets/Plugins/JsonFx.Json.dll

MarkerMetro.Unity.JsonFxMetro Project > /Assets/Plugins/Metro/JsonFx.Json.dll

MarkerMetro.Unity.JsonFxWP8 Project > /Assets/Plugins/WP8/JsonFx.Json.dll

Note there is a dependency on https://github.com/MarkerMetro/MarkerMetro.Unity.WinLegacy

Latest binaries referenced from following commit and stored in /References in this repository https://github.com/MarkerMetro/MarkerMetro.Unity.WinLegacy/commit/86c873c9c98a1ad7aa7fd8e80ddf336d1fce6e9f
