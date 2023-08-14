using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.infrastructure.read
{
    public interface IProductReadService
    {
        public ProductDto Find(Guid id);
    }
}
