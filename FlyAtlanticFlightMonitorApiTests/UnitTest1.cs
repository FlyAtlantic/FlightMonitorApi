using System;
using System.Diagnostics;
using FlyAtlanticFlightMonitorApi;
using NUnit.Framework;

namespace FlyAtlanticFlightMonitorApiTests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase]
        public void FSUIPCProviderPoolReturnsNullSnapshot()
        {
            FlightSimIgnore();

            Assert.IsNull(FSUIPCProvider.Pool());
        }

        [TestCase]
        public void Test1()
        {
            Assert.IsNotNull(FSUIPCProvider.Pool());
        }

        public void FlightSimIgnore()
        {
            foreach (Process p in Process.GetProcesses())
            {
                string name = p.ProcessName.ToLower();
                if (name == "prepar3d")
                    Assert.Ignore();

                if (name == "fsx")
                    Assert.Ignore();
            }

        }
    }
}
