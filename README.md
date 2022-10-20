# HackerthonProject

# Agora Web API Version 1.0

###  Overview
> - An API that outputs a list of developer advocates with their details such as where they work, social links, bio, etc.

### API URL
> - http://donkennie-001-site1.dtempurl.com/

### Get all Advocates URL
> - http://donkennie-001-site1.dtempurl.com/api/advocates/

### Search for Advocate name query URL
> - http://donkennie-001-site1.dtempurl.com/api/advocates?searchTerm=kennie

### Paging query URL
> - http://donkennie-001-site1.dtempurl.com/api/advocates?pageNumber=1&pageSize=5

### Get Advocate by id URL
> - http://donkennie-001-site1.dtempurl.com/api/advocates/1

###  Get all Companies URL
> - http://donkennie-001-site1.dtempurl.com/api/companies/

### Get Company by id URL
> - http://donkennie-001-site1.dtempurl.com/api/companies/1

### paginate and search at the same
> - http://donkennie-001-site1.dtempurl.com/api/advocates?pageNumber=1&pageSize=5&searchTerm=kennie


> ### Features implemented:

> - Using CQRs and MediatR Pattern 

> ### Technlogies and packages used:

> - AutoMapper.Extensions.Microsoft.DependencyInjection
> - MediatR.Extensions.Microsoft.DependencyInjection
> - Microsoft.EntityFrameworkCore
> - MediatR
> - Microsoft.EntityFrameworkCore.Tools

> ### Pictoral Explanation

> - The four endpoints for the company and advocates
> 
![Screenshot (97)](https://user-images.githubusercontent.com/88739172/197054203-cb966778-1db6-4924-8ca2-2d28fe746ed4.png)

> - The search feature and pagination
![Screenshot (95)](https://user-images.githubusercontent.com/88739172/197054569-dc7823a8-04dd-4f17-a50b-8a2f34c65780.png)

>- Consuming Web API return type through exposing the API capabilities by defining it as a filter that specifies the type of the value and status code returned by the action.
![Screenshot (96)](https://user-images.githubusercontent.com/88739172/197054741-983b7ec1-864e-4447-992c-b94e54de7316.png)
