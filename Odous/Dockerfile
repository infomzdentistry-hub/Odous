FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out
EXPOSE 8080
ENV ASPNETCORE_ENVIRONMENT=Production
RUN mkdir -p /var/data
RUN chmod 777 /var/data
ENTRYPOINT ["dotnet", "out/Odous.dll"]