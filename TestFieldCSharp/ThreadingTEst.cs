using System.Collections.Concurrent;

namespace TestFieldCSharp;

class RunThings()
{
    static void Main(string[] args)
    {
        ConcurrentQueue<string> cq = new();

        Game game = new(cq);
        Renderer renderer = new(cq);

        Thread t1 = new(game.Start);
        Thread t2 = new(renderer.Start);

        t1.Start();
        t2.Start();
    }
}

class Renderer
{
    private ConcurrentQueue<string> _cq = new();

    public Renderer(ConcurrentQueue<string> cq)
    {
        _cq = cq;
    }

    public void Add(string value) => _cq.Enqueue(value);

    public void Start()
    {
        while (true)
        {
            if (!_cq.IsEmpty)
            {
                Console.Clear();
                _cq.TryDequeue(out var temp);

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(temp);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

class Game
{
    private ConcurrentQueue<string> _cq;

    public Game(ConcurrentQueue<string> cq)
    {
        _cq = cq;
    }

    public void Start()
    {
        Input();
    }

    private void Input()
    {
        while (true)
        {
            _cq.Enqueue(Console.ReadKey().Key.ToString() ?? "x");
        }
    }
}
