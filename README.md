# LobsterAdventures

Setup the application by running the below commands 

```docker
docker build -f LobsterAdventures/Dockerfile -t my_adventures .

docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e  ASPNETCORE_URLS=http://+:5000 my_adventures
```

*Note* : Swagger does not work while running the above docker commands.
You would have to run the app locally (using Visual Studio or any other IDE) to work on Swagger.

## Adventure Controller

- Get the list of adventures
- Get an adventure by ID- 
- Get a list of Decisions by Adventure
- Creates a new Adventure


## Decision Controller

- Get the next decision based on the previous answer
- Adds a Decision/Question to an Adventure


## Player Controller

- Returns the Path taken by a player for a particular adventure
- Maps the decision taken to the player 

I have pre-populated a player and some questions in the AddTestData() method within the Startup.cs file



