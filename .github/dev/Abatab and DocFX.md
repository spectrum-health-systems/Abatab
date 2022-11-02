# Abatab and DocFX

1. Create a new .NET Framework 4.8 Class Library project named "DocFX"
2. Add the docfx.console NuGet package
3. Remove "DocFX/Class1.cs"
3. Add DocFX/ to Abatab/Libraries/"
4. Add the DocFX project to Abatab, in the Libraries/ solution folder
5. Change the following code:
```bash
"files": [
"*.csproj"
],
"cwd": ".",
```

to this:
```bash
"files": [
"*.sln"
],
"cwd": "../../",
```
6. Clean and rebuild the solution

You should now see documentation in Abatab/Libraries/DocFX/_site/api/