using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Windows.Media;

namespace MessageAppDemo.MVVM.Model
{
	public enum UserStatus
	{
		Online,
		Busy,
		Offline
	}

	public class UserModel
	{
		public string Username { get; set; }
		public string Password { private get; set; }
		public string ImageSource { get; set; }
		public UserStatus Status { get; set; }
		public ContractModel UserContract { get; set; }
		public SolidColorBrush StatusColor { get; set; }

		public UserModel(string username, string password, string imageSource, ContractModel userContract = null)
		{
			Username = username;
			Password = password;
			ImageSource = imageSource;
			Status = UserStatus.Offline;

			UserContract = userContract ?? new ContractModel(username, password);
		}

		public static UserModel LogIn(string username, string password, List<UserModel> userModels, ObservableCollection<ContractModel> contractModels)
		{
			foreach (var user in userModels)
			{
				if (user.Username != username || user.Password != password) continue;
				foreach (var contract in contractModels)
				{
					foreach (var message in contract.Messages)
					{
						if (message.Username == user.Username)
						{
							message.IsNativeOrigin = true;
							message.UsernameColor = "Green";
						}
						else
						{
							message.IsNativeOrigin = false;
							message.UsernameColor = "Blue";
						}
					}
				}

				contractModels.Remove(user.UserContract);

				switch (user.Status)
				{
					case UserStatus.Online:
						user.StatusColor = Brushes.ForestGreen;
						break;
					case UserStatus.Busy:
						user.StatusColor = Brushes.Coral;
						break;
					case UserStatus.Offline:
						user.StatusColor = Brushes.Gray;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				return user;
			}

			throw new SecurityException("Wrong password or username");
		}
		
		public static List<UserModel> CreateUserModels(IEnumerable<ContractModel> contractModels)
		{
			return contractModels.Select(contractModel =>
				new UserModel(contractModel.Username, "", contractModel.ImageSource, contractModel)).ToList();
		}

		public static ObservableCollection<ContractModel> GetContractModels(IEnumerable<UserModel> userModels)
		{
			return new ObservableCollection<ContractModel>(userModels.Select(userModel => userModel.UserContract).ToList());
		}
	}
}