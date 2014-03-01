RelTexPacNet - Texture Atlas Generator
======================================

This started out as a simple GUI for Rel's Texture Packer since the official GUI was done in VB6 and a pain in the ass to run on any remotely current operating system. After trying to work around numerous bugs and limitations of the underlying texture packer I decided it was easier to just rewrite the entire thing and ditch the RTP dependency completely.

Branches
--------
**master:**
[![Build status](https://ci-beta.appveyor.com/api/projects/status/51gsvoo39q01abmo/branch/master)](https://ci-beta.appveyor.com/project/nathanchere/relstexturepackernet)

**stable:**
[![Build status](https://ci-beta.appveyor.com/api/projects/status/51gsvoo39q01abmo/branch/stable)](https://ci-beta.appveyor.com/project/nathanchere/relstexturepackernet)

Idealistic but highly unlikely to-do:
------------------

* Implement texture_packer logic in .Net (remove dependency on external EXE)
* Fix minor bugs like no output when target output directory doesn't exist
* More configuration options like input/output path and what file types to output (eg code headers, index images)

Credits / thanks
------

[Relminator](http://rel.phatcode.net) - original texture packer which was the inspiration for this project

[BlackPawn](http://www.blackpawn.com/texts/lightmaps/default.html) - texture atlas algorithms

[![Send me a tweet](http://nathanchere.github.io/twitter_tweet.png)](https://twitter.com/intent/user?screen_name=nathanchere "Send me a tweet") [![Follow me](http://nathanchere.github.io/twitter_follow.png)](https://twitter.com/intent/user?screen_name=nathanchere "Follow me") 