using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


using Bentley.MicroStation.WinForms;
using Bentley.GenerativeComponents.UISupport;
using Bentley.GenerativeComponents;
using Bentley.GenerativeComponents.GCScript;
using Bentley.GenerativeComponents.MicroStation;

using CERVER.Timer;


namespace Bentley.GenerativeComponents.Features.Specific  // Must be in this namespace.
{
    [HideInheritedTechniques]
     public class CrazyPoint : Point
    {

        /*------------------------------------------------------------------------------------**/
        /// <summary>Embeded timer example</summary>
        /// <author>CERVER Design Studio</author>                                        
        /// <date>2013</date>

        /*--------------+---------------+---------------+---------------+---------------+------*/
   

        // you need to close the form when you delete the feature, so we override this class
        protected override void OnBeingDeleted()
        {
            base.OnBeingDeleted();  // Must call the base implementation; it is NOT "do nothing".
       
            //this closes the timer when you delete or unplay the feature
            if (internalTimer != null)
            {
                internalTimer.form.Close();
            }
        }

        //this is for the timer
        private bool reset = false;
        private int currentFrame = 0;
        private InternalTimer internalTimer = null;
        
        //this is for the feature
        double x, y, z;

        [Technique]
        public bool updateObject
            (
            FeatureUpdateContext updateContext,
                                    IPoint startPt,
            [DefaultValue(2.0)]     double scale

            )
        {
            //make the timer if it does not exist
            if (internalTimer == null)
            {
                internalTimer = new InternalTimer(this, this.Name);
                internalTimer.CreateTimer();
            }
            //this takes care of reopening the timer if you accedently close it 
            if (internalTimer != null && !internalTimer.form.IsAccessible)
            {
                internalTimer.form.Show();
            }

            //we can check the state of the reset button
            reset = internalTimer.getResetState;
            
            //and we check the current frame
            currentFrame = internalTimer.getCurrentFrame;


            //this is the code for the sample feature, add your own feature here

            Random ran = new Random();

            if (reset)
            {
                x = startPt.X;
                y = startPt.Y;
                z = startPt.Z;
            }
            else
            {

                x += (1-(ran.NextDouble()*2)) * scale;
                y += (1 - (ran.NextDouble() * 2)) * scale;
                z += (1 - (ran.NextDouble() * 2)) * scale;
            }
           
            Point pt = new Point(this);
            pt.ByCartesianCoordinates(updateContext, this.ParentModel().BaseCoordinateSystem(),x,y,z , null);
            pt.SetSuccess(true);
            this.AddReplicatedChildFeature(pt);
            
            return true;
        } 
         
  

        // Bentley.GenerativeComponents.ViewBase.Properties.Resources.GCFeatureIcon
       

    } // class



} // namespace
