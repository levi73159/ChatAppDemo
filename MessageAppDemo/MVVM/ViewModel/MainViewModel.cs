using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MessageAppDemo.Core;
using MessageAppDemo.MVVM.Model;

namespace MessageAppDemo.MVVM.ViewModel
{
	public class MainViewModel : ObservableObject
	{
		public ObservableCollection<MessageModel> Messages
		{
			get { return SelectedContact.Messages; }
			set { SelectedContact.Messages = value; }
		}

		public ObservableCollection<ContractModel> Contracts { get; set; }
		public List<UserModel> Users { get; set; }

		private UserModel _currentUser;

		public UserModel CurrentUser
		{
			get { return _currentUser; }
			set
			{
				_currentUser = value;
				OnPropertyChanged();
			}
		}

		

		//Commands
		public RelayCommand SendCommand { get; set; }

		private ContractModel _selectedContact;

		public ContractModel SelectedContact
		{
			get { return _selectedContact; }
			set
			{
				_selectedContact = value;
				OnPropertyChanged();
			}
		}

		private string _message;

		public string Message
		{
			get { return _message; }
			set
			{
				_message = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			Contracts = new ObservableCollection<ContractModel>();
			SendCommand = new RelayCommand(delegate(object o)
			{
				SelectedContact.Messages.Add(new MessageModel
				{
					Message = Message,
					FirstMessage = true,
					UsernameColor = "Green",
					IsNativeOrigin = true,
					Username = CurrentUser.Username,
					ImageSource = CurrentUser.ImageSource,
					Time = DateTime.Now
				});

				Message = "";
			}, o =>
			{
				if (SelectedContact == null) return false;
				return !string.IsNullOrWhiteSpace(Message);
			});

			for (int i = 0; i < 5; i++)
			{
				Contracts.Add(new ContractModel($"Cody{i}", 
					"https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png"));
			}

			Users = UserModel.CreateUserModels(Contracts);
			Users.Add(new UserModel("Levi", "", 
				"https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png")
			{
				Status = UserStatus.Online
			});
			Contracts = UserModel.GetContractModels(Users);
			CurrentUser = UserModel.LogIn("Levi", "", Users, Contracts);
			Contracts.Remove(CurrentUser.UserContract);
		}

		public void Click()
		{
			if (SendCommand.CanExecute(Message)) SendCommand.Execute(Message);
		}
	}
}