FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY Shirka.Domotics.Tests.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o publish 

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "test", "Shirka.Domotics.Tests.dll"]
