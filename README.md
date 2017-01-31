# DDS2Tool
A tool for editing Persona 5 Bustup BINs
![Image of program](https://images-ext-1.discordapp.net/.eJwFwdENhCAMANBdGIAitFbchsBFzJ2FSI0fxt3vvcdc58-spqr2sQLkIrbsI7ezpN5tbgck1ZTr8REdMGGYMMbAHjksPGMEz-hcWIhm8kSeHcIlX2m32C6bef8ddx4O.djWCH9BrRq1BvaIhUFc-g2tQNyg)
**DDS2Tool** isn't a tool for Digital Devil Saga 2, but it _is_ a tool for extracting DDS images from DDS2 archives. In **Persona 5**, bustup BIN files contain typically 2 DDS files per frame.
Atlus's bizarre way of avoiding image compression artifacts was to save one layer of the frame with DXT1 compression, and another with DXT5. In-game, the DXT1 is overlayed ontop of the DXT5 to give the illusion of a full image being rendered. Each 2 slices of the frame are stored together as a DDS2 file, hence the name of the tool.
##Usage
By **supplying the path to a BIN file**, you can extract all DXT1 and DXT5 images from the BIN. They will be saved to a new folder for editing.
Note: This does not work on the early, unused portraits from the Persona 5 trailer.

By **supplying a path to a folder with DDS images**, you can generate a new BIN file.
Note: This will probably only work in-game if you keep the filenames the same, and don't add or remove DDS files. I'm not sure at this time if saving the DDS file with a different type of compression will matter, but try to stick to DXT1 and DXT5 if possible.

And finally, by **supplying a path to a folder with BIN files**, you can mass-extract all the DDS files. It will automatically skip any unused ones using DXT3.
