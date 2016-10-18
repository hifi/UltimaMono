/***************************************************************************
 *   HighPerformanceTimer.cs
 *   
 *   No license information - can't remember where I got this, found it in
 *   one of my experiments folders :( If anyone can help me track down the
 *   original source (I can only find other hobby games using the same
 *   code), please let me know!
 *
 ***************************************************************************/
using System;

// This portable implementation is *not* high performance and exists for the
// sole purpose of making UltimaXNA run with diagnostics.

namespace UltimaXNA.Core.Diagnostics
{
    /// <summary>
    /// A high resolution query performance timer.
    /// </summary>
    public class HighPerformanceTimer
    {
        #region Member Variables
        private long m_StartTime = 0;
        #endregion

        public HighPerformanceTimer()
        {
        }

        #region Methods
        public void Start()
        {
            // Record when the timer was started.
            m_StartTime = DateTime.Now.Ticks;
        }

        public static double SecondsFromTicks(long ticks)
        {
            return ((double)ticks) / Frequency;
        }
        #endregion

        #region Static Properties

        static HighPerformanceTimer()
        {
        }

        /// <summary>
        /// Gets the frequency that this HighPerformanceTimer performs at.
        /// </summary>
        public static long Frequency
        {
            get
            {
                return TimeSpan.TicksPerSecond;
            }
        }

        /// <summary>
        /// Gets the current system ticks.
        /// </summary>
        public static long Counter
        {
            get
            {
                return DateTime.Now.Ticks;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the tick count of when this HighPerformanceTimer was started.
        /// </summary>
        public long StartTime
        {
            get
            {
                return m_StartTime;
            }
        }

        public long ElapsedTicks
        {
            get
            {
                return HighPerformanceTimer.Counter - m_StartTime;
            }
        }

        public double ElapsedSeconds
        {
            get
            {
                return ((double)ElapsedTicks) / HighPerformanceTimer.Frequency;
            }
        }
        #endregion
    }
}
