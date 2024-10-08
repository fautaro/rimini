﻿namespace webapi.Application.Store.Queries.DTOs;
public class ProductDTO
{
    public long ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ProductImage { get; set; }
}
