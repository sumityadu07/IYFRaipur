using IYFRaipur.Models;
using IYFRaipur.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IYFRaipur.ViewModels
{
    public class PreacherViewModel : BaseViewModel
    {
        private ObservableRangeCollection<DataClass> facilitators;

        public PreacherViewModel()
        {
            Facilitators = new ObservableRangeCollection<DataClass>();
        }
        public ICommand SaveCommand => new AsyncCommand(Save);
        public ICommand GetFacilitatorsCommand => new AsyncCommand(GetFacilitators);

        async Task Save()
        {
            var _repository = DependencyService.Resolve<IRepository<DataClass>>();
            try
            {
                var councelor = new DataClass
                {
                    UserName = UserName,
                    Name = Name,
                    Email = Email
                };
                await _repository.SaveCouncelor(councelor);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        async Task GetFacilitators()
        {
            try
            {
                var _repository = DependencyService.Get<IRepository<DataClass>>();
                var list = await _repository.GetFacilitators();
                if (list.Count != 0)
                {
                    foreach (DataClass collection in list)
                    {
                        Facilitators.Add(collection);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("ERROR", "No Data Available", "ok");

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("ERROR", ex.Message, "ok");
            }
        }

        #region Properties
        public ObservableRangeCollection<DataClass> Facilitators
        {
            get { return facilitators; }
            set
            {
                facilitators = value;
                OnPropertyChanged(nameof(Facilitators));
            }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        #endregion
    }
}
