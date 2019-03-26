# ATENTION Chicago devs:
## You will find two other files in this repository calld ReadmeAsWell (docs & pdf)
## In there you will find the development procedures, workflow, assumptions.

# Setup 

## Download .NET Core 2.2 SDK (Or just the runtime)

https://dotnet.microsoft.com/download/dotnet-core/2.2

## To build and run the project using the command line:
- 1) Open the Command Prompt
- 2) Download the project repository with the following command: `git clone https://github.com/maximojgonzalezc/SCodeChallengeWebAPI.git`
- 3) Step into the solution directory folder `cd SCodeChallengeWebAPI`
-	4) Restore nuget packages with `dotnet restore`
- 5) Step into the project src `cd SCodeChallengeWebAPI`
-	6) Create the database `dotnet ef migrations add FirstMigration`
-	7) Apply the migration to the database to create the schema `dotnet ef database update`
-	8) Run the project `dotnet run` in the src directory.

- Point your browser to http://localhost:5001

Of course, you can also run it from either Visual Studio 2017 or Visual Studio Code with the IDE handling most of the steps above. 

## To run the unit tests follow all steps until 4, followed by:
- 5) Step into the project src `cd SCodeChallengeWebAPITest`
- 6) Run `dotnet test`

## API Endpoints documentation:
https://documenter.getpostman.com/view/6990804/S17tQ7i7
