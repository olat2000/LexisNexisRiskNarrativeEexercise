using Microsoft.Extensions.Configuration;

namespace LexisNexisRiskNarrativeEexercise
{
    public class ReadJsonData
    {
        private IConfigurationRoot _config;
        public ReadJsonData()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json");
            _config = builder.Build();
        }

        public string GetJsonData(string key) => _config[key]!;
    }
}
