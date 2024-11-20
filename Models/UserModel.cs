using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropDownListAspNetcore.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public List<SelectListItem> UsersList { get; set; }
    }
}
