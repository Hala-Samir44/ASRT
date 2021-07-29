#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LLS-Users/LLS-Users.csproj", "LLS-Users/"]
COPY ["LLS.BLL/LLS.BLL.csproj", "LLS.BLL/"]
COPY ["LLS.CommonDefinitions/LLS.CommonDefinitions.csproj", "LLS.CommonDefinitions/"]
COPY ["LLS.DAL/LLS.DAL.csproj", "LLS.DAL/"]
RUN dotnet restore "LLS-Users/LLS-Users.csproj"
COPY . .
WORKDIR "src/LLS-Users"
RUN dotnet build "LLS-Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LLS-Users.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LLS-Users.dll"]