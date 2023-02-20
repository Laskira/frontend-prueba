using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.Data;


namespace Domino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominoController : ControllerBase
    {
        [HttpGet]
        static void Main(string[] args)
        {
            List<Tuple<int, int>> dominoes = new List<Tuple<int, int>>
        {
            Tuple.Create(2, 1),
            Tuple.Create(2, 3),
            Tuple.Create(1, 3)
        };

            List<List<Tuple<int, int>>> solutions = new List<List<Tuple<int, int>>>();
            GetDominoChain(dominoes, new List<Tuple<int, int>>(), solutions);

            foreach (var solution in solutions)
            {
                Console.WriteLine("Solution:");
                foreach (var domino in solution)
                {
                    Console.WriteLine("[" + domino.Item1 + "|" + domino.Item2 + "]");
                }
                Console.WriteLine();
            }
        }

        static void GetDominoChain(List<Tuple<int, int>> dominoes, List<Tuple<int, int>> currentChain, List<List<Tuple<int, int>>> solutions)
        {
            if (dominoes.Count == 0)
            {
                if (currentChain[0].Item1 == currentChain[currentChain.Count - 1].Item2)
                {
                    solutions.Add(currentChain);
                }
                return;
            }

            for (int i = 0; i < dominoes.Count; i++)
            {
                var newDomino = dominoes[i];
                var newDominoes = new List<Tuple<int, int>>(dominoes);
                newDominoes.RemoveAt(i);
                var newChain = new List<Tuple<int, int>>(currentChain);
                newChain.Add(newDomino);

                if (currentChain.Count == 0 || newDomino.Item1 == currentChain[currentChain.Count - 1].Item2)
                {
                    GetDominoChain(newDominoes, newChain, solutions);
                }
            }
        }
    }
}
