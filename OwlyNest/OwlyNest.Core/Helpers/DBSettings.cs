using OwlyNest.Core.Interfaces.Helpers;

namespace OwlyNest.Core.Helpers
{
    public class DBSettings : IDBSettings
    {
        public string OwlyConnectionString { get; set; }
    }
}
