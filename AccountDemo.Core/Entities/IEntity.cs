using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Core.Entities
{
    public interface IEntity
    {
        void SetCreatedDate();
        void SetIsDeleted();
        void SetIsConfirmed();
    }
}
