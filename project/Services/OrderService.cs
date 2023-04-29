using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Data;
using SQLite;

namespace project.Services
{
	public class OrderService
	{
		public SQLiteAsyncConnection con;
		string _dbPath;

		public OrderService(string dbPath)
		{
			_dbPath = dbPath;
		}

		private async Task InitAsync()
		{
			if (con != null)
			{
				return;
			}
			con = new SQLiteAsyncConnection(_dbPath);
			con.Tracer = new Action<string>(q => Debug.WriteLine(q));
			con.Trace = true;
			await con.CreateTableAsync<ProductInfo>();
		}
		public async Task<bool> AddUpdateProductAsync(ProductInfo productInfo)
		{
			if (productInfo.ProdId > 0)
			{
				await con.UpdateAsync(productInfo);
			}
			else
			{
				await con.InsertAsync(productInfo);
			}
			return await Task.FromResult(true);
		}
		public async Task<bool> DeleteProductAsync(int proId)
		{
			await con.DeleteAsync<ProductInfo>(proId);
			return await Task.FromResult(true);
		}
		public async Task<ProductInfo> GetProductAsync(int proId)
		{
			return await con.Table<ProductInfo>().Where(p => p.ProdId == proId).FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<ProductInfo>> GetProductAsync()
		{
			await InitAsync();
			return await Task.FromResult(await con.Table<ProductInfo>().ToListAsync());
		}
	}
}
