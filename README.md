# Starwars Swapi

## Description
Application to integrate with https://swapi.dev/api/ that allows users to interact with the Star Wars API and display data from the API. The application also has the capability to navigate deeper into the data hierarchy. 

## Solution

I had fun with this problem. Not only I like projects that interact with APIs but I also get to work around Starwars data.

* It uses entity framework to create and manage the User related database. This will be used for authentication.

* Uses JWT token and authentication, to create a token per user, so that it can be used by the frontend to use the API related to starwars data.

* Isolated the SwApi integration to a library so that it can be easily reused.

* Implemented custom Polly policy in case of 429 errors, to wait and retry.

* It relies on Sqlite cache to store and persist starwars data to improve performance since its data is quite large. The cache resides in the StarwarsCache.db in the api project folder.

* Logs were implemented to help manage it.

## How to Run

Clone the project and run. The necessary databases will be created and the api will be ready to be accessed.

Open _Starwars.Web/index.html_ to access the frontend component.