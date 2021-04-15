using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.DTO.Application
{

    public interface IStringLocalizerFactoryWithDefaultResourceSupport
    {
        //[CanBeNull]
        IStringLocalizer CreateDefaultOrNull();
    }
}
