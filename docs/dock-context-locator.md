# Context locators

Dock assigns a `DataContext` to every dockable when a layout is initialized or loaded. The objects are resolved through two properties on `IFactory`:
`ContextLocator` and `DefaultContextLocator`.

## `ContextLocator` dictionary

`ContextLocator` is a `Dictionary<string, Func<object?>>` mapping an identifier to
a factory method. Each entry returns the object that becomes the `DataContext` of
the dockable with the same `Id`.
Populate this dictionary before calling `InitLayout` or loading a layout with
`DockSerializer`.

```csharp
public override void InitLayout(IDockable layout)
{
    ContextLocator = new Dictionary<string, Func<object?>>
    {
        ["Document1"] = () => new DocumentViewModel(),
        ["Tool1"] = () => new Tool1ViewModel(),
    };

    base.InitLayout(layout);
}
```

During `InitDockable` the factory looks up the dockable `Id` in
`ContextLocator` and assigns the returned object to `dockable.Context`.

## `DefaultContextLocator` fallback

`DefaultContextLocator` is a `Func<object?>` invoked when
`ContextLocator` has no entry for the requested identifier. Use it to provide a
common fallback or to integrate with a dependency injection container.

```csharp
DefaultContextLocator = () => _services.GetService<MainViewModel>();
```

When `GetContext` cannot resolve a specific id it will call this delegate. If it
returns `null`, the dockable keeps its existing `Context` (often `null`).

## Why it matters

Dockable views rely on their `DataContext` to function correctly. When loading a
layout that references custom documents or tools, the factory must be able to
recreate those view models. Register each type in `ContextLocator` and provide a
default via `DefaultContextLocator` so that unknown ids do not break the layout.

These locators work alongside `DockableLocator` and `HostWindowLocator` which
resolve dockable instances and host windows. Ensure all locators are populated
before deserializing layouts or initializing new ones.

For a high level overview of the factory API see the
[Advanced guide](dock-advanced.md) and [Reference guide](dock-reference.md).
