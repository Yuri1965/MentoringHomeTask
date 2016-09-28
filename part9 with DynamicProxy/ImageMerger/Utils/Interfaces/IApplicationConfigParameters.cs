using System;
using System.Collections.Generic;

namespace ImageMerger
{
    public interface IApplicationConfigParameters
    {
        bool IsConfigParamLoaded();
        double GetDelayTime();
        List<KeyValuePair<string, string>> GetListInputOutputDirectoriesPair();
    }
}
