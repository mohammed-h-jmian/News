using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace News.Core.Dtos.ClassificationDtos
{
    public class CreateClassificationDto
    {
        [Required(ErrorMessage = "The Classification name field is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
