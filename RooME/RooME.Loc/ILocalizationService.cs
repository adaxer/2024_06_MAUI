using System.Globalization;

namespace RooME.Loc;
public interface ILocalizationService
{
    string Get(string key, string defaultValue="?loc?");
    CultureInfo CurrentCulture { get; set; }
}
