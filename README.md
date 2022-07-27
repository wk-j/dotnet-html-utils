# Html Utils

[![NuGet](https://img.shields.io/nuget/v/wk.HtmlUtils.svg)](https://www.nuget.org/packages/wk.HtmlUtils)

# Installation

```
dotnet tool install -g wk.HtmlUtils
```

# Usage

Find and replace `{version}` with `0.1.0` in  tag:`<title></title>` of `index.html`

```
wk-html-utils replace "//head/title" "{version}" "0.1.0" --file resource/index.html
```