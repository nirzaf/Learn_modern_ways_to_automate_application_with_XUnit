﻿namespace EATestProject.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ProductType ProductType { get; set; }
}

public enum ProductType
{
    CPU,
    MONITOR,
    PERIPHARALS,
    EXTERNAL
}