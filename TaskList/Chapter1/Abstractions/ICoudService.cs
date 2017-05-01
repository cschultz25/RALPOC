using System;

namespace TaskList.Abstractions
{
	//Defines what the app can do to the API
    public interface ICloudService
    {
        ICloudTable<T> GetTable<T>() where T : TableData;
    }
}
