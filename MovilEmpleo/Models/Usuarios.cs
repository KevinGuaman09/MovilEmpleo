﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MovilEmpleo.Models
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(55)]
        public string nombre { get; set; }
        [MaxLength(100)]
        public string usuario { get; set; }
        [MaxLength(100)]
        public string password { get; set; }
    }
}
