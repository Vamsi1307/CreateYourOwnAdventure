# CreateYourOwnAdventure
CreateYourOwnAdventure repo is a solution which allows a player to choose their own
adventure by picking from multiple choices in order to progress to the next set of choices,
until they get to one of the endings. You should be able to persist the player’s choices and in
the end, show the steps they took to get to the end of the game.

This application is built using .Net 6 and SQLite 3.12.2

# Prerequisite
- Docker - https://docs.microsoft.com/en-us/virtualization/windowscontainers/quick-start/set-up-environment?tabs=Windows-Server

# Architecture & Components
- This project is developed using Clean architecture where all the layers are decoupled.
- Swagger Implementation
- Error Handling
- Docker Impementation
- Unit Tests

# Endpoints

#Docker Endpoints:
- Swagger Url: http://localhost:7088/index.html
- Swagger Url: https://localhost:7089/index.html

#Local Swagger Endpoint: 
- Swagger Url: https://localhost:9876/index.html

# Documentation
- https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/visual-studio-tools-for-docker?view=aspnetcore-6.0

#Sample Swagger Inputs for each API:

#Create Adventure
- {
    "question": "Do I want a doughnut?",
    "yes": {
        "question": "Do I deserve it?",
        "yes": {
            "question": "Are you sure?",
            "yes": {
                "question": "Get it.",
                "yes": null,
                "no": null
              },
            "no": {
                "question": "Do jumping jacks first",
                "yes": null,
                "no": null
              }
          },
        "no": {
            "question": "Is it a good doughnut?",
            "yes": {
                "question": "What are you waiting for? Grab it now.",
                "yes": null,
                "no": null
              },
            "no": {
                "question": "Wait till you find a sinful, unforgettable doughnut",
                "yes": null,
                "no": null
              }
          }
    },
    "no": {
        "question": "May be you want an apple?",
        "yes": null,
        "no": null
    }
}

#Get Adventures
- No parameters required

#Get Adventure by AdventureId
- Input adventureId as 1

#Create Game
- [
   "Y", "N", "Y"
  ]

#Get Games
- No parameters required

#Get Game by GameId
- Input gameId as 1


# Frameworks:
- Dotnet 6
- SQLite 3.12.2
- Docker 20.10.17

# How to run the solution:
- Clone the repo into a folder of your choice: git clone https://github.com/Vamsi1307/CreateYourOwnAdventure/
- Open powershell from the root folder eg: CreateYourOwnAdventure
- Type "docker-compose up"

The endpoint will be up and running. 
curl --location --request GET 'http://localhost:7088/' \
--header 'Content-Type: application/json'

# Running Unit Tests 
- Navigate to the unit test folder: cd CreateYourOwnAdventure.UnitTests
- Type dotnet test, to run the unit tests included.

# What else can be done to improve code quality
- Authentication and authorisation can be implemented
- Logging can be enabled for all the layers
- Add more validations
- More negative unit tests and improve code coverage 
- Add integration tests using SpecFlow
- Docker installation could be automated