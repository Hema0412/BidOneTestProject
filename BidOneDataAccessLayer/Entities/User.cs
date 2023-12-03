using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOneDataAccessLayer.Entities
{

    /// <summary>
    /// Enitity Objects for the User Addition 
    /// </summary>
    public  class UserEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }= DateTime.Now;
    }
}
