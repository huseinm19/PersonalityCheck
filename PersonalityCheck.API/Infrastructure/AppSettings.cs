using System.ComponentModel.DataAnnotations;

namespace PersonalityCheck.API.Infrastructure
{
    public class AppSettings
    {
        [MaxLength(1000)]
        [DataType(DataType.Text)]
        public string SelfRegistrationDALURL { get; set; }
    }
}
