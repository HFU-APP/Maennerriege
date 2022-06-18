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

      if (string.IsNullOrEmpty(verein.Title))
      {
        await _dialogService.Show("Validation failed", "The title cannot be empty.");

        return false;
      }

      if (string.IsNullOrEmpty(verein.Description))
      {
        await _dialogService.Show("Validation failed", "The description cannot be empty.");

        return false;
      }

      return true;
    }

    private readonly IDialogService _dialogService;
  }
}
