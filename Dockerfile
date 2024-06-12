FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY ICI.ProvaCandidato.Web/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish ICI.ProvaCandidato.Web -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ICI.ProvaCandidato.Web.dll"]