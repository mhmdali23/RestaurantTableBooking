using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FileService : IFileService
    {
        private readonly ILoggerAdapter<FileService> _logger;

        public FileService(ILoggerAdapter<FileService> logger)
        {
            _logger = logger;
        }
        public async Task<string> ReadFileAsync(string path)
        {
            string? filePath = Path.Combine(AppContext.BaseDirectory, path);

            try
            {
                _logger.LogInformation($"Attempting to read file: {filePath}");

                //read file content
                string? content = await File.ReadAllTextAsync(filePath);

                return content;

            }
            catch (FileNotFoundException ex) 
            {
                _logger.LogError(ex,$"File not found: {filePath}. Exception: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"An error occurred while reading the file {filePath}. Exception: {ex.Message}");
                throw;
            }

        }
    }
}
