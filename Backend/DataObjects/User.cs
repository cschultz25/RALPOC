﻿using System.ComponentModel.DataAnnotations;

namespace Backend.DataObjects
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
    }
}