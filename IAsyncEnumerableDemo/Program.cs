using System;
using System.Collections.Async;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IAsyncEnumerableDemo
{
  class AsyncEnumerableExample
  {
    public static void Main()
    {
      Output.WriteLine("********************************* IEnumerable Demo *********************************");
      StartIEnumerable().Wait();

      Output.WriteLine("********************************* IAsyncEnumerable Demo *********************************");
      StartIAsyncEnumerable().Wait();

      Output.WriteLine("Done");
      Console.ReadLine();
    }

    static async Task StartIEnumerable()
    {
      Output.WriteLine("StartIEnumerable Starting");

      var list = await EnumerableCalculation();

      Output.WriteLine("StartIEnumerable Completed");

      foreach (var value in list)
      {
        Output.WriteLine($"Result: {value}");
      }
      Output.WriteLine("");
    }

    static async Task<IEnumerable<int>> EnumerableCalculation()
    {
      Output.WriteLine("EnumerableCalculation Called");

      var list = new Collection<int>();

      for (var i = 0; i < 3; i++)
      {
        Output.WriteLine("Computing " + i);
        await Task.Delay(TimeSpan.FromSeconds(1));

        list.Add(i);
      }

      return list;
    }

    static async Task StartIAsyncEnumerable()
    {
      Output.WriteLine("StartIAsyncEnumerable Starting");

      IAsyncEnumerable<int> sequence = AsyncEnumerableCalculation().ToAsyncEnumerable();

      Output.WriteLine("StartIAsyncEnumerable Awaiting");

      await sequence.ForEachAsync(value =>
      {
        Output.WriteLine($"Result: {value}");
      });

      Output.WriteLine("");
    }

    static IEnumerable<int> AsyncEnumerableCalculation()
    {
      Output.WriteLine("AsyncEnumerableCalculation Called");

      for (var i = 0; i < 3; i++)
      {
        Output.WriteLine("Async Computing " + i);
        Task.Delay(TimeSpan.FromSeconds(1)).Wait();

        yield return i;
      }
    }
  }
}