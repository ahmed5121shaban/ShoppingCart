FROM mcr.microsoft.com/dotnet/core/sdk:8.0 AS build
WORKDIR /src
COPY ["ShoppingCart.csproj", "ShoppingCart/"]
RUN dotnet restore "ShoppingCart/ShoppingCart.csproj"
COPY . .
RUN dotnet build "ShoppingCart/ShoppingCart.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "ShoppingCart/ShoppingCart.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM mcr.microsoft.com/dotnet/core/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.dll"]