FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80/tcp
WORKDIR /app
COPY bin/Release/net6.0/publish/ /app
ENTRYPOINT ["dotnet", "rfeTestAPI.dll"]