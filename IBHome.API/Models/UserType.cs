﻿using System.ComponentModel.DataAnnotations;

namespace IBHome.API.Models
{
    public class UserType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
