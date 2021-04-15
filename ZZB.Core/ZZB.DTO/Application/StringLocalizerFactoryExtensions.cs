using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.DTO.Application
{
    public static class StringLocalizerFactoryExtensions
    {
        public static IStringLocalizer CreateDefaultOrNull(this IStringLocalizerFactory localizerFactory)
        {
            return (localizerFactory as IStringLocalizerFactoryWithDefaultResourceSupport)
                ?.CreateDefaultOrNull();
        }
    }
}
