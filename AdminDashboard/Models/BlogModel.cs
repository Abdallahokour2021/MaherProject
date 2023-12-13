﻿using ServiceLayer.DTO;
using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Models
{
    public class BlogModel
    {
        public int Id { get; set; }

        [Display(Name ="Title")]
        [Required(ErrorMessage ="Title Field Is REQUIRED")]
        public string? Title { get; set; }

        [Display(Name = "Main Image")]
        public string? BlogMainImage { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Title Field Is REQUIRED")]
        public string? BlogMainText { get; set; }

        public List<IFormFile>? Image { get; set;}

        public IFormFile? CardImage { get; set; }
        public string? CardImageUrl { get; set; }

        public IFormFile? Video { get; set; }

        public string? VideoUrl { get; set; }

        public List<ImageInfo>? ImageInfo { get; set; }
        [Required(ErrorMessage = "Title Field Is REQUIRED")]
        public string? SecondaryDescription { get; set; }

        [Display(Name = "Share")]
        [Required(ErrorMessage = "Title Field Is REQUIRED")]
        public bool IsPublished { get; set; }

        [Required(ErrorMessage = "Title Field Is REQUIRED")]
        public string? ShortDescription { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
