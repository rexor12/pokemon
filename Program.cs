using System;
using PokemonGame.DependencyInjection;
using PokemonGame.DependencyInjection.Catalogs;
using PokemonGame.Diagnostics;

namespace PokemonGame
{
    /// <summary>
    /// Defines the entry point for the application.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">An array of arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("[Info] Booting Pokémon..");
            using (var container = new DependencyContainer())
            using (var game = new Game())
            {
                var catalog = new AssemblyExportCatalog(typeof(Program).Assembly);
                using (new ExecutionTracker(tracker => Console.WriteLine($"[Debug] Resolved dependencies in {tracker.ElapsedTime.TotalMilliseconds:0}ms.")))
                {
                    container.Resolve(game, catalog);
                }
                Console.WriteLine("[Info] Successfully booted Pokémon. Press Ctrl+C to exit anytime.");

                game.Run();
            }
            Console.WriteLine("[Info] Shutting down...");
        }
    }
}
