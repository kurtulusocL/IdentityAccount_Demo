using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Entities.Abstract
{
    public interface IApplicationUser
    {
        void SetCreatedDate();
        void SetIsDeleted();
        void SetIsConfirmed();
    }
}
