﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using SophiApp.Contracts.Services;
using SophiApp.Contracts.ViewModels;
using SophiApp.Helpers;

namespace SophiApp.Services;

// For more information on navigation between pages see
// https://github.com/microsoft/TemplateStudio/blob/main/docs/WinUI/navigation.md
public class NavigationService : INavigationService
{
    private readonly IPageService pageService;
    private object? lastParameterUsed;
    private Frame? frame;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationService"/> class.
    /// </summary>
    /// <param name="pageService"><see cref="IPageService"/>.</param>
    public NavigationService(IPageService pageService)
    {
        this.pageService = pageService;
    }

    public event NavigatedEventHandler? Navigated;

    public Frame? Frame
    {
        get
        {
            if (frame == null)
            {
                frame = App.MainWindow.Content as Frame;
                RegisterFrameEvents();
            }

            return frame;
        }

        set
        {
            UnregisterFrameEvents();
            frame = value;
            RegisterFrameEvents();
        }
    }

    [MemberNotNullWhen(true, nameof(Frame), nameof(frame))]
    public bool CanGoBack => Frame != null && Frame.CanGoBack;

    public bool GoBack()
    {
        if (CanGoBack)
        {
            var vmBeforeNavigation = frame.GetPageViewModel();
            frame.GoBack();
            if (vmBeforeNavigation is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedFrom();
            }

            return true;
        }

        return false;
    }

    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false)
    {
        var pageType = pageService.GetPageType(pageKey);

        if (frame != null && (frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(lastParameterUsed))))
        {
            frame.Tag = clearNavigation;
            var vmBeforeNavigation = frame.GetPageViewModel();
            var navigated = frame.Navigate(pageType, parameter);
            if (navigated)
            {
                lastParameterUsed = parameter;
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }
            }

            return navigated;
        }

        return false;
    }

    private void RegisterFrameEvents()
    {
        if (frame != null)
        {
            frame.Navigated += OnNavigated;
        }
    }

    private void UnregisterFrameEvents()
    {
        if (frame != null)
        {
            frame.Navigated -= OnNavigated;
        }
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame)
        {
            var clearNavigation = (bool)frame.Tag;
            if (clearNavigation)
            {
                frame.BackStack.Clear();
            }

            if (frame.GetPageViewModel() is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(e.Parameter);
            }

            Navigated?.Invoke(sender, e);
        }
    }
}
