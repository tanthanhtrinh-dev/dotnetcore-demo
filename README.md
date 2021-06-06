# ASP.Net Core V5 demo
I am studing ASP.Net Core 5. This is repository to practice

#install package
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet-aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

#How to initial migration and Execute
dotnet ef migrations add InitialCreate
dotnet ef database update

#To undo
ef migrations remove

#To Reset and rebuild mirgrations as below:
dotnet ef migrations remove
dotnet ef database drop
dotnet ef migrations add InitialCreate
dotnet ef database update
