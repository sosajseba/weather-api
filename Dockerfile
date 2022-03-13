FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools

EXPOSE 80
CMD ["sh", "/app/entrypoint.sh"]