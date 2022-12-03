using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalityCheck.Tests.Models
{
    public class ErrorTestModel
    {
        public string errorMessage;
        public string description;
        public string details;
        public string ErrorMessage { get { return errorMessage; } set { errorMessage = "The 422 Unprocesable entity indicates that the action could not be processed properly due to invalid data provided."; } }
        public string Description { get { return description; } set { description = "The 422 Unprocesable entity indicates that the action could not be processed properly due to invalid data provided."; } }
        public object Details { get { return details; } set { details = "The 422 Unprocesable entity indicates that the action could not be processed properly due to invalid data provided."; } }
    }
}
