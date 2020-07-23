using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace persons_crud_api.Validators
{
    public class RutValidator
	{
		public bool Validate(string rut)
		{
			rut = rut.Replace(".", "").ToUpper();
			Regex expression = new Regex("^([0-9]+-[0-9K])$");
			string dv = rut.Substring(rut.Length - 1, 1);
			if (!expression.IsMatch(rut))
			{
				return false;
			}
			char[] charHyphen = { '-' };
			string[] rutTemp = rut.Split(charHyphen);
			if (dv != Digit(int.Parse(rutTemp[0])))
			{
				return false;
			}
			return true;
		}

		public bool Validate(string rut, string dv)
		{
			return Validate(rut + "-" + dv);
		}

		public string Digit(int rut)
		{
			int sum = 0;
			int multiplier = 1;
			while (rut != 0)
			{
				multiplier++;
				if (multiplier == 8)
					multiplier = 2;
				sum += (rut % 10) * multiplier;
				rut = rut / 10;
			}
			sum = 11 - (sum % 11);
			if (sum == 11)
			{
				return "0";
			}
			else if (sum == 10)
			{
				return "K";
			}
			else
			{
				return sum.ToString();
			}
		}
	}
}
