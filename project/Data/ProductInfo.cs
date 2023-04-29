using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace project.Data
{
	public class ProductInfo
	{
		[PrimaryKey, AutoIncrement]
		public int ProdId { get; set; }
		public string CustName { get; set; }
		public string CustNum { get; set; }
		public string PickupTime { get; set; }
		public double OrderPrice { get; set; }
		public DateTime OrderTime { get; set; }
	}
}
