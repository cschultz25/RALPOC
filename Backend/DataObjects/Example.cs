﻿using System;
using Microsoft.Azure.Mobile.Server;

namespace Backend.DataObjects
{
    public class Example : EntityData
    {
        public string GroupId { get; set; }
        public string StringField { get; set; }
        public int IntField { get; set; }
        public double DoubleField { get; set; }
        public DateTimeOffset DateTimeField { get; set; }
    }
}