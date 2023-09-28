namespace Application.Common.Logging.Serilog.ConfigurationModels;

public sealed class FileLogConfiguration
{
    public string FilePath { get; set; }

    public FileLogConfiguration()
    {
        FilePath = string.Empty;
    }

    public FileLogConfiguration(string filePath)
    {
        FilePath = filePath;
    }
}
