﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Input.TextInput;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using System.Runtime.CompilerServices;
using ToggleSwitchDoubleTap.ViewModels;

namespace ToggleSwitchDoubleTap.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        /*
        this.AddHandler<KeyEventArgs>(KeyUpEvent, (o, e) =>
        {
            
                ViewModel?.Messages.Insert(0, $"KeyUp Detected: Key -> {e.Key} Modifiers -> {e.KeyModifiers} Handled -> {e.Handled}");
            
        }, handledEventsToo: true);
        this.AddHandler<KeyEventArgs>(KeyDownEvent, (o, e) =>
        {

            ViewModel?.Messages.Insert(0, $"KeyDown Detected: Key -> {e.Key} Modifiers -> {e.KeyModifiers} Handled -> {e.Handled}");

        }, handledEventsToo: true);
        */
        this.AddHandler<TextInputMethodClientRequestedEventArgs>(TextInputMethodClientRequestedEvent, (o, e) =>
        {
            ViewModel?.Messages.Insert(0, $"Tunnel IME Client Requested: Source -> {e.Source}, Client -> {e.Client}, Handled -> {e.Handled}");
            e.Client = null;
            e.Handled = true;
        }, handledEventsToo: true);
        /*
        this.AddHandler<TextInputMethodClientRequestedEventArgs>(TextInputMethodClientRequestedEvent, (o, e) =>
        {
            ViewModel?.Messages.Insert(0, $"Bubble IME Client Requested: Source -> {e.Source}, Client -> {e.Client}, Handled -> {e.Handled}");
            
        }, routes: RoutingStrategies.Bubble, handledEventsToo: true);

        this.AddHandler<TextInputMethodClientRequeryRequestedEventArgs>(InputMethod.TextInputMethodClientRequeryRequestedEvent, (o, e) =>
        {
            ViewModel?.Messages.Insert(0, $"IME Client Requery Requested: Source -> {e.Source}, Handled -> {e.Handled}");
        }, handledEventsToo: true);
        */

        this.AddHandler<GotFocusEventArgs>(GotFocusEvent, (o, e) =>
        {

            ViewModel?.Messages.Insert(0, $"GotFocus Detected: Source -> {e.Source} Handled -> {e.Handled}");

        }, handledEventsToo: true);

        

    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        var top = TopLevel.GetTopLevel(this);
        top.AddHandler<GotFocusEventArgs>(GotFocusEvent, (o, e) => ViewModel?.Messages.Insert(0, $"Toplevel GotFocus Detected: Source -> {e.Source} Handled -> {e.Handled}"));
        base.OnLoaded(e);
        Dispatcher.UIThread.Post(() => TB1.Focus(NavigationMethod.Tab), DispatcherPriority.Background); 
    }
}
