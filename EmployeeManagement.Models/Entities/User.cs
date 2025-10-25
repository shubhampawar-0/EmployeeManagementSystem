﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Entities
{
    public class User
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation (optional, useful later)
        public Role Role { get; set; }


    }
}
