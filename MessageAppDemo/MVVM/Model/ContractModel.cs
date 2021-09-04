using System.Collections.ObjectModel;
using System.Linq;

namespace MessageAppDemo.MVVM.Model
{
	public class ContractModel
	{
		public string Username { get; set; }
		public string ImageSource { get; set; }
		public ObservableCollection<MessageModel> Messages { get; set; }
		public string LastMessage
		{
			get { return Messages.Last().Message; }
		}
	}
}