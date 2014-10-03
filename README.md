OpenSonos
=========

An implementation of Sonos "SMAPI" (Sonos Music API) documented here: http://musicpartners.sonos.com/?q=docs

# What does this do?

This proof of concept implementation allows you to run a sonos music server on your home network, sharing any SMB file share in it's entirety.
It's un-indexed, and not subject to the 65k track limits of the sonos media library.

# What doesn't work?

* Anything that isn't an MP3 right now won't display or play.
* Metadata and artwork - this is all bare bones
* Search

Those features can all be supported off this codebase. They're just currently not implemented.

# How do I use it?

* Git pull
* Compile
* Open app.config and edit the baseUrl and musicShare settings as you wish
* Run OpenSonos.LocalMusicServer.exe
* Wait until it detects the Sonos players on your network
* Open a browser and visit: http://[player-ip-address]:1400/customsd.htm
* Fill in the following settings:

    SID: 255
    Service name: LANServer
    Endpoint URL: http://[base-Url-from-config]/sonos-api
    Secure Endpoint URL: http://[base-Url-from-config]/sonos-api
    Polling interval: 15
    Authentication: Session ID
    Presentation map: Version 4, Uri: http://[base-Url-from-config]/metadata/presentation-maps
    Select Sonos Sound Lab
    Capabilities: Search, Extended Metadata, Support the ability to received actions...
    
* Submit the form, this has registered the sonos server    
* Then open your sonos controller, and "login" by going to your "Service Settings", click "Sonos Labs" and add "LANServer".
* Just put anything in the username and password boxes

# That's all rough and ready, can you make it easier?

Yes, in time. Installers, binaries, Windows services, auto-registration etc, etc. But if you want it now, you're going to have to do it by hand!

# Can I help?

Sure! Get in touch

- D