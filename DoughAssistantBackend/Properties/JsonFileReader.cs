using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoughAssistantBackend.Properties
{
    public static class JsonFileReader
    {
        public static async Task<T> ReadAsync<T>(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}