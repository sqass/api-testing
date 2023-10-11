
```

1. Start with empty table
2. Create a POST Request

```json
{
    "EmployeeID": 1,
    "FirstName": "John",
    "LastName": "Doe",
    "Age": 30,
    "State": "NJ"
}
```
```cs
{  "EmployeeID": 2, FirstName = "Alice", LastName = "Doe", Age = 30,  State = "NY" },
{  "EmployeeID": 3, FirstName = "Jane", LastName = "Smith", Age = 25, State = "CA" },
{ "EmployeeID": 3, FirstName = "Bob", LastName = "Johnson", Age = 35,  State = "IL" },
{"EmployeeID": 3,  FirstName = "Bob", LastName = "Doe", Age = 30, State = "MI" },
{ "EmployeeID": 3, FirstName = "Jane", LastName = "Smith", Age = 25, State = "MI" },
{ "EmployeeID": 3, FirstName = "Bob", LastName = "Johnson", Age = 35, State = "MI" },
{ "EmployeeID": 3, FirstName = "Alice", LastName = "Brown", Age = 28, State = "MI" }
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



# Validation

```js
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
```

# Install newman and htmlextra

`sudo npm install -g newman newman-reporter-htmlextra`

# Running from newman-cli

```bash
newman run Employees-cli.postman_collection.json -d InputFile.json -r htmlextra
```