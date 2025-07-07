﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
using System.Runtime.Serialization;
using Dock.Model.Controls;
using Dock.Model.Prism.Core;

namespace Dock.Model.Prism.Controls;

/// <summary>
/// Docking panel dock.
/// </summary>
[DataContract(IsReference = true)]
public class DockDock : DockBase, IDockDock
{        
    private bool _lastChildFill = true;

    /// <inheritdoc/>
    [DataMember(IsRequired = false, EmitDefaultValue = true)]
    public bool LastChildFill
    {
        get => _lastChildFill;
        set => SetProperty(ref _lastChildFill, value);
    }
}
