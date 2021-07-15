using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class ProductDetails
  {
    public Product Product { get; set; } = new Product {
      Reviews = new List<Review>(),
      Declaration = new Declaration(),
      QAs = new List<QA>()
    };

    [Inject] public IProductHttpRepository ProductRepository { get; set; }
    [Parameter] public Guid ProductId { get; set; }

    private int _currentRating;
    private int _reviewCount;
    private int _questionCount;

    protected override async Task OnInitializedAsync()
    {
      Product = await ProductRepository.GetProduct(ProductId);
      _reviewCount = Product.Reviews.Count;
      _questionCount = Product.QAs.Count;
      _currentRating = CaculateRating();
    }

    private int CaculateRating()
    {
      var rating = Product.Reviews.Any() ? Product.Reviews.Average(r => r.Rate) : 0;
      return Convert.ToInt32(Math.Round(rating));
    }

    private void RatingValueChanged(int value) => Console.WriteLine($"The product is rated with {value} thumbs.");
  }
}