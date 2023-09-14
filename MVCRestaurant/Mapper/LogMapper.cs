using MVCRestaurant.Models;
using MVCRestaurant.ViewModels;

namespace MVCRestaurant.Mapper
{
    public class LogMapper
    {
        public static LogViewModel LogToVM(Log log)
        {
            return new LogViewModel
            {
                UserId = log.UserId,
                Description = log.Description,
                SubmitDate = log.SubmitDate,
                ErrorEncountered = log.ErrorEncountered,
            };
        }
    }
}
