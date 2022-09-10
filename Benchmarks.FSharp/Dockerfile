FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Needed for target framework
COPY Directory.Build.props ./
COPY Benchmarks.FSharp/Benchmarks.FSharp.fsproj Benchmarks.FSharp/
COPY LeetCode.FSharp/LeetCode.FSharp.fsproj LeetCode.FSharp/

COPY . .
WORKDIR /src/Benchmarks.FSharp

RUN dotnet restore Benchmarks.FSharp.fsproj
RUN dotnet build Benchmarks.FSharp.fsproj -c Release

# Benchmarks require release configuration and run against both net6.0 and net7.0 SDKs
ENTRYPOINT ["dotnet", "run", "Benchmarks.FSharp.fsproj", "-f", "net7.0", "-c", "Release"]