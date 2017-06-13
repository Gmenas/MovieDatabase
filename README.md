# MovieDatabse
## Team Gmenas
- [markshark05](http://telerikacademy.com/Users/markshark05)
- [ogitaki](http://telerikacademy.com/Users/ogitaki)

## Project description:
**MovieDatabse** is a console application where you can create a collection of movies with their details such as cast, director, release date etc. Data is stored in MS SQL Server and some of the data is loaded from xml and json files. The database modeling is done through Entity Framework (code first).

## The application data is stored in:
- MS SQL Server
- XML Files
- JSON Files

## Tables Relations
![Tables](http://i.imgur.com/l8TQzCy.png)

## Frameworks used
- Entity Framework
- JSON.NET

## List of commands
- create-movie 
  - you'll be presented with a form to fill in the movie data
  - all necessary data will automatically be created if it isn't already in the database
- create-actor
  - manually add an actor to the database
  - you'll be presented with a form to fill actor data
- create-director
  - manually add a director to the database
  - you'll be presented with a form to fill director data
- list-movies [by-title, by-rating, by-year, by-date-added]
   - list all movies in the database
   - you can also supply an additional parameter to change the order
- remove-movie [movieName]
   - removes a movie from the database
- remove-genre [genreName]
  - remove a genre from the database
  - this will remove all movies of that genre