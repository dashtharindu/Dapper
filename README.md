This project contains basic CRUD operations with DAPPER micro-ORM

I've used Asp.net web api here and below I've attached API calls required for this app.
You can use Postman to test this app.
(please note that this application only used Dapper non-async methods and if you need to do this in async you may customize this with async methods.)

====================
Future Version Plans
====================
This project currently has no any connection with <b>Swagger</b> But in future versions I will include that with Dapper+ bulk operations



*port number can be differ than "44337"
===============================================
Insert
===============================================
URL : https://localhost:44337/api/Product/
Request type: Post

Body(with application/json header),

Name : string
Quantity : int
Price : int



===============================================
Get All
===============================================
URL : https://localhost:44337/api/Product/
Request type: Get



===============================================
Get by ID (In URL "2" is a ID)
===============================================
URL : https://localhost:44337/api/Product/2
Request type: Get



===============================================
Update (In URL "2" is a ID)
===============================================
URL : https://localhost:44337/api/Product/2
Request type: Post

Body(with application/json header),

Name : string
Quantity : int
Price : int



===============================================
Delete
===============================================
URL : https://localhost:44337/api/Product/2
Request type: Delete
==============================================