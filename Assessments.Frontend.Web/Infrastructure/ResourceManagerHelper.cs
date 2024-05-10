using System.Reflection;
using System.Resources;

namespace Assessments.Frontend.Web.Infrastructure;

public static class ResourceManagerHelper
{
    public static ResourceManager Shared => new("Assessments.Frontend.Web.Resources.SharedResources", Assembly.GetExecutingAssembly());
}