﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;

namespace Backend.DataObjects
{
    public class TodoItem : EntityData
    {
        public string UserId { get; set; }

        public string Text { get; set; }

        public bool Complete { get; set; }

        public string TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}