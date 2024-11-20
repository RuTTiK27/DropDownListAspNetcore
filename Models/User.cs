using System.ComponentModel.DataAnnotations;

namespace DropDownListAspNetcore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public int? Age { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
