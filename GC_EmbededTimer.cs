using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


using Bentley.MicroStation.WinForms;
using Bentley.GenerativeComponents.UISupport;
using Bentley.GenerativeComponents;
using Bentley.GenerativeComponents.Features;
using Bentley.GenerativeComponents.GCScript;
using Bentley.GenerativeComponents.MicroStation;

using EmbededTimer;


namespace CERVER.Timer 
{
    
    
    public class InternalTimer 
    {
        private string timerName = null;
        public InternalTimer()
        {

        }
        public InternalTimer(Feature parentFeature, string name)
        {
            timerName = name;
            GCobj = parentFeature;
        }


        public TimerForm form = new TimerForm();
        
        public void resetTimer()
        {
            form.resetTimer();
        }
        public bool getResetState
        {
            get { return form.getResetState(); }
        }
        public int getCurrentFrame
        {
            get {return form.getCurrentFrame(); }
        }

        private bool formExists = false;
        private string TimerName;
        private Feature GCobj;
        
        public bool CreateTimer()
        {
           
            if (!formExists)
            {
                TimerName = "Timer: " + GCobj.Name;

                form.tmrName = TimerName;
                form = new TimerForm(TimerName);
                if (timerName == null) form.Text = "Timer: " + GCobj.Name;
                else form.Text = timerName;
                form.resetTimer();
                form.Show();
                formExists = true;
               
            }
          

            if (GCobj != null)
            {
                form.timerObj = GCobj;
            }
            else return false;

            
            return true;
        } 
         

    } // class



} // namespace
