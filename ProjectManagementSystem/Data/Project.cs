using System.ComponentModel.DataAnnotations;

namespace projectManagementSystem.Data
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, Enter a Ctegory first")]
        public string  Category { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int Duration { get; set; }
        public DateTime DateofAddingItem { get; set; }
        public Project()
        {
            DateofAddingItem = DateTime.Now.Date;
        }

    }

}
