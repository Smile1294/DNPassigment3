using System.ComponentModel.DataAnnotations;

namespace DNPAssigment1.Login
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]

        public int SecurityLvl { get; set; }
    }
}