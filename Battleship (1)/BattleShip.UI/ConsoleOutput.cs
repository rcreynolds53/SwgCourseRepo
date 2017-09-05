using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
namespace BattleShip.UI
{
	public class ConsoleOutput
	{
		public static string GetName(int playernumber)
		{
			// for now just have their input be their name, but later one make it so that it must include a string of letters. 
			Console.WriteLine($"Welcome to Battleship! Player {playernumber} please start by entering your name.");
			return Console.ReadLine();
		}

		internal static void DisplaySplash()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(@"                                     ``        :++`            `       `                            
        `        `                             --++-                   :       `          `       ` 
                                               -::/:/.              `--/:-                          
                     ``              `         --:`:`-:`      `.-:/++/+/++                          
                                               -`/ `:``:-`   -++/:-..`.+::                  `       
                                               - `/ .:  .-:--+/-:.-//:/:.`                          
 `                                             -  :-`--    `:--::-+-://`:          `                
                               `.-.            -  `--.:-   .:::/::://-..-..`                        
                            `--.`  -           -   : .-+::---///--::.- -.. -                      ` 
                `            :  ````-      `.-:-::.+:-:--://---//:.`---.--.-`                       
                             `/....`..     .---//-::.---::---:/:.`..-`.  ::-...                     
                              `.  .`.-.    `:./://--/+-:---` -:.``..:.. `-/..`                      
                               ..  - -:..--:::.::/::/. `..:.-.`.`.-:```.:` ..                       
                                -`.`. .:://:-:-`/++-`:-` ..:`   .-- `-:-                            
            `.--                .:-.`//:/--:/-/+:-`--``:--:`` .`.`  :-`                             
o`      `.--.`` -              `../:-.--:/:.///- --`---:  .```..   ..                               
o+.     /`  . `.`-        ..  `.-.-:---:-:::--`--.-:..-.`` ...`   .`                                
.o//    `:   ....`-       --:///:.:-...//-:.  -..-:...`.` ---   ..                                  
 :+//.   `-..`   ``:    .--++:.:-:-:`::::-` - .--... .`  -.`   .`                                   
  -o---`  `.`  `  ..- -/:-//.--:`..-.-:-...` ---`. `-  `-.   `.                                     
  ../-.:-` `-..``   `:-.:-.`:-.-.--.:. . `-.--:-` .` `:-    .`          .-                          
   -`+:`-...`:.-  `  `:::-:---..: :.`.. -.-.-:` `.  .-`   `-          `-` :                         
    -.-/``-`.:-.. ```--.--.-..:`--````-`..     .```..    -.--        .-   `-.                       
    ..-`/. .-`//:/--:``--...:`-.` `..`.-`    .` ...`   `:``  .-   -...`..`..`-.     ``              
     --  :+-:+:-`/:::-:-.-:-:. .. -..:-.   `` ``..    .-  `..  --.. .-......:- .--..``...           
   `.::``./+:-/-.-:/...---:.` - `` -..``    ``..     :`      ..  .-.   ``           .... :``        
  `-` s/---./:.-.-/..-:::. ..`.``.-.-  ```  `-.    .-`.````````````````````.-.-............-::...`` 
.`/`-/::/+:/+:-`:-..:::```. .-`-..``  .` . --     --.```````.`.             .``````          .. ``` 
` /-:. /:::-://..--::` -`.` .--`-    `   `-`    `:``....``   .-`````              -     ..```    ```
.-.-..-/...`-.````..```.``-`--```````````.``````.````   `.`         `.`-`        -      `.         `
```````   ``.``..  ``.`-...`````-``````. `.```````.``````       `   `````    ````            `````  
`      ```.` ```..                      ``                   ```-    ``                `.`      `.  
```.``.````.`.`           .``.`...` ```.`````..`.    .` ````.`   .-`.s/ ..  oo  ` ./-     `         
            -`.``:-    +. -`````` ````  ````     ````         :/`::os+/:oy.:+/:.+---+`   -./+:      
    `/-.`  ./--:.//.oo-oo//`:. ....-....`..`..``````        `:s+ssooooys/s+o:o+ss+/-/o.`-++:oo/`.   
   -o+/o/-:+:/osoo/+s+ssooso+o-..`.```   `          ```````:oooso+ss++.++s//oo+o-:-/os/sysoh:+os-s` 
`. :o:yoso/so.-/:+:o+o:/+syo+so/     -```-`````````````    /+oy+osh+o/:os+s:+y-yo.`:y/os//oo/o/ysso 
:+////o+:ssoy:/+oy+++o+o//s/os+/ ```                     `./+sos/:o:/oy+o//:oso+///os+s//:+++/:///o 
-/ .---::.:.::-::/--//-://::--+......```          ```.---.``::..:////-.-::-:-::--.-/----//:..... :+ 
./`  `   .-` `-.``.-`.:....-```....`.```..-` ``.-.```.````````.`--..`.::-.-:-``.--` ..:-`  `.`   :+ 
.::` `.```.```..-.-..`    ````    ```````   ````   `````````` ```.`````` `....```````.---.::----::-`");
			Console.ReadKey();
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
		}

		internal static void VictoryResponse()
		{

			Console.WriteLine($"Contragulations! You have won the game by sinking all of the opponents ships.!");
			Console.ReadLine();
		}

		internal static void ShipToPlace(ShipType shipType)
		{
			Console.WriteLine($"You are placing your {shipType}.");
		}

		internal static void ShipNoSpaceAlert(ShipType shipType)
		{
			Console.WriteLine($"Error, there is not enough space on the board for you to place your {shipType} on that coordinate in that direction. Please try again.");
			Console.ReadLine();
		}

		internal static void ShipOverlappedAlert(ShipType shipType)
		{
			Console.WriteLine($"Error, your {shipType} was unable to be placed since it is overlapping with another ship. Please try again.");
			Console.ReadLine();
		}

		internal static void PlayAgainPrompt()
		{
			Console.WriteLine("Would you like a rematch> \n Press Y to play again, otherwise press any other key to exit Battleship.");
		}

		internal static void HitAndSunkResponse(string shipImpacted)
		{
			Console.WriteLine($"You have hit and sunk the opponents {shipImpacted}!");
			Console.ReadLine();
		}

		internal static void IvalidResponse()
		{
			Console.WriteLine($"Please enter a valid coordinate to attack!");
			Console.ReadLine();
		}

		internal static void VictoryResponse(string name)
		{
			Console.WriteLine($"Contragulations {name}! You have won the game!");
			Console.ReadLine();

		}

		internal static void HitResponse()
		{
			Console.WriteLine("Hit!");
			Console.ReadLine();

		}

		internal static void MissResponse()
		{
			Console.WriteLine("Miss!");
			Console.ReadLine();

		}

		internal static void DuplicateResponse()
		{
			Console.WriteLine("You already entered that coordinate, please reenter a coordinate.");
			Console.ReadLine();

		}

		internal static void ToNextTurn()
		{
			Console.WriteLine("Please press any key to continue...");
			Console.Clear();
		}

		internal static void WhoBuilds(Player name)
		{
			Console.WriteLine($"{name.Name}, it is your turn.");
		}

		public static void WhoseTurn(Player player)
		{
			Console.WriteLine($"{player.Name}, it is your turn.");
		}

		internal static void PromptPlayerForCoordinate()
		{
			Console.WriteLine("Please enter a coordinate from a1 to j10: ");
		}

		internal static void PromptForDirection()
		{
			Console.WriteLine("Please enter the uppercase letter that corresponds to the direction you want to place your ship.\n U = Up   D = Down   L = Left   R = Right \n");
		}

	}
}