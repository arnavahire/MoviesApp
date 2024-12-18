# MoviesApp
This is a simple movie app where you can add movies to the website and add reviews on those movies.

This project has been implemented using .Net 8 framework with Blazor server settings so that we can create a Blazor based Web Application.

- **Backend: C#**

- **Frontend: Razor web pages, HTML, CSS**

- **Database: MySql (on docker)** (check connection string in appsettings.json to connect to the Mysql DB)


### Pages

- _Home Page:_

  - The home page shows list of movies added to the DB. Whenever you add a new movie, the movie shows up on this page.
The movies appear as cards which are written using Bootstrap cards.

- _Add/Edit Movie:_

  - If you want to add a new movie, you navigate to this page in order to do that.

- _Add Review:_

  - If you want to add a review to the existing movies, you can do so by navigating to this url.

### Running the app

- Make sure the docker image for MySql is already running. Make sure you configure the connection string in appsettings.json.
- Run the app by running the command `dotnet run`.
- If you make changes to Models, run migration using `dotnet ef migrations add <migration_name> ` and apply the migration using `dotnet ef database update`.
