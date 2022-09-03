FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Needed for target framework
COPY Directory.Build.props ./
COPY Benchmarks.CSharp/Benchmarks.CSharp.csproj Benchmarks.CSharp/
COPY LeetCode.CSharp/LeetCode.CSharp.csproj LeetCode.CSharp/
RUN dotnet restore Benchmarks.CSharp/Benchmarks.CSharp.csproj
COPY . .
WORKDIR /src/Benchmarks.CSharp
RUN dotnet build Benchmarks.CSharp.csproj --configuration Release

ENTRYPOINT ["dotnet"]
CMD ["run", "Benchmarks.CSharp.csproj", "--configuration", "Release", "--filter", "LeetCode.CSharpBenchmarks*", "--memory"]
