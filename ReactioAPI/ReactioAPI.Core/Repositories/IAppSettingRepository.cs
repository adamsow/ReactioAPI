﻿using ReactioAPI.Core.Domain;
using System.Threading.Tasks;

namespace ReactioAPI.Core.Repositories
{
    public interface IAppSettingRepository
    {
        Task<AppSetting> GetByKeyAsync(string key);
    }
}
