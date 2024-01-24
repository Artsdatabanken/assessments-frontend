using System;
using System.ComponentModel;
using System.Resources;

namespace Assessments.Shared.Helpers;

public class LocalizedDescriptionAttribute : DescriptionAttribute
{
    private readonly string _resourceKey;
    
    private readonly ResourceManager _resource;
    
    public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
    {
        _resource = new ResourceManager(resourceType);
        _resourceKey = resourceKey;
    }

    public override string Description
    {
        get
        {
            var displayName = _resource.GetString(_resourceKey);

            return !string.IsNullOrEmpty(displayName) ? displayName : _resourceKey;
        }
    }
}