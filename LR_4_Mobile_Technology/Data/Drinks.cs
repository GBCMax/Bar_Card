using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar_Card.Data
{
	public class Drinks
	{
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Consists { get; set; }
		public int Volume { get; set; }
	}
}
