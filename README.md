# ExampleWebAPI

## Just a basic example of an ASP .NET Core Web API
### This project started as a way to learn more about web services, but became the focus of a class project.

### Please reference the API documentation for info on all the API functions here...
### https://documenter.getpostman.com/view/9459391/SW7Uaphp?version=latest

## Data Persistence
The web service requires the use of an SQL database to store character and word use.  
Schema:  
* WORD_USE  
  * WORD : VARCHAR(50)  
  * USES : INT(10)  
* CHAR_USE  
  * LETTER : VARCHAR(50)  
  * USES : INT(10)
### Once you run the service, you can test it out using postman
### Get Postman here : https://www.getpostman.com/
### Send a GET to this url "https://localhost:44346/Capitalize" (You may need to change the port in the url if this doesn't work for you)
### Add this to your request body...
    {
	    "stringToModify" : " this is a string   ",
        "trimTrailingWhiteSpace" : true,
        "trimPrecedingWhiteSpace" : true,
        "firstCharOnly" : true
    }
### Make sure the content type you are sending is JSON(application/json)

