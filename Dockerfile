FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . .

ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet restore
RUN dotnet clean && dotnet publish -c Release

CMD dotnet bin/Release/net7.0/publish/api.dll

EXPOSE 5000