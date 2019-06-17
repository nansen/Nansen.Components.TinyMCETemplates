@echo off
cls

echo Creating the module zip file..
powershell -command "Compress-Archive -Path .\module.config, .\Templates\ -DestinationPath .\Modules\_protected\Nansen.TinyMCETemplates\Nansen.TinyMCETemplates.zip -CompressionLevel Optimal -Force"
echo.

echo Creating NuGet package..
echo.
nuget pack Nansen.Components.TinyMCETemplates.csproj -Build -Properties Configuration=Release -Verbosity detailed

echo.
echo.
echo Done...