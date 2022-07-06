// <copyright file="CoreTests.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using FakeItEasy;
using Wettkampf.Core;
using Wettkampf.Views;
using NUnit.Framework;
using SimpleInjector;
using Turnverein.ViewModels;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Tests
{
  [TestFixture]
  public class CoreTests
  {
    [Test]
    public async Task TestSaveEmptyPersonList()
    {
      var container = ContainerExtensions
        .CreateContainer()
        .RegisterWettkampfServices();

      var dialogService = A.Fake<IDialogService>();

      container.RegisterInstance(dialogService);

      var vereinSaver = container.GetInstance<IVereinSaver>();

      var verein = new Verein();

      Assert.That(await vereinSaver.TrySaveAsync(verein), Is.False);
      A.CallTo(() => dialogService.Show(A<string>.Ignored, A<string>.Ignored)).MustHaveHappenedOnceExactly();
    }

        //[Test]
        //public async Task TestInserPerson()
        //{


        //    Verein verein = new Verein();

        //    ListViewModelBase<Verein, VereineViewModel> a = new ListViewModelBase<Verein, VereineViewModel>();
        //    int old = a.Items.Count;

        //    VereineViewModel b = new VereineViewModel();
        //    b.Items.Add(verein);

        //    int neu = a.Items.Count;

        //    Assert.IsTrue(neu == old + 1);
        //}

        [Test]
        public async Task TestLogin()
        {
            var container = ContainerExtensions
                .CreateContainer()
                .RegisterWettkampfServices();


            var dialogService = A.Fake<IDialogService>();

            App.Services.RegisterInstance(dialogService);

            LoginViewModel a = new LoginViewModel();
            //bool c = await a.checkLogin("Admin", "admin");


            Assert.That(await a.CheckLogin("Admin", "admin"), Is.True);
            A.CallTo(() => dialogService.Show(A<string>.Ignored, A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Testtest()
        {
            var container = ContainerExtensions
                .CreateContainer()
                .RegisterWettkampfServices();

            var dialogService = A.Fake<IDialogService>();

            container.RegisterInstance(dialogService);

            var vereinSaver = container.GetInstance<IVereinSaver>();

            var verein = new Verein();

            Assert.That(await vereinSaver.TrySaveAsync(verein), Is.False);
            A.CallTo(() => dialogService.Show(A<string>.Ignored, A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }


    }
}