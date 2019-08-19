using ceTe.DynamicPDF.Merger;
using System;
using System.Text.RegularExpressions;

namespace example_split_pdf_dotnet
{

    // This example shows how to split a PDF document.
    // It references the ceTe.DynamicPDF.CoreSuite.NET NuGet package.
    class Program
    {
        // Splits a PDF document into two.
        // This code uses the DynamicPDF Merger for .NET product.
        // Import the ceTe.DynamicPDF.Merger namespace for the PdfDocument and MergeDocument classes.
        static void Main(string[] args)
        {
            //Create a PdfDocument using the source PDF
            PdfDocument pdf = new PdfDocument(GetResourcePath("doc-a.pdf"));

            // Create MergeDocument and append the pages needed from main document to split
            MergeDocument part1 = new MergeDocument();
            part1.Append(pdf, 1, 1);
            part1.Draw("part1.pdf");

            // Create MergeDocument and append the pages needed from main document to split
            MergeDocument part2 = new MergeDocument();
            part2.Append(pdf, 2, 1);
            part2.Draw("part2.pdf");
        }

        // This is a helper function to get the full path to a file in the Resources folder.
        public static string GetResourcePath(string inputFileName)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, "Resources", inputFileName);
        }
    }
}
