FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY --from=mcr.microsoft.com/dotnet/sdk:6.0 /usr/share/dotnet/sdk /usr/share/dotnet/sdk
COPY --from=mcr.microsoft.com/dotnet/sdk:6.0 /usr/share/dotnet/shared /usr/share/dotnet/shared

# Needed for target framework
COPY Directory.Build.props ./

COPY LeetCode.ConsoleApp/LeetCode.ConsoleApp.csproj LeetCode.ConsoleApp/
COPY LeetCode.CSharp/LeetCode.CSharp.csproj LeetCode.CSharp/
COPY LeetCode.FSharp/LeetCode.FSharp.fsproj LeetCode.FSharp/

COPY . .

WORKDIR /src/LeetCode.ConsoleApp

RUN dotnet restore LeetCode.ConsoleApp.csproj
RUN dotnet build LeetCode.ConsoleApp.csproj -c Release

# Benchmarks require release configuration and run against both net6.0 and net7.0 SDKs
ENTRYPOINT ["dotnet", "run", "LeetCode.ConsoleApp.csproj", "-f", "net6.0", "-c", "Release"]
