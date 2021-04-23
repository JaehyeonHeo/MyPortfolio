using System.ComponentModel.DataAnnotations;

namespace PortfolioHeo.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Email을 입력하세요")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password를 입력하세요")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Grade { get; set; }
    }
}
