// <copyright file="VereinSaver.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class VereinSaver : IVereinSaver
  {
    public VereinSaver(IDialogService dialogService)
    {
      _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public async Task<bool> TrySaveAsync(Verein verein)
    {
      if (verein is null) { throw new ArgumentNullException(nameof(verein)); }

      if (string.IsNullOrEmpty(verein.Name))
      {
        await _dialogService.Show("Validation failed", "Das Feld für den Namen darf nicht leer sein.");

        return false;
      }

      if (string.IsNullOrEmpty(verein.Vorname))
      {
        await _dialogService.Show("Validation failed", "Das Feld für den Vornamen darf nicht leer sein.");

        return false;
      }

      if (string.IsNullOrEmpty(verein.Vereinname))
      {
          await _dialogService.Show("Validation failed", "Das Feld für den Vereinname darf nicht leer sein.");

          return false;
      }

        return true;
    }

    private readonly IDialogService _dialogService;
  }
}
