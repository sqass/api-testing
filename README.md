# api-testing

# pre-requisite


git config user.email "contact@softwarequalityassociates.com"


```yml
version: '3.9'

services:
  # MySQL database service
  mysql:
    image: mysql:5.7
    container_name: mysql_container
    environment:
      # MYSQL_ROOT_PASSWORD: 'password123'
      MYSQL_DATABASE: employee
      MYSQL_USER: 'test-user'
      MYSQL_PASSWORD: 'password1234'
    ports:
      - "3306:3306"
    volumes:
      - ./mysql_data:/var/lib/mysql
      - ./my-custom.cnf:/etc/mysql/my.cnf # Mount the custom configuration file
    # Add an initialization script to create the table
    # command: --init-file /docker-entrypoint-initdb.d/init.sql

  # .NET Core Web API service
  # webapi:
  #   build:
  #     context: ./employees
  #     dockerfile: Dockerfile
  #   container_name: employees_container
  #   ports:
  #     - "7174:80"
  #   depends_on:
  #     - mysql
  #   environment:
  #     ConnectionStrings__DefaultConnection: "Server=mysql;Database=employee;User=test-user;Password=password1234"
```