using FlyAtlanticFlightMonitorApi;
using System;
using System.Windows.Forms;

namespace DataRecorder
{
    public partial class mainFrm : Form
    {
        private FlightMonitor flightMonitor;
        private Timer guiUpdate;

        public mainFrm()
        {
            InitializeComponent();

            flightMonitor = new FlightMonitor();
            flightMonitor.Interests.Add(testInterest);
            flightMonitor.StartWorkers();

            guiUpdate = new Timer();
            guiUpdate.Interval = 1000;
            guiUpdate.Tick += GuiUpdate_Tick;
            guiUpdate.Start();
        }

        public bool testInterest(FSUIPCSnapshot queued, FSUIPCSnapshot contender)
        {
            return (Math.Abs(contender.Altitude - queued.Altitude) > 150);
        }

        private void GuiUpdate_Tick(object sender, EventArgs e)
        {
            lblAltitude.Text = String.Format(
                "Altitude: {0}ft",
                flightMonitor.Queue.Take().Altitude.ToString());
        }
    }
}
