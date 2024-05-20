FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0.300 AS build
WORKDIR /src

# Needed for target framework
COPY Directory.Build.props ./

COPY LeetCode/LeetCode.csproj LeetCode/
COPY LeetCode.CSharp/LeetCode.CSharp.csproj LeetCode.CSharp/
COPY LeetCode.FSharp/LeetCode.FSharp.fsproj LeetCode.FSharp/

COPY . .

WORKDIR /src/LeetCode

RUN dotnet restore LeetCode.csproj
RUN dotnet build LeetCode.csproj -c release

# Benchmarks require release configuration
ENTRYPOINT ["dotnet", "run", "-c", "release"]
