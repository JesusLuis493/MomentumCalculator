FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/MomentumCalculator.Core/*.csproj src/MomentumCalculator.Core/
COPY src/MomentumCalculator.API/*.csproj  src/MomentumCalculator.API/
RUN dotnet restore src/MomentumCalculator.API/*.csproj
COPY src/ src/
RUN dotnet publish src/MomentumCalculator.API/*.csproj \
    -c Release -o /out --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
USER app
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "MomentumCalculator.API.dll"]

# Autor y datos generales
LABEL maintainer="jesusdev@gmail.com"
LABEL version="2.0"
LABEL description="Docker image for .NET 8.0 SDK on Ubuntu"