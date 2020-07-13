# TODOtNET - ASP.NET Core hosted full-stack C# web application with MVC framework
## Table of Content
1. [Introduction](#introduction)
2. [Used SDK version](#used-sdk-version)
3. [Used tools](#used-tools)
4. [Used packages](#used-packages)
5. [How to run the app](#how-to-run-the-app)\
	5.1. [Build and run with Docker](#build-and-run-with-docker)\
	5.2. [Build and run with SDK](#build-and-run-with-sdk)\
	5.3. [Test and stop](#test-and-stop)
6. [Limitations](#limitations)\
    7.1. [Exception/error handling](#exception-error-handling)
7. [Some further development possibilities](#some-further-development-possibilities)
8. [Resources](#resources)

## 1. Introduction <a name="introduction"></a>
This is a basic ASP.NET Core hosted web app using MVC framework with CRUD operations and user login/account management. You can register a new user account with your email address and password. After successful registration, you can log in and add, edit, remove and track TODO items. You can also edit your account data and delete your account. This app was created for learning purpose, but is might be useful as a starting-point for other projects.

The backend uses:
- Cookies/Sessions for authentication
- Entity Core as ORM
- Identity Core for identity management
- SQLite for DB management
- MCV framework

The frontend uses:
- Bootstrap

Tooling:
- Git Extensions as git gui
- VSC as text editor
- Docker for containerization
- Windows 10 as OS

If any question, please do not hesitate to contact me.

## 2. Used SDK version <a name="used-sdk-version"></a>
.NET Core SDK v3.1.301
## 3. Used tools <a name="used-tools"></a>
- dotnet-ef
- dotnet-aspnet-codegenerator
## 4. Used packages <a name="used-packages"></a>
- AutoMapper v10.0.0"
- AutoMapper.Extensions.Microsoft.DependencyInjection v7.0.0
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore v3.1.5
- Microsoft.AspNetCore.Identity.EntityFrameworkCore v3.1.5
- Microsoft.AspNetCore.Identity.UI v3.1.5
- Microsoft.AspNetCore.Mvc.NewtonsoftJson v3.1.5
- Microsoft.EntityFrameworkCore.Design v3.1.5
- Microsoft.EntityFrameworkCore.Sqlite v3.1.5
- Microsoft.EntityFrameworkCore.SqlServer v3.1.5
- Microsoft.EntityFrameworkCore.Tools v3.1.5
- Microsoft.VisualStudio.Web.CodeGeneration.Design v3.1.3
## 5. How to run the API <a name="how-to-run-the-app"></a>
### 5.1. Build and run with Docker <a name="build-and-run-with-docker"></a>
- download and install Docker
- clone or download the content of the repository
- open a terminal and navigate to the containing folder
- write "docker build -t todowebapp:v1 ." and press Enter
- write "docker run -it --rm -p 5000:5000 todowebapp:v1" and press Enter
### 5.2. Build and run with SDK <a name="build-and-run-with-sdk"></a>
- download and install .NET Core SDK version v3.1.301 or greater (latest 3.1)
- clone or download the content of the repository
- open a terminal and navigate to the containing folder
- write "dotnet restore" and press Enter
- navigate to folder Server
- write "dotnet run" and press Enter
### 5.3. Test and stop <a name="test-and-stop"></a>
- if no error message in the terminal, open your browser (recommended: latest Chrome, Firefox, Safari, Edge Chromium or Chromium) and open: http://localhost:5000
- first register a user account, then log in and after that you can manage your TODO items and account
- after testing go back to the terminal and press "Ctrl+C" to stop the web server
## 6. Limitations <a name="limitations"></a>
### 6.1. Exception/error handling <a name="exception-error-handling"></a>
This application needs to be extended with exception handling and more response values. There are some already known issues which may cause error when it is not used correctly. I only tested the app with correct input values.
## 7. Some further development possibilities <a name="some-further-development-possibilities"></a>
- adding firsname and lastname to user data
- customizing Identity UI
- Facebook sign-in
- adding roles (admin, user)
- automated unit and integration tests
## 8. Resources <a name="resources"></a>
There are several online source which I used for creating this web app.
I reused my TODOtNET_API RESTful API project as a backend and the frontend code from my TODOtNET_APP SPA project for this application. All the resources that are listed in the README.md at that repos applies here as well.\
MVC APP - Including but not limited to:
- https://asp.mvc-tutorial.com/
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-3.1

Thank to every hero on Stackoverflow and Github who helped me with their comments! (Not all heroes wear capes.)