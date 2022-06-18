// <copyright file="IVereinSaver.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public interface IVereinSaver
  {
    Task<bool> TrySaveAsync(Verein verein);
  }
}
