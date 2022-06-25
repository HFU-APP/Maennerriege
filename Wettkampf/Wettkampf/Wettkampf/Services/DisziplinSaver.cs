// <copyright file="DisziplinSaver.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class DisziplinSaver : IDisziplinSaver
  {
    public DisziplinSaver(IDialogService dialogService)
    {
      _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public async Task<bool> TrySaveAsync(Disziplin disziplin)
    {
      if (disziplin is null) { throw new ArgumentNullException(nameof(disziplin)); }

      if (string.IsNullOrEmpty(disziplin.Title))
      {
        await _dialogService.Show("Validation failed", "The title cannot be empty.");

        return false;
      }

      return true;
    }

    private readonly IDialogService _dialogService;
  }
}
