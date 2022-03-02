using System.ComponentModel.DataAnnotations;


namespace task_4_Solution.Models
{
    public class Animal
    {
        [Required(ErrorMessage = "Object id is required")]
        public int IdAnimal { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max length is 200")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Max length is 200")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MaxLength(200, ErrorMessage = "Max length is 200")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [MaxLength(200, ErrorMessage = "Max length is 200")]
        public string Area { get; set; }
    }
}