nuget pack Transformalize.Transform.LambdaParser.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Transform.LambdaParser.Autofac.nuspec -OutputDirectory "c:\temp\modules"

nuget push "c:\temp\modules\Transformalize.Transform.LambdaParser.0.11.1-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
nuget push "c:\temp\modules\Transformalize.Transform.LambdaParser.Autofac.0.11.1-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
