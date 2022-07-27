
using System.CommandLine;
using HtmlAgilityPack;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo>(
            name: "--file",
            description: "Input file"
        );

        var sourceText = new Argument<string>(
            name: "sourceText",
            description: "Source text"
        );

        var replaceByText = new Argument<string>(
            name: "replaceText",
            description: "Replace by"
        );

        var xpath = new Argument<string>(
            name: "xpath",
            description: "xpath"
        );

        var replaceCommand = new Command("replace", "Replace text in html");
        replaceCommand.AddArgument(xpath);
        replaceCommand.AddArgument(sourceText);
        replaceCommand.AddArgument(replaceByText);

        var rootCommand = new RootCommand("HTML util");
        rootCommand.AddGlobalOption(fileOption);
        rootCommand.AddCommand(replaceCommand);


        replaceCommand.SetHandler((file, xpath, source, replace) =>
        {
            Replace(file, xpath, source, replace);
        }, fileOption, xpath, sourceText, replaceByText);


        await rootCommand.InvokeAsync(args);

        return 0;
    }

    static void Replace(FileInfo file, string xpath, string source, string replace)
    {
        var htmlFile = file.FullName;

        var htmlDoc = new HtmlDocument();
        htmlDoc.Load(htmlFile);

        // "//head/title"

        var title = htmlDoc.DocumentNode.SelectSingleNode(xpath);
        if (title != null)
        {
            var innerText = title.InnerHtml.Replace(source, replace);
            title.InnerHtml = innerText;
            htmlDoc.Save(htmlFile);
        }
    }
}