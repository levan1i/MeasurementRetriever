#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MeasurementRetriever/MeasurementRetriever.API.csproj", "MeasurementRetriever/"]
COPY ["MeasurementRetriever.Repository/MeasurementRetriever.Repository.csproj", "MeasurementRetriever.Repository/"]
COPY ["MeasurementRetriever.Domain/MeasurementRetriever.Domain.csproj", "MeasurementRetriever.Domain/"]
RUN dotnet restore "MeasurementRetriever/MeasurementRetriever.API.csproj"
COPY . .
WORKDIR "/src/MeasurementRetriever"
RUN dotnet build "MeasurementRetriever.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeasurementRetriever.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeasurementRetriever.API.dll"]