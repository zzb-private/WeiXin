
using Microsoft.Extensions.FileProviders;

namespace ZZB.BLL.Extensions
{
    public static class IFileProviderExtensions
    {
        public static string GetRoot(this IFileProvider provider)
        {
            return provider.GetFileInfo("/").PhysicalPath;

        }
    }
}
