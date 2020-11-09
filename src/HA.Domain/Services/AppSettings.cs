using HA.WebAPI.ConfigurationOptions;

namespace HA.Domain.Services
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public ApplicationDetail ApplicationDetail { get; set; }

    }
}
