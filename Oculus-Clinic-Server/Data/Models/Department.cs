namespace Oculus_Clinic_Server.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employeer> Employeers { get; set; }
    }
}
