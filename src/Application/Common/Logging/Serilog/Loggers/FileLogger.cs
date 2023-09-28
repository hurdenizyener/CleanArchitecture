using Application.Common.Logging.Serilog.ConfigurationModels;
using Application.Common.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Application.Common.Logging.Serilog.Loggers;

public sealed class FileLogger : LoggerServiceBase
{
    private readonly IConfiguration _configuration;

    public FileLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        FileLogConfiguration logConfig =
            configuration.GetSection("SerilogConfigurations:FileLogConfiguration").Get<FileLogConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string logFilePath = string.Format(format: "{0}{1}", arg0: Directory.GetCurrentDirectory() + logConfig.FilePath, arg1: ".txt");

        Logger = new LoggerConfiguration().WriteTo.File(
            logFilePath, rollingInterval: RollingInterval.Day, // Hergün yeni Dosya
            retainedFileCountLimit: null, // Dosyalar büyüdükce silme
            fileSizeLimitBytes: 5000000, // Dosya Boyutu Maxsimum
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
            ).CreateLogger();
    }
}
