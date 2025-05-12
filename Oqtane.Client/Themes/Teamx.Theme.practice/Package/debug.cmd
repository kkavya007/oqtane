@echo off
set TargetFramework=%1
set ProjectName=%2

XCOPY "..\Client\bin\Debug\%TargetFramework%\%ProjectName%.Client.Oqtane.dll" "..\..\oqtane\Oqtane.Server\bin\Debug\%TargetFramework%\" /Y
XCOPY "..\Client\bin\Debug\%TargetFramework%\%ProjectName%.Client.Oqtane.pdb" "..\..\oqtane\Oqtane.Server\bin\Debug\%TargetFramework%\" /Y
XCOPY "..\Client\wwwroot\*" "..\..\oqtane\Oqtane.Server\wwwroot\" /Y /S /I