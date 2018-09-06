FROM microsoft/dotnet:2.1.400-sdk-alpine AS builder

ARG Version
ARG NUGET_KEY
ARG NUGET_URL=https://api.nuget.org/v3/index.json
WORKDIR /sln

COPY . .

RUN dotnet restore
RUN dotnet build /p:Version=$Version -c Release --no-restore
RUN dotnet pack /p:Version=$Version -c Release --no-restore --no-build -o /sln/artifacts
# http://bit.ly/2OWtLjk