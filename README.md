# Software needed

1. [postman](https://www.postman.com/downloads/)
2. [docker](https://www.docker.com/products/docker-desktop/)
3. [my sql](https://dev.mysql.com/downloads/workbench)


# Running the application

1. Clone the repo [api-testing](https://github.com/sqass/api-testing.git)
2. Go to root directory of the project from your terminal
3. Run `docker-compose up` . You should see something like this
    <img width="1141" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/c9ec7f13-2616-4bc3-83c4-93e20d6451d4">
4. Open mysql workbench
5. Click on create new connection
4. Enter the details as shown in below screenshot with user as `user123` and password as `password1234`
<img width="900" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/239c7f1f-087e-481c-9b58-fa568578099f">

5. Click on test connection, the connection to the database should be successful.
6. Double click on the newly created database
7. Click on create new query session
8. Run the below select query, should see a record on the table 
```sql
SELECT * FROM employee.EmployeeDetails;
```

<img width="1143" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/eb73a058-f083-4145-ac52-67746c0498e6">

# Testing the api using postman

### Create your first GET request

- Create a GET srequest to read the details of EmployeeId `1`

`RequestUrl` : http://127.0.0.1:7174/api/employee/1

`HttpMethod` : GET


<img width="1301" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/ad29ec92-0cb6-4baf-a9f0-03e46371ef5b">

### Create your first POST request 

[Refer to authorization section how to authorize endpoint](###Authorization)

- Create a POST request to create new employee details, see the below screenshot for example

`RequestUrl` : http://127.0.0.1:7174/api/employee

`HttpMethod`: POST

`RequestBody`: 
```json
{
    "EmployeeID": 2,
    "FirstName": "James",
    "LastName": "sad",
    "Age": 30,
    "State": "MI"
}
```
<img width="1290" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/6bb62199-a480-4d93-b68c-59def91cc116">


### Create your first PUT request 

[Refer to authorization section how to authorize endpoint](###Authorization)

Let's update the State of the newly created employee to `IL`. For this we need to create a PUT request request

`RequestUrl` : http://127.0.0.1:7174/api/employee/2`

`HttpMethod`: PUT

`RequestBody`: 
```json
{
    "EmployeeID": 2,
    "FirstName": "James",
    "LastName": "sad",
    "Age": 30,
    "State": "IL"
}
```

<img width="1295" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/8ea90027-feec-476b-aa4f-fd470bbdf5b4">

### Create your first PATCH request 

[Refer to authorization section how to authorize endpoint](###Authorization)

Let's update again the state of employee 2 from `IL` to `NY`. For this we will be using PATCH request.

You might be wondering, whats the difference between PUT and PATCH. In Patch request, we do not send entire request body details. We only send what are required

`RequestUrl` : http://127.0.0.1:7174/api/employee/2

`HttpMethod`: PATCH
request Body: 
```json
{
    "EmployeeID": 2,
    "FirstName": "James",
    "LastName": "sad",
    "Age": 30,
    "State": "NY"
}
```
<img width="1297" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/c34795f0-fdcc-44f8-9c74-1f9c45003453">

### Create your first DELETE request

[Refer to authorization section how to authorize endpoint](###Authorization)

We can incur by the name, if you want to delete a record then we use DELETE request.

`RequestUrl` : http://127.0.0.1:7174/api/employee/2

`HttpMethod`: DELETE

<img width="1313" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/78bedab9-6239-4f25-9a1b-a9fe10d921e2">

### What are Request Parameters in postman ?

Let's say in our example, we want to find the details of the employees who's state is `NJ`

For this we need to pass the state to the request, that's where request parameters will come in place.

`RequestUrl` : http://localhost:7174/api/employee/ByState

`RequestParams` : State

`HttpMethod` : GET

<img width="1301" alt="image" src="https://github.com/sqass/api-testing/assets/142704021/95bdd032-69e4-4ef7-8814-593ca387e390">




### Authorization

In order create, update or delete employee details, we need to get a bearer token and add to the header.

This would also help you to understand how we can test an authorization to the endpoint.

To get the bearer token , hit the endpoint `http://localhost:7174/api/auth` with the below request body

```json
{
    "username" : "random@gmail.com",
    "password" : "strongpassword"
}
``` 

<img width="1254" alt="image" src="https://github.com/bhargavjulaganti/LearningCypress/assets/11901773/4c8afb12-02ae-47c6-a57b-f9bc782ef4b3">

Add the token as bearer header for the POST/PUT/DELETE endpoint as shown below

<img width="1304" alt="image" src="https://github.com/bhargavjulaganti/LearningCypress/assets/11901773/9d797d79-bd9b-454d-bd09-d73a452f8b8a">