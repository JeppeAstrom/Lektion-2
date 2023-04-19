using System.Collections.Generic;
using _01_ASPNetMVC.Models;

namespace _01_ASPNetMVC.ViewModels
{
	public class AllProductsViewModel
	{
		public CollectionModel Showcase { get; set; }
		public CollectionModel PopularProducts { get; set; }
		public CollectionModel NewProducts { get; set; }
	}
}
