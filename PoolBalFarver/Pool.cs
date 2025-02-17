using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolBalFarver
{
	internal class Pool
	{
		int _noOfPlayers = 0;
		private List<string> _playerList = new List<string>();

		List<char> possibleColors = new List<char>(){'b', 'g', 'ø', 'r', 'o', 'l', 's', 'x'};
		private char[] _chosenColors;

		public void GetNoOfPlayers()
		{
			string noOfPlayers;
			bool isNumberValid;
			do
			{
				isNumberValid = true;
				Console.Write("Hvor mange ønsker I at spille? (2/3/4/5/6/7): ");
				noOfPlayers = Console.ReadLine();

				if (!(int.TryParse(noOfPlayers, out var value)))
				{
					Console.WriteLine("Skriv venligst et tal");
					isNumberValid = false;
				}
				else
				{
					_noOfPlayers = Convert.ToInt32(noOfPlayers);

					if (_noOfPlayers < 2 || _noOfPlayers > 7)
					{
						Console.WriteLine("Skriv venligst et tal mellem 2 og 7");
						isNumberValid = false;
					}
				}
			} while (!isNumberValid);
		}

		public void PutPlayersInList()
		{
			for (int i = 0; i < _noOfPlayers; i++)
			{
				_playerList.Add("Spiller " + (i+1));
			}
		}


		public void SetPlayerNames()
		{
			Console.WriteLine("\r\nGodt. Skriv nu hver især jeres navn efterfulgt af Enter.\r\n");
			for (int i = 0; i < _playerList.Count; i++)
			{
				Console.Write("{0}: ", _playerList[i]);
				_playerList[i] = Console.ReadLine();
			}
		}

		public void ChooseColors()
		{
			int spillerNo = 0;
			_chosenColors = new char[_noOfPlayers];
			System.ConsoleKeyInfo midlColor;
			bool korrekt;

			Console.WriteLine("\r\nOkay. De mulige farver er: \r\n b (blå) \r\n g (gul) \r\n ø (grøn) \r\n r (rød) \r\n o (orange) \r\n l (lilla) \r\n x (bourdeaux) \r\n s (sort)");
			Console.WriteLine("\r\nVælg nu jeres ønskede farve ved at indtaste bogstavet for farven (b/g/ø/r/o/l/x/s): \r\n");

			foreach (string poolSpiller in _playerList)
			{
				do
				{
					Console.Write("{0}: ", poolSpiller);
					midlColor = Console.ReadKey(true);

					if (!possibleColors.Contains(midlColor.KeyChar))
					{
						Console.WriteLine("Skriv venligst en gyldig farve. Prøv igen.");
						korrekt = false;
					}
					else
					{
						_chosenColors[spillerNo] = midlColor.KeyChar;
						korrekt = true;
						Console.WriteLine();
					}
				} while (korrekt == false);

				spillerNo++;
			}
		}

		public bool IsResultValid()
		{
			List<char> checkDubColor = new List<char>();
			bool checker = true;
			bool isResultValid = true;
			if (_chosenColors.Length != _chosenColors.Distinct().Count())
			{
				isResultValid = false;
				Console.WriteLine("\r\nDesværre, to eller flere spillere har valgt den samme farve.");
				Console.WriteLine("Tryk Enter for at se, hvilke(n) farve(r), der går igen.\r\n");
				while (Console.ReadKey().Key != ConsoleKey.Enter)
				{

				}

				foreach (char color in _chosenColors)
				{
					if (checkDubColor.Contains(color))
					{
						if (checker == true)
						{
							Console.Write("Følgende farve(r) går igen: ");
							Console.Write(color + " ");
							checker = false;
						}
						else
							Console.Write(color + " ");
					}
					checkDubColor.Add(color);
				}
			}
			else
			{
				isResultValid = true;
				Console.WriteLine("\r\nTillykke, I har valgt hver jeres farve. Spillet kan nu begynde.");

				Console.WriteLine("EFTER SPILLET: \r\nTryk på Enter for at få vist spillernes valg.\r\n");

				while (Console.ReadKey().Key != ConsoleKey.Enter)
				{

				}

				int y = 0;
				foreach (string spiller in _playerList)
				{
					Console.WriteLine("{0} valgte: {1}", spiller, _chosenColors[y]);
					y++;
				}
			}

			return isResultValid;
		}
	}
}
