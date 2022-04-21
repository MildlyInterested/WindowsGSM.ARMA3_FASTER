# WindowsGSM.ARMA3_FASTER
WindowsGSM plugin that integrates FASTER managed Arma servers into WindowsGSM
All this plugin does it to create an empty server folder thats tracked by WindowsGSM so you can let FASTER install a server into that.
WindowsGSM will then use the "arma3server_x64.exe" to launch your copy pasted launch arguments from FASTER.

## Requirements
[WindowsGSM](https://github.com/WindowsGSM/WindowsGSM) >= 1.21.0
[FASTER](https://github.com/Foxlider/FASTER)

## Installation
1. Download the [latest](https://github.com/BattlefieldDuck/WindowsGSM.ARMA3/releases/latest) release
1. Move **ARMA3.cs** folder to **plugins** folder
1. Click **[RELOAD PLUGINS]** button or restart WindowsGSM

## Current known issues
1. Headless clients need an extra install so WindowsGSM can track them, you can simlink their files to save space
2. The picture in the "MOD" column will be shown on all ARMA3 servers, regardless if installed via this plugin or the normal ARMA3 plugin.