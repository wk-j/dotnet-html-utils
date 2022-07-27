
```bash
dotnet run --project src/HtmlUtils/HtmlUtils.csproj -- \
    replace "{Version}" 0.1.0 --file resource/index.html --xys

dotnet r -c pack -a "/p:Version=0.1.0"
```