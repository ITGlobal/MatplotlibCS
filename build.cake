#addin "nuget:?package=NuGet.Core&version=2.8.6"
#addin "Cake.ExtendedNuGet"

var TARGET = Argument("target", "default");
var CONFIGURATION = Argument("configuration", "Release");

var OUT_DIR = Directory("out");
var ARTIFACTS_DIR = Directory("artifacts");
var SOLUTION = File("MatplotlibCS.sln");
var VERSION = "1.0.0";

TaskSetup(context =>
{
    if(AppVeyor.IsRunningOnAppVeyor)
    {
        AppVeyor.AddInformationalMessage("Starting task {0}", context.Task.Name);
    }
});

TaskTeardown(_ => { });


Task("init")
    .Does(() =>
{
    foreach(var dir in new []{ OUT_DIR, ARTIFACTS_DIR })
    {
        if(!DirectoryExists(dir))
        {
            Information("Creating directory {0}", dir);
            CreateDirectory(dir);
        }
    }    
});

Task("clean")
    .IsDependentOn("init")
    .Does(() =>
{
    foreach(var dir in 
        new DirectoryPath[] { OUT_DIR, ARTIFACTS_DIR }
        .Concat(GetDirectories("./**/bin"))
        .Concat(GetDirectories("./**/obj")))
    {
        Information("Cleaning directory {0}", dir);
        CleanDirectory(dir);
    }
});

Task("restore")
    .IsDependentOn("init")
    .Does(() =>
{
    DotNetCoreRestore();
});

Task("version")
    .IsDependentOn("init")
    .Does(() =>
{
    if(AppVeyor.IsRunningOnAppVeyor)
    {
        VERSION = AppVeyor.Environment.Build.Version;
    }
    else
    {
        Warning("Will not use build number since build is not running in AppVeyor");
    }
    Information("Version is {0}", VERSION);
});

Task("compile")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .IsDependentOn("version")  
    .Does(() =>
{
    var settings = new MSBuildSettings
    {
        Configuration = CONFIGURATION
    };
    settings.WithProperty("OutputPath", new string[]{ MakeAbsolute(OUT_DIR).FullPath });
    // MSBuild(SOLUTION, settings);
    DotNetCoreBuild(".");
});

Task("pack")
    .IsDependentOn("version")
    .IsDependentOn("compile")    
    .Does(() =>
{
    var settings = new NuGetPackSettings
    {
        Version = VERSION,
        OutputDirectory = ARTIFACTS_DIR
    };
    NuGetPack("./MatplotlibCS.nuspec", settings);
});

Task("default").IsDependentOn("pack");

RunTarget(TARGET);