param($installPath, $toolsPath, $package, $project)

Write-Host Setting MRLib items CopyToOutputDirectory=true
$project.ProjectItems.Item("MRLib").ProjectItems.Item("HiveDriver.exe").Properties.Item("CopyToOutputDirectory").Value = 1;
