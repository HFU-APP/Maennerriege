using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wettkampf.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public bool IsBusy
    {
      get => _isBusy;
      set => SetProperty(ref _isBusy, value);
    }

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }

    public string Vorname
    {
        get => _vorname;
        set => SetProperty(ref _vorname, value);
    }
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Vereinname
    {
        get => _vereinname;
        set => SetProperty(ref _vereinname, value);
    }

        public double ResultatLauf
        {
        get => _resultatLauf;
        set => SetProperty(ref _resultatLauf, value);
    }

    public double ResultBallwerfen
        {
        get => _resultBallwerfen;
        set
        {
            SetProperty(ref _resultBallwerfen, value);
        }
    }

    public DateTime Geburtsdatum
        {
        get => _geburtsdatum;
        set => SetProperty(ref _geburtsdatum, value);
    }



        public event PropertyChangedEventHandler PropertyChanged;

    protected bool SetProperty<T>(
      ref T backingStore,
      T value,
      [CallerMemberName] string propertyName = "",
      Action onChanged = null)
    {
      if (EqualityComparer<T>.Default.Equals(backingStore, value))
      {
        return false;
      }

      backingStore = value;
      onChanged?.Invoke();
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

      return true;
    }

    private bool _isBusy;
    private string _title;
    private string _vorname;
    private string _name;
    private string _vereinname;
    private double _resultatLauf;
    private double _resultBallwerfen;
    private DateTime _geburtsdatum;
    }
}
