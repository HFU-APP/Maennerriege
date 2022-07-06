using System.Threading.Tasks;
using FakeItEasy;
using Wettkampf.Core;
using NUnit.Framework;
using Turnverein.ViewModels;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.ViewModels;

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

        [Test]
        public async Task TestAddPerson()
        {
            var dialogService = A.Fake<IDialogService>();
            App.Services.RegisterInstance(dialogService);

            var factory = A.Fake<IItemFactory<Verein>>();
            App.Services.RegisterInstance(factory);

            Verein verein = new Verein();

            ListViewModelBase<Verein, VereineViewModel> a = new ListViewModelBase<Verein, VereineViewModel>();
            int old = a.Items.Count;

            a.Items.Add(verein);

            int neu = a.Items.Count;

            Assert.IsTrue(neu == old + 1);
        }

        [Test]
        public async Task TestRemovePerson()
        {
            var dialogService = A.Fake<IDialogService>();
            App.Services.RegisterInstance(dialogService);

            var factory = A.Fake<IItemFactory<Verein>>();
            App.Services.RegisterInstance(factory);

            Verein verein = new Verein();

            ListViewModelBase<Verein, VereineViewModel> a = new ListViewModelBase<Verein, VereineViewModel>();

            a.Items.Add(verein);
            a.Items.Add(verein);

            int old = a.Items.Count;

            a.Items.Remove(verein);
            int neu = a.Items.Count;

            Assert.IsTrue(neu == old - 1);
        }

        [Test]
        public async Task TestPasswordAdminOk()
        {
            var dialogService = A.Fake<IDialogService>();
            App.Services.RegisterInstance(dialogService);

            LoginViewModel a = new LoginViewModel();

            Assert.That(await a.CheckLogin("GrZKy/5QWp7WrKf21hNZUA==", "Admin"), Is.True);
        }

        [Test]
        public async Task TestPasswordAdminFalse()
        {
            var dialogService = A.Fake<IDialogService>();
            App.Services.RegisterInstance(dialogService);

            LoginViewModel a = new LoginViewModel();

            Assert.That(await a.CheckLogin("1234", "Admin"), Is.False);
        }

        [Test]
        public async Task TestPasswordUserOk()
        {
            var dialogService = A.Fake<IDialogService>();
            App.Services.RegisterInstance(dialogService);

            LoginViewModel a = new LoginViewModel();

            Assert.That(await a.CheckLogin("IxA5mJA4ZpFBeiAsWLTFRQ==", "User"), Is.True);
        }

        [Test]
        public async Task TestPasswordUserFalse()
        {
            var dialogService = A.Fake<IDialogService>();
            App.Services.RegisterInstance(dialogService);

            LoginViewModel a = new LoginViewModel();

            Assert.That(await a.CheckLogin("1234", "User"), Is.False);
        }
  }
}