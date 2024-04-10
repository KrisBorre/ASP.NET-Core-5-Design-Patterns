﻿using System.Collections.Generic;

namespace WebApi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
