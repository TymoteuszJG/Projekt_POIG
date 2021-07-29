using System;
using System.Globalization;

namespace MultiLanguage.Infrastructure
{
    /// <summary>
    /// Provides a mechanism for retrieving an object that encapsulates the information
    /// needed to support multiple cultures
    /// </summary>
    public interface ISupportedCultureInfo
    {
        CultureInfo Culture { get; }
        IFormatProvider FormatProvider { get; }
        string DisplayName { get; }
        string GetString(string name);
        void Release();
    }
}
