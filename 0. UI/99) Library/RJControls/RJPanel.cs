﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace IF_UI.RJControls
{
    public class RJPanel : Panel
    {
        /// <summary>
        /// This control doesn't have many additional customization properties,
        /// just set the background color according to the theme set by the appearance settings,
        /// and be able to set a radius to the edge of the control.
        /// </summary>
        ///

        #region -> Fields

        private bool customizable; // Gets or sets if the appearance colors are customizable
        private int borderRadius; // Gets or sets the border radius

        #endregion -> Fields

        #region -> Properties

        [Category("RJ Code Advance")]
        [Description("Gets or sets whether the control's appearance colors are customizable")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Gets or sets the border radius")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate(); // Redraw the control to update the appearance of the control.
            }
        }

        #endregion -> Properties

        #region -> Private methods

        private void ApplyAppearanceSettings()
        {// Apply appearance settings
            if (customizable == false)
            {
                this.BackColor = Settings.UIAppearance.ItemBackgroundColor;
            }
        }

        #endregion -> Private methods

        #region -> Overridden methods

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Utils.RoundedControl.RegionAndSmoothed(this, borderRadius, e.Graphics);
        }

        #endregion -> Overridden methods
    }
}