using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace News.Core.Dtos.NewsDtos
{
    public class CreateNewsDto
    {
        [Required(ErrorMessage = "The News name field is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The News Description field is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The News Classification field is required.")]
        [Display(Name = "Classification")]
        public int ClassificationId { get; set; }

        [Required(ErrorMessage = "An Image file must be provided.")]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
