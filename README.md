# DDS2Tool
A tool for editing Persona 5 Bustup BINs
![Image of program](https://images-ext-1.discordapp.net/.eJwFwdENhCAMANBdGIAitFbchsBFzJ2FSI0fxt3vvcdc58-spqr2sQLkIrbsI7ezpN5tbgck1ZTr8REdMGGYMMbAHjksPGMEz-hcWIhm8kSeHcIlX2m32C6bef8ddx4O.djWCH9BrRq1BvaIhUFc-g2tQNyg)
**DDS2Tool** isn't a tool for Digital Devil Saga 2, but it _is_ a tool for extracting DDS images from DDS2 archives. In **Persona 5** (PS3), bustup BIN files contain typically 2 DDS files per frame.
Atlus's bizarre way of avoiding image compression artifacts was to save one layer of the frame with DXT1 compression, and another with DXT5. In-game, the DXT1 is overlayed ontop of the DXT5 to give the illusion of a full image being rendered. Each 2 slices of the frame are stored together as a DDS2 file, hence the name of the tool.
## Usage
By **dragging a BIN file** onto the window, you can extract all DXT1 and DXT5 images from the BIN. They will be saved to a new folder for editing.
Bustups that are split up into pairs (hence the DDS2 name) will automatically be converted to PNG and combined, for your convenience.
Note: This does not work on the early, unused portraits from the Persona 5 trailer (as they used DXT3).
By **dragging a folder** onto the window that **contains DDS files**, you can create a new BIN for use in the game as a mod.
For info about modding the game, check out TGE's [Mod Compendium](https://github.com/TGEnigma/Mod-Compendium).

Try dragging multiple folders and bins at once too for batch conversion!
