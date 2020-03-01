# Seek and Deploy - Documentation

## Summary

**Category:** Sitecore Meetup Website 

Our main idea was to develop a 100% sitecore site for planing meetings. The main functionality is based on the current MeetUp web site. The design of the web page was develop by a backend team inspired on the current sitecore website.


## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

No, it is based on plain helix example, using unicorn for items synchronization


## Installation

-	Install Sitecore 9.3 with helix-basic-unicorn example running 
-	Deploy website by clicking the build option on Visual studio project for "Hackathon.Boilerplate\Environment\Website"
-   Please review file "Local.pubxml.user.props" inside "Hackathon.Boilerplate\Environment\Website\Properties\PublishingProfiles" to configure your deployed site location
-   After deploying the site, please do a unicorn sync
-   Do a smart site publish on sitecore


## Configuration

No additional configuration is needed

## Usage
Once the site is running you will see the list of created events in the body of the site, by clickingo on the "More" button you will be able to navigate into the details of that event.
On the header of the site, there is a search bar avaialble, for looking for an specificc event, the keyword that isu sed for the search will be used to llok on the event name and description.
We also provide user registration to be able to create a new Event and publish it on the site ({site-url}\Register).
After a user is registrated it may login with the credentials that were provided ({site-url}\Login).

Creating an event is really simple, you just need to provide the Event details and location, this location will be used for displaying on it for users on a map

Unfortunately we did not manage to finish all the ideas that we had for this website, like:

-	Grouping events into categories ( like JSS, etc. ) so that users may search events by their likings
-   Another idea was to create a profile where user may login and share their event information on social networks
-   Developing a search module for events near your current location
-   Giving the ability to identify if an event was created by sitecore staff and mark them as "Official", giving them more weight on the result list

## Video

https://youtu.be/ChS3HzvJrk4
