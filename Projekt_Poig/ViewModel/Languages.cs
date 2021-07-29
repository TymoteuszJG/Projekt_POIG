using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Resources;
using System.Globalization;
using MultiLanguage.Infrastructure;


namespace Projekt_Poig.ViewModel
{
    using BaseClass;
    using Model;
    

    class Languages : ISupportedCultureInfo
    {

        private readonly CultureInfo _culture;
        private ResourceManager _resourceManager;
        public Languages(CultureInfo culture, ResourceManager resourceManager)
        {
            _culture = culture;
            _resourceManager = resourceManager;
        }
        public CultureInfo Culture { get { return _culture; } }
        public string GetString(string name)
        {
            if (_resourceManager != null)
            {
                return _resourceManager.GetString(name);
            }
            return name;
        }
        public void Release()
        {
            if (_resourceManager != null)
            {
                _resourceManager.ReleaseAllResources();
                _resourceManager = null;
            }
        }
        public IFormatProvider FormatProvider { get { return _culture; } }
        public string DisplayName { get { return _culture.DisplayName; } }
        public override string ToString()
        {
            return _culture.DisplayName;
        }

    }
}
