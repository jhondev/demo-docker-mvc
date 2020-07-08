FROM mcr.microsoft.com/dotnet/core/sdk:3.1
ENV DOTNET_USE_POLLING_FILE_WATCHER true  

WORKDIR /src/app

COPY DockerMVCApp/*.csproj .
COPY DockerMVCApp/Directory.Build.props .

# Remaining configs are in Properties/launchSettings.json
ENTRYPOINT [ "dotnet", "watch", "run" ]