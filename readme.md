Rel's Texture Packer GUI .Net
=============================

A simple GUI for Rel's Texture Packer, since the official one is (as far as I can tell) done in VB6 and a pain in the ass to run on any remotely current operating system.

At the moment it's just a quick wrapper around Rel's Texture_packer executable. It would be ideal to rewrite the core texture_packer logic to have an all-in-one exe and fix some of the shortcomings but for now it works well enough.

Idealistic but highly unlikely to-do:
------------------

* Implement texture_packer logic in .Net (remove dependency on external EXE)
* Fix minor bugs like no output when target output directory doesn't exist
* More configuration options like input/output path and what file types to output (eg code headers, index images)

Credits / thanks
------

[Relminator](http://rel.phatcode.net) - texture packer implementation

[BlackPawn](http://www.blackpawn.com/texts/lightmaps/default.html) - texture atlas algorithm