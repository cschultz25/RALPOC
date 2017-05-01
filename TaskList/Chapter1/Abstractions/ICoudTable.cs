using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskList.Abstractions
{
	//Defines the normal CRUD operations for the API
	public interface ICloudTable<T> where T : TableData
	{
        Task<T> CreateItemAsync(T item);
        Task<T> ReadItemAsync(string id);
        Task<T> UpdateItemAsync(T item);
        //Task<T> UpsertItemAsync(T item);
        Task DeleteItemAsync(T item);
        Task<ICollection<T>> ReadAllItemsAsync();
        Task<ICollection<T>> ReadItemsAsync(int start, int count);
    }
}
