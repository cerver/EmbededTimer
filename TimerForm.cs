using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

using Bentley.MicroStation.WinForms;
using Bentley.GenerativeComponents.UISupport;
using Bentley.GenerativeComponents;
using Bentley.GenerativeComponents.Features;
using Bentley.GenerativeComponents.Features.Specific;
using Bentley.GenerativeComponents.GCScript;
using Bentley.GenerativeComponents.MicroStation;
using Bentley.GenerativeComponents.API;


namespace EmbededTimer
{
    //public partial class TimerForm : Form
    public partial class TimerForm : AdapterWinForm
    {
        public Feature timerObj;
        public string tmrName;

        private bool rset = true;
        private long tickCt;
        private int frameCt;
        private int timeInt;
        private int currentTime;
        private DispatcherTimer dispTimer;

        public TimerForm()
           : base(true, "GC Timer", new System.Drawing.Size(212, 155), AdapterWinFormDockability.All)
        {
            this.Height = 155;
            tmrName = "Timer";
            InitializeComponent();

            timeInt = (int)this.updateInterval.Value;
            frameCt = 0;
            cFrameTxt.Text = "0";

            dispTimer = new DispatcherTimer();
            dispTimer.Tick += dispTimer_Tick;
            dispTimer.Interval = TimeSpan.FromMilliseconds(timeInt);
        }

        public TimerForm(string name)
            : base(true, "GC Timer", new System.Drawing.Size(212, 155), AdapterWinFormDockability.All)
        {
            this.Height = 155;
            tmrName = name;       
            InitializeComponent();
            
            timeInt = (int)this.updateInterval.Value;
            frameCt = 0;
            cFrameTxt.Text = "0";

            dispTimer = new DispatcherTimer();
            dispTimer.Tick += dispTimer_Tick;
            dispTimer.Interval = TimeSpan.FromMilliseconds(timeInt);
        }

        
        protected override void DisposeManagedResources()
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        protected override void OnAdapterWinFormClosing(bool trulyClosing)
        {

            frameCt = 0;
            if (dispTimer != null)
            {
                dispTimer.Stop();
            }
        }
        private void btPlay_CheckedChanged(object sender, EventArgs e)
        {
            if (btPlay.Checked)
            {
                btPlay.Image = EmbededTimer.Properties.Resources.player_pause;
                dispTimer.Start();
                if (btReset.Checked) btReset.Checked = false;
            }
            else
            {
                btPlay.Image = EmbededTimer.Properties.Resources.player_play;
                dispTimer.Stop();

            }
        }


        private void btReset_CheckedChanged(object sender, EventArgs e)
        {
            if (btReset.Checked)
            {
                resetTrue();
            }
            else
            {
                rset = false;
                btReset.Image = EmbededTimer.Properties.Resources.player_reset_false;
            }
            updateGC();
        }

        private void updateInterval_ValueChanged(object sender, EventArgs e)
        {
            timeInt = (int)updateInterval.Value;
            dispTimer.Interval = TimeSpan.FromMilliseconds(timeInt); 
        }
        void dispTimer_Tick(object sender, EventArgs e)
        {

            currentTime = System.Environment.TickCount;
            tickCt = currentTime + dispTimer.Interval.Ticks;

            frameCt++;
            cFrameTxt.Text = frameCt.ToString();
            //update
            updateGC();
        }

        private void resetTrue()
        {
            if (dispTimer != null)
            {
                dispTimer.Stop();

                btReset.Image = EmbededTimer.Properties.Resources.player_reset_true;

                cFrameTxt.Text = "0";
                rset = true;

                if (frameCt > 0)
                    updateGC();
                frameCt = 0;
            }
        }

        private void updateGC()
        {
            GCTools.UserModel.Lock(GCTools.UserModel);
            try
            {
                if (timerObj != null)
                {
                    APIHelper.UpdateNodeTree(new List<INode>(1) { timerObj });
                    GCTools.SyncUpMicroStation();
                }

            }
            finally
            {
                GCTools.UserModel.Unlock(GCTools.UserModel);
            }

        }

        private void FrameRateTxt_Click(object sender, EventArgs e)
        {

        }
        /////public///////////////////////////////

        public void resetTimer()
        {
            resetTrue();
        }
        public bool getResetState()
        {
            return rset;
        }

        public int getCurrentFrame()
        {
            return frameCt;
        }

       

    }
}
