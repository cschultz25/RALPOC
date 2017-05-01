using Microsoft.Azure.Mobile.Server;

namespace Backend.DataObjects
{
	//Use EntityData to expose additional attributes for tracking device changes
	public class TodoItem : EntityData
	{
		public string Text { get; set; }
		public bool Complete { get; set; }
	}
}