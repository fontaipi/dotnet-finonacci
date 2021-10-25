FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Fibonacci.Api/Fibonacci.Api.csproj", "Fibonacci.Api/"]
RUN dotnet restore "src/Fibonacci.Api/Fibonacci.Api.csproj"
COPY . .
WORKDIR "/src/Fibonacci.Api"
RUN dotnet build "Fibonacci.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fibonacci.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fibonacci.Api.dll"]
