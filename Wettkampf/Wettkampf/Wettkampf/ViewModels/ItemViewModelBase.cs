// <copyright file="ItemViewModelBase.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Wettkampf.Services;
using Xamarin.Forms;

namespace Wettkampf.ViewModels
{
  public class ItemViewModelBase<T> : ViewModelBase
  {
    protected IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
  }
}
