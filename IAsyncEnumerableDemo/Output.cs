using System;
using System.Threading;
using System.Threading.Tasks;

namespace IAsyncEnumerableDemo
{
  static class Output
  {
    internal static void WriteLine(string message)
    {
      Console.WriteLine($"(Time: {DateTime.Now.ToShortTimeString()},  Thread {Thread.CurrentThread.ManagedThreadId}): {message} ");
    }
  }
}