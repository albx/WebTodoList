# Runs the migrations and create the database if not exists
dotnet ef database update -p .\src\WebTodoList.Core\WebTodoList.Core.csproj -s .\src\WebTodoList.Api\WebTodoList.Api.csproj