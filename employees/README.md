# Create new table

```sql
CREATE TABLE EmployeeDetails (
    EmployeeID INT ,
    FirstName VARCHAR(100),
	LastName VARCHAR(100),
    Age INT,
    State VARCHAR(2)
);
```

1. Start with empty table
2. Create a POST Request

```json
{
    "EmployeeID": 1,
    "FirstName": "John",
    "LastName": "Doe",
    "Age": 30,
    "City": "NJ"
}
```
3. Create a GET request for employee 1
4. Update the State to `MI` using PUT Request

```json
{
    "employeeID": 1,
    "firstName": "John",
    "lastName": "Doe",
    "age": 30,
    "city": "MI"
}
```
5. Update the City to MN using patch request

```json
{
    "city": "NY"
}
```
6. Now delete the record