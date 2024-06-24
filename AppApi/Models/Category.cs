using System.ComponentModel.DataAnnotations;

namespace AppApi.Models
{
    public class Category : BaseEntity
    {
        [StringLength(10)]
        public string Name { get; set; }
    }
}
