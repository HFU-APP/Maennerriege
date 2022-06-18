// <copyright file="CoreTests.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using FakeItEasy;
using Wettkampf.Core;
using Wettkampf.Views;
using NUnit.Framework;
using Wettkampf.Models;
using Wettkampf.Services;
using Xamarin.Forms;

namespace Wettkampf.Tests
{
  [TestFixture]
  public class CoreTests
  {
    [Test]
    public async Task TestSaveEmptyAlbum()
{
      var container = ContainerExtensions
        .CreateContainer()
        .RegisterWettkampfServices();

      var dialogService = A.Fake<IDialogService>();

      container.RegisterInstance(dialogService);

      var vereinSaver = container.GetInstance<IVereinSaver>();

      var album = new Verein();

      Assert.That(await vereinSaver.TrySaveAsync(album), Is.False);
      A.CallTo(() => dialogService.Show(A<string>.Ignored, A<string>.Ignored)).MustHaveHappenedOnceExactly();
}
  }
}