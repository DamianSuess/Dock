# Dock Markup Extensions

Dock ships with two simple markup extensions that complement Avalonia's XAML loader. They are distributed in the `Dock.MarkupExtension` package and can be used independently from the docking system.

## `LoadExtension`

`LoadExtension` loads a XAML fragment from a URI at runtime and returns the resulting object instance. This is handy when you want to keep small pieces of XAML in separate files without creating data templates.

```xaml
<TextBlock Text="{markup:Load 'resm:Views/StatusView.axaml?assembly=MyApp'}"/>
```

The URI is resolved relative to the current `IUriContext`. Any element type can be loaded. When used as a binding the created object becomes the property value.

## `ReferenceExtension`

`ReferenceExtension` returns an element by name from the current `INameScope`. It mirrors the behaviour of WPF's `x:Reference` markup extension.

```xaml
<StackPanel>
  <Button x:Name="OkButton" Content="OK"/>
  <TextBlock Text="{markup:Reference OkButton.Content}"/>
</StackPanel>
```

The extension searches the nearest name scope for an element called `OkButton` and returns it. This can be used to bind properties between two elements declared in the same scope.

Both extensions reside in the `Avalonia.MarkupExtension` namespace and can be imported in XAML using `xmlns:markup="clr-namespace:Avalonia.MarkupExtension"`.

For an overview of all guides see the [documentation index](README.md).
