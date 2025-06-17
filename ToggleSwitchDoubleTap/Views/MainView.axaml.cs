using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Input.TextInput;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using ToggleSwitchDoubleTap.ViewModels;

namespace ToggleSwitchDoubleTap.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        this.AddHandler<KeyEventArgs>(KeyUpEvent, (o, e) =>
        {
            
                ViewModel?.Messages.Insert(0, $"KeyUp Detected: Key -> {e.Key} Modifiers -> {e.KeyModifiers} Handled -> {e.Handled}");
            
        }, handledEventsToo: true);
        this.AddHandler<KeyEventArgs>(KeyDownEvent, (o, e) =>
        {

            ViewModel?.Messages.Insert(0, $"KeyDown Detected: Key -> {e.Key} Modifiers -> {e.KeyModifiers} Handled -> {e.Handled}");

        }, handledEventsToo: true);

        this.AddHandler<TextInputMethodClientRequestedEventArgs>(TextInputMethodClientRequestedEvent, (o, e) =>
        {
            ViewModel?.Messages.Insert(0, $"IME Client Requested: Source -> {e.Source}, Client -> {e.Client}, Handled -> {e.Handled}");
        }, handledEventsToo: true);

        this.AddHandler<TextInputMethodClientRequeryRequestedEventArgs>(InputMethod.TextInputMethodClientRequeryRequestedEvent, (o, e) =>
        {
            ViewModel?.Messages.Insert(0, $"IME Client Requery Requested: Source -> {e.Source}, Handled -> {e.Handled}");
        }, handledEventsToo: true);
    }

    
}
