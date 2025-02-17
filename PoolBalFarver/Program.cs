using System.Runtime.InteropServices;

namespace PoolBalFarver
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(95, 46);
			
			Pool poolObj = new Pool();
			bool resultValid;
			char playAgainInput;
			bool playAgain = true;
			bool playAgainInputValid = true;

			Console.WriteLine("Hej og velkommen til Poolbalfarve-dublikat-checkeren!");
			poolObj.GetNoOfPlayers();
			poolObj.PutPlayersInList();
			poolObj.SetPlayerNames();

			do
			{
				do
				{
					poolObj.ChooseColors();

					Console.WriteLine("\r\nAlle spillere har nu valgt deres ønskede farve. Vent venligst, mens resultatet beregnes...");
					for (int i = 0; i < 3; i++)
					{
						Thread.Sleep(1500);
						Console.Write("...          ");
					}

					resultValid = poolObj.IsResultValid();

					if (!resultValid)
					{
						Console.WriteLine();
						Console.WriteLine("Tryk Enter for at prøve igen");
						while (Console.ReadKey().Key != ConsoleKey.Enter)
						{

						}
					}

				} while (!resultValid);

				do
				{
					Console.Write("\r\nØnsker I at spille igen? (j/n): ");
					playAgainInput = Console.ReadKey().KeyChar;

					if (playAgainInput != 'j' && playAgainInput != 'n')
					{
						Console.WriteLine("\r\nSkriv venligst 'j' for ja eller 'n' for nej.");
						playAgainInputValid = false;
					}
					else if (playAgainInput == 'j')
					{
						playAgain = true;
						playAgainInputValid = true;
					}
					else if (playAgainInput == 'n')
					{
						playAgain = false;
						playAgainInputValid = true;
					}
				} while (!playAgainInputValid);

				Console.WriteLine();
			}
			while (playAgain);

			Console.WriteLine("\r\nTak for denne gang. Tryk på Enter for at afslutte programmet.");
			while (Console.ReadKey().Key != ConsoleKey.Enter)
			{

			}

			Environment.Exit(0);
		}
	}
}