using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Converter;

// Интерфейс команды
public interface ICommand
{
    Task ExecuteAsync();
}

// Команда для получения информации о видео
public class GetVideoInfoCommand : ICommand
{
    private readonly string _videoUrl;
    private readonly YoutubeClient _youtubeClient;

    public GetVideoInfoCommand(string videoUrl)
    {
        _videoUrl = videoUrl;
        _youtubeClient = new YoutubeClient();
    }

    public async Task ExecuteAsync()
    {
        try
        {
            var video = await _youtubeClient.Videos.GetAsync(_videoUrl);

            Console.WriteLine("=== Информация о видео ===");
            Console.WriteLine($"Название: {video.Title}");
            Console.WriteLine($"Описание: {video.Description}");
            Console.WriteLine($"Длительность: {video.Duration}");
            Console.WriteLine($"Дата загрузки: {video.UploadDate}");
            Console.WriteLine($"Автор: {video.Author}");
            Console.WriteLine("==========================");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении информации: {ex.Message}");
        }
    }
}

// Команда для скачивания видео
public class DownloadVideoCommand : ICommand
{
    private readonly string _videoUrl;
    private readonly string _outputPath;
    private readonly YoutubeClient _youtubeClient;

    public DownloadVideoCommand(string videoUrl, string outputPath = "video.mp4")
    {
        _videoUrl = videoUrl;
        _outputPath = outputPath;
        _youtubeClient = new YoutubeClient();
    }

    public async Task ExecuteAsync()
    {
        try
        {
            Console.WriteLine("Начинаем загрузку...");

            await _youtubeClient.Videos.DownloadAsync(
                _videoUrl,
                _outputPath,
                builder => builder.SetPreset(ConversionPreset.UltraFast)
            );

            Console.WriteLine($"Видео успешно скачано в: {_outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке видео: {ex.Message}");
        }
    }
}

// Класс-вызыватель команд
public class CommandInvoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public async Task ExecuteCommandAsync()
    {
        if (_command != null)
        {
            await _command.ExecuteAsync();
        }
        else
        {
            Console.WriteLine("Команда не установлена.");
        }
    }
}

// Основной класс программы
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("YouTube Video Processor");
        Console.WriteLine("Доступные команды:");
        Console.WriteLine("1. info <url> - Получить информацию о видео");
        Console.WriteLine("2. download <url> [output] - Скачать видео (по умолчанию: video.mp4)");
        Console.WriteLine("3. exit - Выйти из программы");

        var invoker = new CommandInvoker();

        while (true)
        {
            Console.Write("\nВведите команду: ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandName = parts[0].ToLower();

            try
            {
                switch (commandName)
                {
                    case "info":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Пожалуйста, укажите URL YouTube");
                            continue;
                        }
                        invoker.SetCommand(new GetVideoInfoCommand(parts[1]));
                        await invoker.ExecuteCommandAsync();
                        break;

                    case "download":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Пожалуйста, укажите URL YouTube");
                            continue;
                        }
                        var outputPath = parts.Length > 2 ? parts[2] : "video.mp4";
                        invoker.SetCommand(new DownloadVideoCommand(parts[1], outputPath));
                        await invoker.ExecuteCommandAsync();
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}