using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DockInpcSample.Views;

public partial class DockableOptionsView : UserControl
{
    public DockableOptionsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
