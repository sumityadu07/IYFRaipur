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
    public class FacilitatorViewModel : BaseViewModel
    {
        public ObservableRangeCollection<DataClass> NewDevotees { get; set; }
        public FacilitatorViewModel()
        {
            NewDevotees = new ObservableRangeCollection<DataClass>();
        }

        public ICommand SaveCommand => new AsyncCommand(Save);
        public ICommand AddNewDevoteeCommand => new AsyncCommand(AddNewDevotee);
        public ICommand GetNewDevoteesCommand => new AsyncCommand(GetNewDevotees);
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

                await _repository.SaveFacilitator(data);
                await Shell.Current.GoToAsync("//CouncelorPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async Task AddNewDevotee()
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

        async Task GetNewDevotees()
        {
            try
            {
                var _repository = DependencyService.Get<IRepository<DataClass>>();
                var list = await _repository.GetPreachers();
                if (list.Count != 0)
                {
                    foreach (DataClass collection in list)
                    {
                        NewDevotees.Add(collection);
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
