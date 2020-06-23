# WebTodoList

![WebTodoList Build](https://github.com/albx/WebTodoList/workflows/WebTodoList%20Build/badge.svg?branch=master)

Simple todo list to compare blazor to react as clients.

The purpose of this project is to compare Blazor Webassembly to popular javascript frameworks, such as ReactJS, as client which consume a set of APIs.

Up to now it lacks all a set of test suite for the clients projects (Blazor WebAssembly and React).

## Requirements

In order to run the client using Blazor WebAssembly, you should install the latest .NET Core SDK and follow the documentation at [https://docs.microsoft.com/it-it/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio](https://docs.microsoft.com/it-it/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio).

## Projects

This solutions is composed of 3 main projects:
- WebTodoList.Api
- WebTodoList.Client.BlazorWASM
- WebTodoList.Client.ReactJS

### WebTodoList.Api
This is a simple .NET Core 3.1 API project.

It exposes some simple endpoints to manage a todo list.
Running this project you can go to https://localhost:44387/swagger to browse a Swagger UI with the description of all the endpoints

### WebTodoList.Client.BlazorWASM
This project is placed under the src/Clients directory.

It uses Blazor WebAssembly to build a SPA client which call the endpoints described previously.

### WebTodoList.Client.ReactJS
This project is placed under the src/Clients directory.

It uses React to build a SPA client which call the endpoints described previously.

## Contributing

Feel free to fork, open issue and PRs to propose and add functionalities you may consider interesting.
