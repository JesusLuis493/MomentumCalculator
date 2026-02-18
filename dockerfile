# Entorno de desarrollo de la aplicasion
FROM ubuntu:24.04

# Autor y datos generales
LABEL maintainer="jesusdev@gmail.com"
LABEL version="1.0"
LABEL description="Docker image for .NET 8.0 SDK on Ubuntu"

# Instalar dependencias necesarias
RUN apt-get update && \
    apt-get install -y wget && \
    wget https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y dotnet-sdk-8.0 git && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app
RUN git clone https://github.com/JesusLuis493/MomentumCalculator.git && \
    cd MomentumCalculator && \
    dotnet restore

# Exponer el puerto de la aplicación
EXPOSE 5277

# Instrucciones para el cmd
WORKDIR /app/MomentumCalculator
CMD ["dotnet", "run", "--project", "src/MomentumCalculator.CLI/MomentumCalculator.CLI.csproj"]
