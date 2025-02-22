using Hospital.DAL.Models;

namespace Hospital.PL.ViewModels
{
    public class NurseViewModel :EmployeeViewModel
    {

        //Navigational proparty = [Many]
        public int? RoomId { get; set; } 
        public Room? Room { get; set; }
    }
}
