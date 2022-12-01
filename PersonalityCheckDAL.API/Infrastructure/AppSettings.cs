using System.ComponentModel.DataAnnotations;

namespace Evv.SelfRegistrationDAL.API.Infrastructure
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

    }
    public class ConnectionStrings
    {
        [MaxLength(1000)]
        [DataType(DataType.Text)]
        public string EVVSelfRegistrationDB { get; set; }
    }
}
