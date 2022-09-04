FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Needed for target framework
COPY Directory.Build.props ./
COPY Benchmarks.FSharp/Benchmarks.FSharp.fsproj Benchmarks.FSharp/
COPY LeetCode.FSharp/LeetCode.FSharp.fsproj LeetCode.FSharp/

COPY . .
WORKDIR /src/Benchmarks.FSharp

RUN dotnet restore Benchmarks.FSharp.fsproj /p:UseTargetFramework=net6.0
RUN dotnet build Benchmarks.FSharp.fsproj /p:UseTargetFramework=net6.0 -c Release

# Benchmarks require release configuration and always check memory allocation
ENTRYPOINT ["dotnet", "run", "Benchmarks.FSharp.fsproj", "-c", "Release", "--memory"]