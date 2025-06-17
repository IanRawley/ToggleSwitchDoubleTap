using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;

namespace ToggleSwitchDoubleTap.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public bool Value { get; set; } = false;

    public ObservableCollection<string> Messages { get; } = new();

        

    public MainViewModel()
    {
        
    }
   
    
}
