using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.UI;

namespace WebAppECart.ViewModel
{
    public class ItemView
    {
        [Key]
        public int ItemId { set; get; }
        [Required]
        [DisplayName("Enter Item Name") ]
        [StringLength(10,MinimumLength =4)]
        public string ItemName { set; get; }
        [Required]
        [DisplayName("enter description")]
        [StringLength(100,MinimumLength =4)]
        public string Description { set; get; }
        [Required]
        [DisplayName("Cetagory")]
        public int CategoryId { set; get; }
        public string ImagePath { set; get; }
        [Required]
        [DisplayName("Enter the cost of item")]
        public decimal ItemPrice { set; get; }

        public IEnumerable<SelectListItem> CategorySelectListItem { set; get; }
    }
}

