﻿using ApiEBooks.Dto;
using System.ComponentModel.DataAnnotations;

namespace ApiEBooks.Models.Dto
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        

    }
}