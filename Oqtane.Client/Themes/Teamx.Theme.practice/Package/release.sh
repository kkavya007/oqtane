TargetFramework=$1
ProjectName=$2

"..\..\oqtane\oqtane.package\nuget.exe" pack %ProjectName%.nuspec -Properties targetframework=%TargetFramework%;projectname=%ProjectName%
cp -f "*.nupkg" "..\..\oqtane\Oqtane.Server\Packages\"