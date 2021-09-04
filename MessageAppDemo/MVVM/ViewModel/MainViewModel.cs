using System;
using System.Collections.ObjectModel;
using MessageAppDemo.MVVM.Model;

namespace MessageAppDemo.MVVM.ViewModel
{
	public class MainViewModel
	{
		public ObservableCollection<MessageModel> Messages { get; set; }
		public ObservableCollection<ContractModel> Contracts { get; set; }

		public MainViewModel()
		{
			Messages = new ObservableCollection<MessageModel>();
			Contracts = new ObservableCollection<ContractModel>();
			
			Messages.Add(new MessageModel
			{
				Username = "Allison",
				UsernameColor = "#409aff",
				ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png",
				Message = "Test",
				Time = DateTime.Now,
				IsNativeOrigin = false,
				FirstMessage = true
			});

			for (int i = 0; i < 3; i++)
			{
				Messages.Add(new MessageModel
				{
					Username = "Allison",
					UsernameColor = "#409aff",
					ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png",
					Message = "Test",
					Time = DateTime.Now,
					IsNativeOrigin = false,
					FirstMessage = false
				});
			}
			
			for (int i = 0; i < 4; i++)
			{
				Messages.Add(new MessageModel
				{
					Username = "Alison",
					UsernameColor = "#0fdbff",
					ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png",
					Message = "Love You",
					Time = DateTime.Now,
					IsNativeOrigin = true,
				});
			}
			
			Messages.Add(new MessageModel
			{
				Username = "Alison",
				UsernameColor = "#0fdbff",
				ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png",
				Message = "Last",
				Time = DateTime.Now,
				IsNativeOrigin = true,
			});

			for (int i = 0; i < 5; i++)
			{
				Contracts.Add(new ContractModel
				{
					Username = $"Allison {i}",
					ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/249px-Video-Game-Controller-Icon-IDV-green.svg.png",
					Messages = Messages
				});
			}
		}
	}
}