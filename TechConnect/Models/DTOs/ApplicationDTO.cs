﻿namespace TechConnect.Models.DTOs
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string Status { get; set; } = null!;
    }
}
