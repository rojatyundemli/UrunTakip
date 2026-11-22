using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{
    public class Category
    {

       public int Id { get; set; }

        public string Name { get; set; }

        public int? UpCategoryId { get; set; }
        public String? UpCategoryName { get; set; }
        public string Description { get; set; }

        public bool isActive { get; set; }
        public String CategoryCode { get; set; }
        public int CategoryLevel { get; set; }


    }
}
