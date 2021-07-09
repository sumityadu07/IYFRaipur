using IYFRaipur.Models;
using IYFRaipur.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IYFRaipur.ViewModels
{
    class CouncelorViewModel : BaseViewModel
    {

        public ObservableRangeCollection<DataClass> Preachers { get; set; }
        private ObservableRangeCollection<DataClass> Facilitators { get; set; }
        public CouncelorViewModel()
        {
            Preachers = new ObservableRangeCollection<DataClass>();
            Facilitators = new ObservableRangeCollection<DataClass>();
            _ = GetPreachers();
        }

        public ICommand SaveCommand => new AsyncCommand(Save);
        public ICommand GetPreachersCommand => new AsyncCommand(GetPreachers);
        public ICommand GetFacilitatorsCommand => new AsyncCommand(GetFacilitators);
        async Task Save()
        {
            var _repository = DependencyService.Resolve<IRepository<DataClass>>();

            try
            {
                var data = new DataClass
                {
                    UserName = UserName,
                    Name = Name,
                    Email = Email
                };

                await _repository.SaveCouncelor(data);
                await Shell.Current.GoToAsync("//CouncelorPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Returns Preachers collection on Councelor page
        async Task GetPreachers()
        {
            try
            {
                var _repository = DependencyService.Get<IRepository<DataClass>>();
                var list = await _repository.GetPreachers();
                if (list.Count != 0)
                {
                    foreach (DataClass collection in list)
                    {
                        Preachers.Add(collection);
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

        //Returns Preachers collection on Councelor page
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
        private string userNAme;
        public string UserName
        {
            get { return userNAme; }
            set
            {
                userNAme = value;
                OnPropertyChanged(nameof(UserName));
            }
        }


        private string email;
        public string Email
        {
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
            get
            { return email; }
        }
        #endregion
    }
}