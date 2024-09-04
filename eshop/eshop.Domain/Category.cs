using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set ; }
        public string Name { get; set; }

        public IList<Product> Products { get; set; }
    }
}
