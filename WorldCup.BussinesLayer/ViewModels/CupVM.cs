using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.Repository;

namespace WorldCup.BussinesLayer.ViewModels
{
	public class CupVM
	{
		public static string MaleCup { get; } = "Muško prvenstvo";
		public static string FemaleCup { get; } = "Žensko prvenstvo";
		public string Name { get; set; }
	}
}
