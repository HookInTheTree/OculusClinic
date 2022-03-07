namespace Oculus_Clinic_Server.Data.Models
{
    public class Employeer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
