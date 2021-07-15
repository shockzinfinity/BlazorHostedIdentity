using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorHostedIdentity.Shared
{
  public class Product
  {
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required field")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Supplier is required field")]
    public string Supplier { get; set; }

    [Required(ErrorMessage = "Price is required field")]
    [Range(1, double.MaxValue, ErrorMessage = "Value for the Price can't be lower than 1")]
    public double Price { get; set; }

    public string ImageUrl { get; set; }
    public DateTime ManufactureDate { get; set; }

    public ICollection<Review> Reviews { get; set; }
    public ICollection<QA> QAs { get; set; }
    public Declaration Declaration { get; set; }
  }
}