﻿namespace test.Endpoints.CartItems.Models;

public class CartItemResponse
{
    public int Id { get; set; } 
    public int ProductId { get; set; } 
    public string ProductName { get; set; } 
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalSum => Quantity * Price;
}
