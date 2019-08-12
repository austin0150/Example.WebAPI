# ExampleWebAPI

## Just a basic example of an ASP .NET Core Web API
### I just wanted to make something like this for my own practice.

### Runs on ASP Net Core 2.2 and Can be run in a docker container (Once I set that up) 

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

