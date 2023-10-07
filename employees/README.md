# Software needed

 1. [dotnet ](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 2. [postman](https://www.postman.com/downloads/)
 3. [docker](https://www.docker.com/products/docker-desktop/)
 4. [my sql](https://dev.mysql.com/downloads/workbench)


# Creating the database

1. Run the command `docker run -d -p 3306:3306 --name employee-mysql -e MYSQL_ROOT_PASSWORD=password123 -e MYSQL_DATABASE=employee mysql:latest' from your terminal/bash
2. Open mysql workbench
3. Click on create new connection
4. Enter the details as shown in below screenshot with password as `password123`
![image](https://github.com/bhargavjulaganti/Stocks/assets/11901773/236e5d5b-2658-4d52-b654-c635dabce85e)
5. Click on test connection, the connection to the database should be successful.
6. Double click on the newly created database
7. Click on create new query session
8. Run the create table query as shown below 
```sql
USE employee;
CREATE TABLE EmployeeDetails (
    EmployeeID INT ,
    FirstName VARCHAR(100),
	LastName VARCHAR(100),
    Age INT,
    State VARCHAR(2)
);
```
9. Run the below query to see whether the table is created or not. You should get table with empty records
``` sql
SELECT * FROM EmployeeDetails
```

# Running the api

1. Navigate to employees directory with command `cd employees`
2. run the command `dotnet run`
3. The api should be up and running on the localhost ports `https://localhost:7071;http://localhost:5163`

# Testing the api using postman

1. Create a GET request (https://localhost:7071/api/employee/1). You should see response status code 404
2. Create a POST request (https://localhost:7071/api/employee). with below body, should see success response 201

```json
{
    "EmployeeID": 1,
    "FirstName": "John",
    "LastName": "Doe",
    "Age": 30,
    "State": "NJ"
}
```
3. Now hit the get request with employeeID (https://localhost:7071/api/employee/1), should see response code 200.
4. Lets try to update the employee state with "NY" , with put request below body

```json
{
    "EmployeeID": 1,
    "FirstName": "John",
    "LastName": "Doe",
    "Age": 30,
    "State": "NY"
}
```
5. Now hit the get request , you will see state is updated to NY


