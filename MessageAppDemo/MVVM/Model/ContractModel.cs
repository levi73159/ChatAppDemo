using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MessageAppDemo.MVVM.Model
{
	public class ContractModel
	{
		public ContractModel(string username, string imageSource)
		{
			Username = username;
			ImageSource = imageSource;
			
			Messages = new ObservableCollection<MessageModel>()
			{
				new MessageModel
				{
					Time = DateTime.Today,
					FirstMessage = true,
					ImageSource = ImageSource,
					Username = username,
					UsernameColor = "Blue",
					Message = "Test",
					IsNativeOrigin = true
				}
			};
		}

		public string Username { get; set; }
		public string ImageSource { get; set; }
		public ObservableCollection<MessageModel> Messages { get; set; }
		public string LastMessage
		{
			get { return Messages.Last().Message; }
		}

		public static ContractModel Get(string username, IEnumerable<ContractModel> contracts)
		{
			foreach (var i in contracts)
			{
				if (i.Username == username) return i;
			}

			return new ContractModel(null, null);
		}
	}
}