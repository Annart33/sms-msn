# SMS Messenger

## Introduction
With the SMS Messenger app you will be able to send an SMS to the specified number and watch your messaging history.
The client side was written using the react framework and the server side with c# and .net 6.

## Database
For the database i used Amazon Web Services RDS to get a free and easy to use cloud db.


## Strcuture of client
The client basically contains 2 main components- message history and new message components. 
When creating a new message, an api request will be sent to twilio using the smsSender service, and a post message with it's details will be sent to our server.
By clicking history, the app sends a get request to the server to get all the previously sent messages.


## Strcuture of server
### Migrations -
As the server goes up, all the migration files will be called and will run in the db, creating all the specified tables, etc.
### Controllers -
You will find a controllers directory which contains the api requests that come from the client to save new messages in the db and get all existing messages in order to view your messaging history.
### Services -
The services are called by the controllers and will be the "logical" part of the request processing, before talking to the db.
### Stores -
The stores are called by the services and they talk directly with the db, using the class DbConnectionHolder which is responsible for connecting to the db using the provided connection string (which you can find in appsettings.json).
### DTO -
The DTOs contain the objects such as Message and MessageRequest.
### Mappers -
The Message mapper maps the message request into the message object in order to save it that way in the db. 

# How to run the app
### Server side
To set up the server side please run in your console (in the API project), the following command: \
dotnet build && dotnet run --urls=http://localhost:7272
### Client side
To set up the client side please run in your console (in my-app project), the following command: \
npm i && npm start
# sms-msn
# sms-msn
