
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

        var replaceCommand = new Command("replace", "Replace text in html");
        replaceCommand.AddArgument(sourceText);
        replaceCommand.AddArgument(replaceByText);

        var rootCommand = new RootCommand("HTML util");
        rootCommand.AddGlobalOption(fileOption);
        rootCommand.AddCommand(replaceCommand);


        replaceCommand.SetHandler((file, source, replace) =>
        {
            Replace(file, source, replace);
        }, fileOption, sourceText, replaceByText);


        await rootCommand.InvokeAsync(args);

        return 0;
    }

    static void Replace(FileInfo file, string source, string replace)
    {
        var htmlFile = file.FullName;

        var htmlDoc = new HtmlDocument();
        htmlDoc.Load(htmlFile);

        var title = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
        if (title != null)
        {
            var innerText = title.InnerHtml.Replace(source, replace);
            title.InnerHtml = innerText;
            htmlDoc.Save(htmlFile);
        }
    }
}