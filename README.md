# CustomerRegistrationApp
 Name  - S.M Pasindu Madushan Bandara
Number - 0710337486

##Introduction
Customer Registration application is a basic development of customer register, update, see details, and delete customers.
Customer consist of name, phone number, address and email.
Fields of Add new and update forms are validated using angular validators

##Technologies
Web API - ASP.NET Core
Front end – Angular 13
DataBase – MS SQL

##Web API Architecture
Web API architecture called as repository architecture. In this architecture has folder structure of IRepository, Repository, Request Models, Response Model, and Controller.
Repository Contains implementations of IRepository Classes. Repositories have crud function. In here I used stored procedures calls to execute queries.
Parameter comes from controller to repositories by using properties of request model. Then all the responses return to controllers using response models.  
Front End architecture
For front end development I used angular 13. It has a component base architecture. I used 3 separate folder for customer-details, customer-table, add-customer. Components are exist inside those folders.
Customer service is separately maintained for API calls. And customer model use to store customer properties.
MS SQL
I used MS SQL database and stored procedure back end program.

##Installation
•	Download the files from the Link - https://github.com/pasindumadushan/CustomerRegistrationApp.git
•	Run sql script in the database folder
•	Run CustomerRegistrationWebAPI 
•	npm install to my-angular-app
•	Run my-angular-app

