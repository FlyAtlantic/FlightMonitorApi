using System.Collections.Concurrent;
using System.Threading;

namespace FlyAtlanticFlightMonitorApi
{
    public delegate bool SnapshotInterest(FSUIPCSnapshot a, FSUIPCSnapshot b);

    public class FlightMonitor
    {
        public BlockingCollection<FSUIPCSnapshot> Queue;

        Thread monitoringThread;

        private bool running = false;

        public FlightMonitor()
        {
            monitoringThread = new Thread(new ThreadStart(MonitoringWorker));
            Queue = new BlockingCollection<FSUIPCSnapshot>();
        }

        public void StartWorkers()
        {
            if (running)
                return;
            running = true;

            monitoringThread.Start();
        }

        private void MonitoringWorker()
        {
            while (running)
            {
                Queue.Add(FSUIPCSnapshot.Pool());
            }
        }
    }
}
