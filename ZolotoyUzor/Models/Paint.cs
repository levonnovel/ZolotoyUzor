﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZolotoyUzor.Models
{
	public class Paint
	{
		static readonly string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Composition { get; set; }
		public string Application_Area { get; set; }
		public decimal Price { get; set; }
		public string Color { get; set; }
		public string Volume { get; set; }
		public string Country { get; set; }

		public static List<Paint> GetAllPaints()
		{
			List<Paint> ProductsList = new List<Paint>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM paints", conn);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					ProductsList.Add(
							new Paint()
							{
								Id = Convert.ToInt32(dr["Id"]),
								Name = dr["Name"].ToString(),
								Description = dr["Description"].ToString(),
								Composition = dr["Composition"].ToString(),
								Application_Area = dr["Application_Area"].ToString(),
								Price = Convert.ToDecimal(dr["Price"]),
								Color = dr["Color"].ToString(),
								Volume = dr["Volume"].ToString(),
								Country = dr["Country"].ToString(),
							}
						);
				}
				return ProductsList;
			}
		}

		public static Paint GellPaintByID( int id)
		{
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM paints WHERE ID=@id", conn);

				conn.Open();
				cmd.Parameters.AddWithValue("@id", id);
				SqlDataReader dr = cmd.ExecuteReader();
				Paint el = new Paint();
				while (dr.Read())
				{

					el = new Paint()
					{
						Id = Convert.ToInt32(dr["Id"]),
						Name = dr["Name"].ToString(),
						Description = dr["Description"].ToString(),
						Composition = dr["Composition"].ToString(),
						Application_Area = dr["Application_Area"].ToString(),
						Price = Convert.ToDecimal(dr["Price"]),
						Color = dr["Color"].ToString(),
						Volume = dr["Volume"].ToString(),
						Country = dr["Country"].ToString(),
					};


				}
				return el;
			}
		}
	}
}