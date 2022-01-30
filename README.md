# RealCat API
The project is a .Net Core Web API application and it is developed using C# .Net 6.0

## About the Application
In-memory database used in this application, RealCat.API solution can be started directly

## API Docunmatation
Endpoints and explanations:

**api/tokens/create** will create a token for the given user

**api/cats/get** will return a random cat image\
**api/cats/upside_down** will return a upside down flipped cat image\
**api/cats/custom_rotation** will return a random cat flipped image :rotation (0, 90, 180, 270)\
**api/cats/filter** will return a random cat with image filtered by :filter (blur, mono, sepia, negative, paint, pixel)\
**api/cats/width_and_height** will return a random cat with :width and :height

**api/users/get** will return a user information for the given username\
**api/users/get_all** will return all users\
**api/users/create** will create a new user

## How to test API methods

To test API methods easily, RealCat_Api_Collection.json file can be imported into Postman 

Except users/create and cats/custom_rotation(for testing purposes) methods and all other methods requires authorization. Therefore a new token must be created first as given below.

![image](https://user-images.githubusercontent.com/98488371/151707729-3e578bb8-2f52-46c5-bc66-b6c575d7b676.png)
predefined admin user can be used for token creation operation:
{
  "username": "admin",
  "password": "admin"
}

after token is created, it can be reused in later calls.
![image](https://user-images.githubusercontent.com/98488371/151708003-59443174-0896-4b07-b49f-45b9feff02be.png)


