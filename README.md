# Poketype
A back-end service for getting Pokemon type related data

# Dependencies
1. .NET Core 3.0
1. Mongo DB



# One Time Steps
This application runs using a Linux docker container. Running the container will also spin up a local instance of Mongo DB. You will have to do a few initial steps on your dev machine in order to get up and running.

1. There are a few environement variables that will need to be set. These only need to be set up initially.
  - ```Poketype_MongoUsername```
  - ```Poketype_MongoPassword```
       - When ```docker-compose``` is run, it will spin up a mongo database with these credentials.
  - ```Poketype_Database```
       - This will be the connection string to your MongoDB database. It'll look something like this: 
       ```
       mongodb://{username}:{password}@mongo:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&authSource=admin&authMechanism=SCRAM-SHA-256
       ```
       - You will want to replace the username and passwords with the two above ones you specified to be your MongoDB credentials.
1. In the project structure, there is a file under Data/MongoDB called ```mongo_backup.agz```. Using your favorite MongoDB tool or the command line (using ```mongorestore```, you can use this file to restore the schema needed to run the application. This will import all collections the application is currently using. If this is updated, you may need to kill your existing database and rerun it.
