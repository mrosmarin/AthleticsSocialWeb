using System;

namespace AthleticsSocialWeb.Common.Logging
{
    /// <summary>
    /// Base contract for Log abstract factory
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Create a new ILogger
        /// </summary>
        /// <returns>The ILogger created</returns>
        ILogger Create(Type loggerType);
    }
}
