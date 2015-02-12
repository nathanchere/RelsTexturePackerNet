STAG - Simple(ish) Texture Atlas Generator
==========================================

This started out as a simple GUI for Rel's Texture Packer since the official GUI was done in VB6 and a pain in the ass to run on any remotely current operating system. After trying to work around numerous bugs and limitations of the underlying texture packer (eg imposing directory structure, no PNG output, no notification or output of any kind on error) I decided it was easier to just rewrite the entire thing and ditch the RTP dependency completely.

Features
--------

* Accepts BMP, PNG, GIF, JPG input
* Output 32bit PNG (use something else to reduce to a fixed palette if needed)

So far the most common question I receive is 'what packing algorithm am I using'. I started out with a mangled bastardisation of the MaxRects approach but couldn't get satisfactory results from it (entirely a failure on my part). I ended up coming up something which uses a similar contact point heuristic for scoring but determines placements based on used space corners rather than free space edges.

Build status
--------

Branch | Status | Download
------|-----|------
master | [![Build status](https://ci-beta.appveyor.com/api/projects/status/51gsvoo39q01abmo/branch/master)](https://ci-beta.appveyor.com/project/nathanchere/stag) | [.zip](https://github.com/nathanchere/stag/archive/master.zip)
stable | [![Build status](https://ci-beta.appveyor.com/api/projects/status/51gsvoo39q01abmo/branch/stable)](https://ci-beta.appveyor.com/project/nathanchere/stag) | [.zip](https://github.com/nathanchere/stag/archive/stable.zip)

Release history
---------------

#### vNext
* Raising events for atlas generation to support displaying in-progress steps
* Optimise Corners heuristic implementation - currently horribly slow and inefficient

#### v0.2 (2015-02-12)
* Release MaxBinRect heuristic with own custom heuristic
* Much more "TDD" than the first algorithm implementation

#### v0.1 (2014-03-20)
* First stable-ish release
* MaxBinRect implementation is kind of broken but good enough for basic use cases

#### vAlpha (2014-02-17)
* First release to GitHub

Credits / thanks
------

[Jukka Jylänki](http://clb.demon.fi) - for the [excellent](http://clb.demon.fi/projects/rectangle-bin-packing) [articles](http://clb.demon.fi/projects/more-rectangle-bin-packing) on [packing algorithms](http://clb.demon.fi/projects/even-more-rectangle-bin-packing) - even though it wasn't used in the end it was direction enough to get me started

[Relminator](http://rel.phatcode.net) - original texture packer which was the inspiration for this project

[![Send me a tweet](http://nathanchere.github.io/twitter_tweet.png)](https://twitter.com/intent/user?screen_name=nathanchere "Send me a tweet") [![Follow me](http://nathanchere.github.io/twitter_follow.png)](https://twitter.com/intent/user?screen_name=nathanchere "Follow me")
