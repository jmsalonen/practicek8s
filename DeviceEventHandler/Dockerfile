FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet build -c Release
RUN dotnet publish -c Release -o out
EXPOSE 5002
ENTRYPOINT ["dotnet", "out/DeviceEventHandler.dll"]
