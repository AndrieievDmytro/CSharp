using System;
using System.ComponentModel.DataAnnotations;
public class Request_Order 
{
    [Required(ErrorMessage = "Product is required")]
    [Range(1,int.MaxValue)]
    public int IdProduct { get; set; }
    [Required(ErrorMessage = " Product is required")]
    [Range(1, int.MaxValue)]
    public int IdWarehouse { get; set; }
    [Required(ErrorMessage = "Amount is required")]
    [Range(1, int.MaxValue)]
    public int Amount { get; set; }
    [Required(ErrorMessage = "Data is required")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid data format")]
    public DateTime CreatedAt { get; set; }
}