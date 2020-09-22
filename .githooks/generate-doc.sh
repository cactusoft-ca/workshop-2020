#!/bin/sh
# husky

dotnet build

swagger tofile --output "../../documentation/V1.json" "bin/Debug/netcoreapp3.1/Workshop2020.dll" "V1"

cd ../../documentation/
widdershins V1.json V1.md --omitBody=true --omitHeader=true --code=true --summary=true

rm V1.json