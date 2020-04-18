# WebTodoList

![WebTodoList Build](https://github.com/albx/WebTodoList/workflows/WebTodoList%20Build/badge.svg?branch=master)

Simple todo list to compare blazor to react as clients.

The purpose of this project is to compare Blazor Webassembly to popular javascript frameworks, such as ReactJS, as client which consume a set of APIs.

Up to now it lacks all a set of test suite for the clients projects (Blazor WebAssembly and React).

## Requirements

In order to run the client using Blazor WebAssembly, first of all you need at least .NET Core SDK version 3.1.201.

After installing the .NET Core SDK, you have to install Blazor WebAssembly Preview4 running this command

```
dotnet new -i Microsoft.AspNetCore.Components.WebAssembly.Templates::3.2.0-preview4.20210.8
```

(You can follow the post at [https://devblogs.microsoft.com/aspnet/blazor-webassembly-3-2-0-preview-4-release-now-available/](https://devblogs.microsoft.com/aspnet/blazor-webassembly-3-2-0-preview-4-release-now-available/))

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

It uses Blazor WebAssembly (Preview 4) to build a SPA client which call the endpoints described previously.

### WebTodoList.Client.ReactJS
This project is placed under the src/Clients directory.

It uses React to build a SPA client which call the endpoints described previously.

## Contributing

Feel free to fork, open issue and PRs to propose and add functionalities you may consider interesting.