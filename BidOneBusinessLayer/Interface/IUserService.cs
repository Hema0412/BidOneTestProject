using BidOneDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOneBusinessLayer.Interface
{

    /// <summary>
    /// Interface to implement JSON file generation
    /// </summary>
    public interface IUserService
    {
        public bool addUser(UserEntity user);
    }
}
