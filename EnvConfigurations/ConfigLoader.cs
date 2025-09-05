using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NSENVSettings;

namespace NSConfigLoader
{
    public class ConfigLoader
    {
        private Dictionary<string, EnvironmentProperties>? environments;

        public ConfigLoader(string configPath)
        {
            string json = File.ReadAllText(configPath);

            environments = JsonConvert.DeserializeObject<Dictionary<string, EnvironmentProperties>>(json);
            if (environments == null)
                throw new InvalidOperationException("Failed to deserialize json");
        }

        public EnvironmentProperties GetEnvironment(string envKey)
        {
            if (environments.ContainsKey(envKey))
                return environments[envKey];
            throw new ArgumentException($"Environment key '{envKey}' not found.");
        }

        public EnvironmentProperties LoadConfigDetails()
        {
            var loader =   new ConfigLoader("environments.json");
            var selectedEnv = loader.GetEnvironment("testenv_chrome"); // choose desired env
            Type tp = selectedEnv.GetType();
            return selectedEnv;
        }
    }
}