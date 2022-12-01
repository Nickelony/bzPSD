using bzPSD;
using System.Diagnostics;
using SixLabors.ImageSharp;

var filePath = args.FirstOrDefault() ?? "Sample.psd";
filePath = Path.GetFullPath(filePath);
Console.WriteLine(filePath);

var resultFile = "Sample.png";
resultFile = Path.GetFullPath(resultFile);
Console.WriteLine(resultFile);

var psd = new PsdFile().Load(filePath);
using var image = ImageDecoder.DecodeImage(psd);
using var output = File.Create(resultFile);
image.SaveAsPng(output);

var process = new Process
{
    StartInfo = new ProcessStartInfo(resultFile)
    {
        UseShellExecute = true
    }
};
process.Start();
