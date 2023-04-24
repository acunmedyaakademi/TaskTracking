using System.ComponentModel.DataAnnotations;

namespace TaskTracking.Models
{
    public class PassCode
    {
        public int Id { get; set; }
        public Users users { get; set; }
        public string Email { get; set; }

        [StringLength(6)]
        public string Mail_code { get; set; }   
    }
}
