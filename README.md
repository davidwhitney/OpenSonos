OpenSonos
=========

An implementation of Sonos "SMAPI" (Sonos Music API) documented here: http://musicpartners.sonos.com/?q=docs

# What does this do?

This proof of concept implementation allows you to run a sonos music server on your home network, sharing any SMB file share in it's entirety.
It's un-indexed, and not subject to the 65k track limits of the sonos media library.

Provided is an API implementation, and a simplistic search implementation.

# What doesn't work?

* Anything that isn't an MP3 right now won't display or play.
* Metadata and artwork - this is all bare bones
* Search only searches top-level directory names for the time

Those features can all be supported off this codebase. They're just currently not implemented.

# How do I use it?

* Git pull
* Compile
* Open app.config and edit the baseUrl, basePort and musicShare settings as you wish
* Run OpenSonos.LocalMusicServer.exe

The service will then auto-register itself after scanning your network.
Make sure your firewall allows traffic on your configured port (by default, 8080).

* Then open your sonos controller, and "login" by going to your "Service Settings", click "Sonos Labs" and add "LANServer".
* Just put anything in the username and password boxes

The app must be run with local admin credentials, and the music share must be an authentication-less SMB share that's compatible with cifs (Windows shares with guest access are fine).

# Manual Registration with your Sonos devices

The server attempts to scan your local network for Sonos players (given an IPv4 network). If it can't find them, you'll need to register the server by hand.

You'll need the IP address of a player on hand. You can grab one from the Sonos desktop app.

* Wait until it detects the Sonos players on your network
* Open a browser and visit: http://[player-ip-address]:1400/customsd.htm
* Fill in the following settings:

    * SID: 255    
    * Service name: LANServer
    * Endpoint URL: http://[base-Url-from-config]/sonos-api
    * Secure Endpoint URL: http://[base-Url-from-config]/sonos-api
    * Polling interval: 15
    * Authentication: Session ID
    * Presentation map: Version 4, Uri: http://[base-Url-from-config]/metadata/presentation-maps
    * Select Sonos Sound Lab
    * Capabilities: Search, Extended Metadata, Support the ability to received actions...
    
* Submit the form, this has registered the sonos server  

# Running as a service

Open a command prompt and type

    OpenSonos.LocalMusicServer.exe /i
    
This will request elevated access and install the app as a Windows service.

You'll then need to ensure the service is running as a user with administrative privileges.
Alternatively you can use urlacl to grant the service access to host at the URL you've specified in the configuration. Up to you.

It's simpler to go to services.msc and give the service a user account with appropriate privileges though.
That's it, it'll be running all the time.

# Known Isssues

For some reason (currently unknown, the network traffic looks correct) sometimes you'll have to enter a folder, return back out, and enter it again before MP3s show up. I have a suspicion this is some kind of client side caching, but I'll dig further into it - the network responses are identical.

# That's all rough and ready, can you make it easier?

Yes, in time. Installers, binaries etc, etc. But if you want it now, you're going to have to do it by hand!

# Can I help?

Sure! Get in touch

- D