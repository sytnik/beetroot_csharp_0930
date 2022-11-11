// Console.WriteLine("Hello, World!");
// var iterator = 0;
// var list = new List<string> {"elem1", "elem2", "elem3", "elem4", "elem5"};
// do
// {
//     Console.WriteLine($"{iterator + 1} - {list[iterator++]}");
// } while (iterator < list.Count);


using System.Text;
using Lesson17;

Console.OutputEncoding = Encoding.UTF8;
var rate = TimeSpan.FromMilliseconds(120);
var game = new Game();

using (var token = new CancellationTokenSource())
{
    var check = CheckKeyPresses(token);
    do
    {
        game.OnTick();
        game.Render();
        await Task.Delay(rate);
    } while (!game.IsGameOver);

    token.Cancel();
    await check;
}

async Task CheckKeyPresses(CancellationTokenSource cts)
{
    while (!cts.Token.IsCancellationRequested)
    {
        if (Console.KeyAvailable)
            game.OnKeyPress(Console.ReadKey(true).Key);
        await Task.Delay(100);
    }
}