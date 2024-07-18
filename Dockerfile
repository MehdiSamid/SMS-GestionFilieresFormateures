"FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base" 
"WORKDIR /app" 
"EXPOSE 80" 
"EXPOSE 443" 
"" 
"FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build" 
"WORKDIR /src" 
"COPY [\"SMS/SMS.csproj\", \"SMS/\"]" 
"COPY [\"SMS.Infrastructure/SMS.Infrastructure.csproj\", \"SMS.Infrastructure/\"]" 
"COPY [\"SMS.Application/SMS.Application.csproj\", \"SMS.Application/\"]" 
"COPY [\"SMS.Domain/SMS.Domain.csproj\", \"SMS.Domain/\"]" 
"RUN dotnet restore \"SMS/SMS.csproj\"" 
"COPY . ." 
"WORKDIR \"/src/SMS\"" 
"RUN dotnet build \"SMS.csproj\" -c Release -o /app/build" 
"" 
"FROM build AS publish" 
"RUN dotnet publish \"SMS.csproj\" -c Release -o /app/publish" 
"" 
"FROM base AS final" 
"WORKDIR /app" 
"COPY --from=publish /app/publish ." 
"ENTRYPOINT [\"dotnet\", \"SMS.dll\"]" 