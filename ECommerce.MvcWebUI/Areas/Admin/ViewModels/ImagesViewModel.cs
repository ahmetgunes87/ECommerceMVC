using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.MvcWebUI.Areas.Admin.ViewModels
{
    public class ImagesViewModel
    {
        public List<ProductImage> ProductImages { get; set; }
        [Required(ErrorMessage = "Lütfen en az 1 adet resim seçiniz.")]
        [Display(Name = "Resim Yükle")]
        public HttpPostedFileBase[] images { get; set; }
    }
}