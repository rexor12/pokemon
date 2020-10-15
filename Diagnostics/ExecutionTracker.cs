using System;
using System.Diagnostics;
using System.Threading;
using PokemonGame.Utilities;

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

        private int _isDisposed;

        private readonly Stopwatch _stopwatch;
        private readonly Action<ExecutionTracker> _callback;

        /// <summary>
        /// Initializes a new instance of <see cref="ExecutionTracker"/>.
        /// </summary>
        /// <param name="callback">The action to be executed when the tracking ends.</param>
        /// <exception cref="ArgumentNullException">Thrown when a mandatory argument is <c>null</c>.</exception>
        public ExecutionTracker(Action<ExecutionTracker> callback)
        {
            ExceptionHelper.ThrowIfNull(nameof(callback), callback);

            _callback = callback;
            _stopwatch = Stopwatch.StartNew();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref _isDisposed, 1, 0) == 1)
            {
                throw new ObjectDisposedException(nameof(ExecutionTracker));
            }

            _stopwatch.Stop();
            _callback(this);
        }
    }
}