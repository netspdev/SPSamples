param($installPath, $toolsPath, $package, $project)

$dir = split-Path $MyInvocation.MyCommand.Path;
& "$dir\e91ef18daa974d3a9868e0f425e02ab5.ps1" $installPath $toolsPath $package $project;

