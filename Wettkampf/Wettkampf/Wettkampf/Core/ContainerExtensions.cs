// <copyright file="ContainerExtensions.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Net.Http;
using Wettkampf.Models;
using Wettkampf.Services;
using JetBrains.Annotations;
using SimpleInjector;

namespace Wettkampf.Core
{
  public static class ContainerExtensions
  {
    public static Container CreateContainer()
    {
      return new Container()
      {
        Options =
        {
          ResolveUnregisteredConcreteTypes = true,
          AllowOverridingRegistrations = true
        }
      };
    }

    public static Container RegisterWettkampfServices([NotNull] this Container container)
    {
      if (container is null) { throw new ArgumentNullException(nameof(container)); }

      container.RegisterSingleton<IDataStore<Disziplin>, DiszilpinDataStore>();
      container.RegisterSingleton<IDialogService, DialogService>();
      container.RegisterSingleton<IDisziplinSaver, DisziplinSaver>();
      container.RegisterSingleton<IWebService<Disziplin>, DisziplinWebService>();
      container.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();


            return container;
    }
  }
}