FROM mcr.microsoft.com/dotnet/sdk:5.0-focal
WORKDIR /app

RUN apt-get update && \
    apt-get install -y postgresql-client

RUN dotnet tool install --global dotnet-ef --version 5.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

COPY findabeer.api/ .
COPY entry.sh .
RUN rm -fr ./obj ./bin

RUN dotnet restore
RUN dotnet publish -c Release -o out

ENTRYPOINT ["bash", "./entry.sh"]