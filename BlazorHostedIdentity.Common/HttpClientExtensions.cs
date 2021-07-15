﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Common
{
  public static class HttpClientExtensions
  {
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode)
        throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

      var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      //var dataAsStream = await response.Content.ReadAsStreamAsync();

      return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
  }
}