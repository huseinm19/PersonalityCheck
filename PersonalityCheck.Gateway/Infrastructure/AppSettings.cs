using System.ComponentModel.DataAnnotations;

namespace Evv.SelfRegistrationAuthGateway.Infrastructure
{
    public class AppSettings
    {
        [MaxLength(1000)]
        [DataType(DataType.Text)]
        public string BasePath { get; set; }
    }
}
