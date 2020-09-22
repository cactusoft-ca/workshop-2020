#!/bin/sh
# husky
echo $PWD
dotnet build
dotnet tool restore
dotnet swagger tofile --output "../../documentation/V1.json" "bin/Debug/netcoreapp3.1/Workshop.Api.dll" "V1"

cd ../../documentation/
widdershins V1.json V1.md --omitBody=true --omitHeader=true --code=true --summary=true
