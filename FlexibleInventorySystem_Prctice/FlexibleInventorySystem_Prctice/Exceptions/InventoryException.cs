using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Exceptions
{
    public class InventoryException:Exception
    {
        public InventoryException():base()
        {
                
        }
        public InventoryException(string errorMessage) : base(errorMessage) { }
       
    }
}
