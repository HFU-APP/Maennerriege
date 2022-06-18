﻿// <copyright file="VereineWebService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wettkampf.Models;
using Newtonsoft.Json;

namespace Wettkampf.Services
{
  /// <summary>
  /// Example web service showing the usage of the HttpClient.
  /// </summary>
  public class VereineWebService : IWebService<Verein>
  {
    public VereineWebService(HttpClient client)
    {
      _client = client ?? throw new ArgumentNullException(nameof(client));

      // Set a base-address so we don't need to repeat ourselves.
      _client.BaseAddress = new Uri("http://localhost:3000");

      // Set global headers for all requests.
      // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "JWTToken");
    }

    public async Task<IEnumerable<Verein>> Get()
    {
      var result = await _client.GetAsync("/vereine/");

      if (result.IsSuccessStatusCode)
      {
        var stringResult = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Verein>>(stringResult);
      }

      throw new InvalidOperationException("Could not load albums from server.");
    }

    public async Task<int> Post(Verein toPost)
    {
      var serializedObject = JsonConvert.SerializeObject(toPost);
      var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
      var result = await _client.PostAsync("/api/something", content);

      // Same handling as with get. Check the status code and read out the result.
      throw new NotImplementedException();
    }

    private readonly HttpClient _client;
  }
}