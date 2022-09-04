FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY --from=mcr.microsoft.com/dotnet/sdk:6.0 /usr/share/dotnet/sdk /usr/share/dotnet/sdk
COPY --from=mcr.microsoft.com/dotnet/sdk:6.0 /usr/share/dotnet/shared /usr/share/dotnet/shared

# Needed for target framework
COPY Directory.Build.props ./
COPY Benchmarks.CSharp/Benchmarks.CSharp.csproj Benchmarks.CSharp/
COPY LeetCode.CSharp/LeetCode.CSharp.csproj LeetCode.CSharp/

COPY . .
WORKDIR /src/Benchmarks.CSharp

RUN dotnet restore Benchmarks.CSharp.csproj /p:UseTargetFramework=net7.0
RUN dotnet build Benchmarks.CSharp.csproj /p:UseTargetFramework=net7.0 -c Release
RUN dotnet restore Benchmarks.CSharp.csproj /p:UseTargetFramework=net6.0
RUN dotnet build Benchmarks.CSharp.csproj /p:UseTargetFramework=net6.0 -c Release

# Benchmarks require release configuration and always check memory allocation
ENTRYPOINT ["dotnet", "run", "Benchmarks.CSharp.csproj", "-c", "Release", "--memory"]
