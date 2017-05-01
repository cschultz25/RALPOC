using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using Backend.DataObjects;

namespace Backend.Models
{
	public class MobileServiceContext : DbContext
	{
		//This is set up in the web.config and overriden in the Azure portal....
		//DON"T CHANGE!
		private const string connectionStringName = "Name=MS_TableConnectionString";

		public MobileServiceContext() : base(connectionStringName)
		{
		}

		//this is needed for each table we wish to expose to the mobile clients
		public DbSet<TodoItem> TodoItems { get; set; }

		/// <summary>
		/// sets up the tables to handle the service columns that are contained within the EntityData class
		/// </summary>
		/// <param name="modelBuilder">Model builder.</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Add(
				new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
					"ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
		}
	}
}