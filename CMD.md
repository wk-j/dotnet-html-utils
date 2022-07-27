
```bash
dotnet run --project src/HtmlUtils/HtmlUtils.csproj -- \
    replace  "//head/title" "{version}" "0.1.0" --file resource/index.html

dotnet r -c pack -a "/p:Version=0.1.0"

act -j nuget
```