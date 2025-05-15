@echo off
set TargetFramework=%1
set ProjectName=%2

del "*.nupkg"
"..\..\oqtane\oqtane.package\nuget.exe" pack %ProjectName%.nuspec -Properties targetframework=%TargetFramework%;projectname=%ProjectName%
XCOPY "*.nupkg" "..\..\oqtane\Oqtane.Server\Packages\" /Y