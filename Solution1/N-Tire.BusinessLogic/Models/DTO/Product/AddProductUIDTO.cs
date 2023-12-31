﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Models.DTO.Product
{
    public class AddProductUIDTO
    {
        [Required]
        public int CatagoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
