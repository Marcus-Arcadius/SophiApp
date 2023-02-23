﻿// <copyright file="App.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using SophiApp.Activation;
using SophiApp.Contracts.Services;
using SophiApp.Helpers;
using SophiApp.Models;
using SophiApp.Notifications;
using SophiApp.Services;
using SophiApp.ViewModels;
using SophiApp.Views;

namespace SophiApp;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.

/// <summary>
/// <inheritdoc/>
/// </summary>
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices((context, services) =>
            {
                // Default Activation Handler
                services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

                // Other Activation Handlers
                services.AddTransient<IActivationHandler, AppNotificationActivationHandler>();

                // Services
                services.AddSingleton<IAppNotificationService, AppNotificationService>();
                services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
                services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                services.AddTransient<INavigationViewService, NavigationViewService>();

                services.AddSingleton<IActivationService, ActivationService>();
                services.AddSingleton<IPageService, PageService>();
                services.AddSingleton<INavigationService, NavigationService>();
                services.AddSingleton<IFileService, FileService>();

                // Views and ViewModels
                services.AddTransient<SettingsViewModel>();
                services.AddTransient<SettingsPage>();
                services.AddTransient<ProViewModel>();
                services.AddTransient<ProPage>();
                services.AddTransient<ContextMenuViewModel>();
                services.AddTransient<ContextMenuPage>();
                services.AddTransient<SecurityViewModel>();
                services.AddTransient<SecurityPage>();
                services.AddTransient<TaskSchedulerViewModel>();
                services.AddTransient<TaskSchedulerPage>();
                services.AddTransient<UwpViewModel>();
                services.AddTransient<UwpPage>();
                services.AddTransient<SystemViewModel>();
                services.AddTransient<SystemPage>();
                services.AddTransient<PersonalizationViewModel>();
                services.AddTransient<PersonalizationPage>();
                services.AddTransient<PrivacyViewModel>();
                services.AddTransient<PrivacyPage>();
                services.AddTransient<ShellPage>();
                services.AddTransient<ShellViewModel>();

                // Configuration
                services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
            })
            .Build();

        GetService<IAppNotificationService>().Initialize();
        UnhandledException += App_UnhandledException;
    }

    /// <summary>
    /// Gets MainWindow.
    /// </summary>
    public static WindowEx MainWindow { get; } = new MainWindow();

    /// <summary>
    /// Gets <see cref="IHost"/>.
    /// </summary>
    public IHost Host
    {
        get;
    }

    /// <summary>
    /// Get <see cref="IHost"/> servise.
    /// </summary>
    /// <typeparam name="T">service type.</typeparam>
    public static T GetService<T>()
        where T : class
    {
        if ((Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        _ = GetService<IAppNotificationService>()
            .Show(string.Format("AppNotificationSamplePayload".GetLocalized(), AppContext.BaseDirectory));

        await GetService<IActivationService>().ActivateAsync(args);
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}
