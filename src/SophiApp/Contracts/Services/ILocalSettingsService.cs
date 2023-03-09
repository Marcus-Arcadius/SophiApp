﻿// <copyright file="ILocalSettingsService.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

public interface ILocalSettingsService
{
    Task<T?> ReadSettingAsync<T>(string key);

    Task SaveSettingAsync<T>(string key, T value);
}