using PersonalityCheck.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityCheck.BLL.Interface
{
    public interface IPersonalityCheckDALService
    {
        Task<List<Question>> GetAllQuestions();
        Task<List<Answer>> GetAllAnswers();
        Task<bool> AddNewUser(User user);
    }
}
