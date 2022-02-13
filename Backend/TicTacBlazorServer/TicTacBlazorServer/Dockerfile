#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TicTacBlazorServer/TicTacBlazorServer.csproj", "TicTacBlazorServer/"]
RUN dotnet restore "TicTacBlazorServer/TicTacBlazorServer.csproj"
COPY . .
WORKDIR "/src/TicTacBlazorServer"
RUN dotnet build "TicTacBlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicTacBlazorServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicTacBlazorServer.dll"]