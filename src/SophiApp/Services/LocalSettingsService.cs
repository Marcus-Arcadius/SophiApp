﻿namespace SophiApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using SophiApp.Contracts.Services;
    using SophiApp.Helpers;
    using SophiApp.Models;
    using Windows.Storage;

    /// <inheritdoc/>
    public class LocalSettingsService : ILocalSettingsService
    {
        private const string DefaultApplicationDataFolder = "SophiApp/ApplicationData";
        private const string DefaultLocalSettingsFile = "LocalSettings.json";

        private readonly string applicationDataFolder;
        private readonly IFileService fileService;
        private readonly string localApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string localSettingsFile;
        private readonly LocalSettingsOptions options;
        private bool isInitialized;
        private IDictionary<string, object> settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalSettingsService"/> class.
        /// </summary>
        /// <param name="fileService"><see cref="IFileService"/>.</param>
        /// <param name="options"><see cref="LocalSettingsOptions"/>.</param>
        public LocalSettingsService(IFileService fileService, IOptions<LocalSettingsOptions> options)
        {
            this.fileService = fileService;
            this.options = options.Value;

            applicationDataFolder = Path
                .Combine(localApplicationData, this.options.ApplicationDataFolder ?? DefaultApplicationDataFolder);

            localSettingsFile = this.options.LocalSettingsFile ?? DefaultLocalSettingsFile;
            settings = new Dictionary<string, object>();
        }

        /// <inheritdoc/>
        public async Task<T?> ReadSettingAsync<T>(string key)
        {
            if (RuntimeHelper.IsMSIX)
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out var obj))
                {
                    return await Json.ToObjectAsync<T>((string)obj);
                }
            }
            else
            {
                await InitializeAsync();

                if (settings != null && settings.TryGetValue(key, out var obj))
                {
                    return await Json.ToObjectAsync<T>((string)obj);
                }
            }

            return default;
        }

        /// <inheritdoc/>
        public async Task SaveSettingAsync<T>(string key, T value)
        {
            if (RuntimeHelper.IsMSIX)
            {
                ApplicationData.Current.LocalSettings.Values[key] = await Json.SerializeAsync(value);
            }
            else
            {
                await InitializeAsync();

                settings[key] = await Json.SerializeAsync(value);

                await Task.Run(() => fileService.Save(applicationDataFolder, localSettingsFile, settings));
            }
        }

        private async Task InitializeAsync()
        {
            if (!isInitialized)
            {
                settings = await Task.Run(() => fileService.Read<IDictionary<string, object>>(applicationDataFolder, localSettingsFile))
                    ?? new Dictionary<string, object>();

                isInitialized = true;
            }
        }
    }
}