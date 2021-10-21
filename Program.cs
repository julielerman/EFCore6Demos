using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore6Demos
{
  public class Program
  {
    private IDbContextFactory<SOContext> _poolingFactory;
    private SOContext _context;

    //compiling the query so it doesn't trigger context or pooling effort
    private static readonly Func<SOContext, IAsyncEnumerable<UserReputation>> _queryone
        = EF.CompileAsyncQuery((SOContext context) => context.UserReps.Take(1));

    private static readonly Func<SOContext, IAsyncEnumerable<UserReputation>> _query1K
          = EF.CompileAsyncQuery((SOContext context) => context.UserReps.Take(1000));

    [GlobalSetup]
    public void Setup()
    {
      var services = new ServiceCollection();
      //pooling, non-tracking
      //opt out of thread safety checks as you would in prod
      services.AddPooledDbContextFactory<SOContext>(options => options
          .UseSqlServer("Server=;Database=StackOverflow2010;Trusted_Connection=True;")
          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
          .EnableThreadSafetyChecks(false)
      );
      var serviceProvider = services.BuildServiceProvider();
      _poolingFactory = serviceProvider.GetRequiredService<IDbContextFactory<SOContext>>();

      //if I'm not using this, is it still impacting (helping/triggering) the poolling?
      _context = _poolingFactory.CreateDbContext();
    }

    [Benchmark]
    public async Task<int> OneKRows_withPooling()
    {
      using var db = _poolingFactory.CreateDbContext();
      await foreach (var userRep in _query1K(db))
      {
      }
      return 0;
    }

    [Benchmark]
    public async Task<int> OneRow_WithPooling()
    {
      using var db = _poolingFactory.CreateDbContext();
      await foreach (var userRep in _queryone(db))
      {
      }
      return 0;
    }

    static void Main(string[] args) =>

          BenchmarkRunner.Run<Program>();
  }
}


