using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Core.Entities
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public BaseEntity()
        {
            SetCreatedDate();
            SetIsConfirmed();
            SetIsDeleted();
        }
        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
        public void SetIsDeleted()
        {
            IsDeleted = false;
        }
        public void SetIsConfirmed()
        {
            IsConfirmed = true;
        }
    }
}
