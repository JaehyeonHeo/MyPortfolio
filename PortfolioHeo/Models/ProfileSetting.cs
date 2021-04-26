using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioHeo.Models
{
    public class ProfileSetting
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "제목을 입력하세요!")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "내용을 입력하세요!")]
        [DataType(DataType.Text)]
        public string Contents { get; set; }

        public DateTime RegDate { get; set; }
    }
}
