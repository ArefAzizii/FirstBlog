using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_DataLayer.Entities
{
    public class User:BaseEntity
    {
      
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRole UserRole { get; set; }

        #region Relations
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion
    }
    public enum UserRole
    {
        Admin,
        Writer,
        User
    }
}
