using System;
using System.Diagnostics;

namespace PokemonGame.Diagnostics
{
    /// <summary>
    /// Provides methods for accurately measuring elapsed time.
    /// </summary>
    public sealed class ExecutionTracker : IDisposable
    {
        /// <summary>
        /// Gets the time elapsed since the tracker was started.
        /// </summary>
        public TimeSpan ElapsedTime => _stopwatch.Elapsed;

        private readonly Stopwatch _stopwatch;
        private readonly Action<ExecutionTracker> _callback;

        /// <summary>
        /// Initializes a new instance of <see cref="ExecutionTracker"/>.
        /// </summary>
        /// <param name="callback">The action to be executed when the tracking ends.</param>
        public ExecutionTracker(Action<ExecutionTracker> callback)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
            _stopwatch = Stopwatch.StartNew();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _stopwatch.Stop();
            _callback(this);
        }
    }
}