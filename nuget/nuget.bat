nuget pack Transformalize.Transform.LambdaParser.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Transform.LambdaParser.Autofac.nuspec -OutputDirectory "c:\temp\modules"

REM nuget push "c:\temp\modules\Transformalize.Transform.LambdaParser.0.11.1-beta.nupkg" -source https://api.nuget.org/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Transform.LambdaParser.Autofac.0.11.1-beta.nupkg" -source https://api.nuget.org/v3/index.json
