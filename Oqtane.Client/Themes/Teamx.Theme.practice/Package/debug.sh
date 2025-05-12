#!/bin/bash

TargetFramework=$1
ProjectName=$2

cp -f "../Client/bin/Debug/$TargetFramework/$ProjectName$.Client.Oqtane.dll" "../../oqtane/Oqtane.Server/bin/Debug/$TargetFramework/"
cp -f "../Client/bin/Debug/$TargetFramework/$ProjectName$.Client.Oqtane.pdb" "../../oqtane/Oqtane.Server/bin/Debug/$TargetFramework/"
cp -rf "../Server/wwwroot/"* "../../oqtane/Oqtane.Server/wwwroot/"