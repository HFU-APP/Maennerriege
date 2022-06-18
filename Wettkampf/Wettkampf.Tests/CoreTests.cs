// <copyright file="CoreTests.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Wettkampf.Core;
using Wettkampf.Views;
using NUnit.Framework;
using Xamarin.Forms;

namespace Wettkampf.Tests
{
  [TestFixture]
  public class CoreTests
  {
    [Test]
    public void TestSave()
    {
      var container = ContainerExtensions
        .CreateContainer()
        .RegisterWettkampfServices();

      var neueVereinPage = new NeuerVereinPage();

      container.RegisterInstance<Page>(neueVereinPage);

      neueVereinPage.Save_Clicked(null, EventArgs.Empty);
    }
  }
}