﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOKApi.Models
{
    public class Like
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IDPost { get; set; }
        public int IDUser { get; set; }
        public Nullable<System.DateTime> DateOfLike { get; set; }

        public  Post? Post { get; set; }
        public  User? User { get; set; }
    }
}
