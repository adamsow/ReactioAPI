using System.ComponentModel.DataAnnotations;

namespace ReactioAPI.Core.Domain
{
    public class AppSetting
    {
        public AppSetting()
        {}

        public AppSetting(string appSettingKey, string appSettingValue)
        {
            AppSettingKey = appSettingKey;
            AppSettingValue = appSettingValue;
        }

        [Key]
        public string AppSettingKey { get; protected set; }

        public string AppSettingValue { get; protected set; }
    }
}
