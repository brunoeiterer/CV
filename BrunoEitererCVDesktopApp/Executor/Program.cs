using System.Diagnostics;

var processStartInfo = new ProcessStartInfo
{
    WorkingDirectory = Path.Join(Directory.GetCurrentDirectory(), "Dependencies"),
    FileName = Path.Join(Directory.GetCurrentDirectory(), "Dependencies", "BrunoEitererCV.exe")
};

Process.Start(processStartInfo);