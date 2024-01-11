// See https://aka.ms/new-console-template for more information
using exercise.main.Game;

Console.WriteLine("Hello, World!");
Game game = new Game();
game.HandSize = 2;
game.Players.Add(new Player() { Name="Nigel"});
game.Players.Add(new Player() { Name = "Carlo" });

game.NewGame();

