using System.Configuration;

namespace Core.DomainService
{
    public static class Utility
    {
        public static string GetAppSetting(string key)
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
