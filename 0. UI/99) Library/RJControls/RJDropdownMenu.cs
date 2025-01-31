﻿using IntelligentFactory;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IF_UI.RJControls
{
    public class RJDropdownMenu : ContextMenuStrip
    {
        /// <summary>
        /// This class inherits from the ContextMenuStrip class.
        /// To customize the appearance of this control use the classes:
        /// <see cref="DropdownMenuColors"/> and <see cref="DropdownMenuRenderer"/>
        /// It also helps you to position the control in an easier way thanks
        /// to the <see cref="DropdownMenuPosition"/> enumeration.
        /// </summary>
        ///

        #region -> Fields

        private bool ownerIsMenuButton; ///Sets or Gets if dropdown owns to main form side menu <see cref="RJMenuButton"/>
        private bool activeMenuItem;/// Sets or Gets if MenuItem is Activated (it has an associated form, the item menu will remain highlighted when the form is active)
        private Bitmap menuItemIcon;//Sets or Gets the menu item icon, Also it sets the height of the menu item

        #endregion -> Fields

        #region -> Constructors

        public RJDropdownMenu()
        {
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));//Set default font
        }

        //
        // Summary:
        //     Initializes a new instance of the RJDropdownMenu class
        //     and associates it with the specified container.
        //
        // Parameters:
        //   container:
        //     A component that implements System.ComponentModel.IContainer that is the
        //     container of the System.Windows.Forms.ContextMenuStrip.
        public RJDropdownMenu(IContainer container)//This constructor is invoked automatically in the form designer when the control is dragged from the toolbox onto the form.
            : base(container)////This constructor ensures that the object is removed correctly, since it is not a child of the form.
        {
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));//Set default font
        }

        #endregion -> Constructors

        #region -> Properties

        [Browsable(false)]
        [Description("Sets or gets if the dropdown menu belongs to the menu button of the main form side menu")]
        public bool OwnerIsMenuButton
        {
            get { return ownerIsMenuButton; }
            set
            {
                ownerIsMenuButton = value;
                //Set the custom renderer and send ownerIsMenuButton value (Runtime only)
                if (this.DesignMode == false)
                    this.Renderer = new DropdownMenuRenderer(ownerIsMenuButton);
            }
        }

        [Browsable(false)]
        public bool ActiveMenuItem
        {
            get { return activeMenuItem; }
            set { activeMenuItem = value; }
        }

        #endregion -> Properties

        #region -> Private methods

        private void LoadItemAppearance()
        {
            Color menuItemTextColor = Color.White;

            //- Set the height of the menu item and the width of the left column of the drop-down menu using the image property of the menu item.
            if (OwnerIsMenuButton == true)//If the owner is menubutton
                menuItemIcon = new Bitmap(25, 45);//Set 25px in width and 45px in HEIGHT
            else //Default value
                menuItemIcon = new Bitmap(22, 25);//Set 22px in width and  25px in HEIGHT

            //- Set setting text color and adjust menu item image (Icon)

            #region - Dropdown Menu Item Level 1 ---------------------------------------------

            foreach (ToolStripMenuItem menuItemL1 in this.Items)
            {
                menuItemL1.BackColor = DEFINE.COLOR_NAVY;
                menuItemL1.ForeColor = Color.White;

                #endregion - Dropdown Menu Item Level 1 ---------------------------------------------

                #region - Dropdown Menu Item Level 2 ---------------------------------------------

                foreach (ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems)
                {
                    if (activeMenuItem == false)
                        menuItemL2.ForeColor = menuItemTextColor;
                    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItemL2.Image == null) menuItemL2.Image = menuItemIcon;
                    else menuItemL2.Image = RedrawMenuItemIcon(menuItemL2.Image);

                    #endregion - Dropdown Menu Item Level 2 ---------------------------------------------

                    #region - Dropdown Menu Item Level 3 ---------------------------------------------

                    foreach (ToolStripMenuItem menuItemL3 in menuItemL2.DropDownItems)
                    {
                        if (activeMenuItem == false)
                            menuItemL3.ForeColor = menuItemTextColor;
                        menuItemL3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuItemL3.Image == null) menuItemL3.Image = menuItemIcon;
                        else menuItemL3.Image = RedrawMenuItemIcon(menuItemL3.Image);

                        #endregion - Dropdown Menu Item Level 3 ---------------------------------------------

                        #region - Dropdown Menu Item Level 4 ---------------------------------------------

                        foreach (ToolStripMenuItem menuItemL4 in menuItemL3.DropDownItems)
                        {
                            if (activeMenuItem == false)
                                menuItemL4.ForeColor = menuItemTextColor;
                            menuItemL4.ImageScaling = ToolStripItemImageScaling.None;
                            if (menuItemL4.Image == null) menuItemL4.Image = menuItemIcon;
                            else menuItemL4.Image = RedrawMenuItemIcon(menuItemL4.Image);
                        }

                        #endregion - Dropdown Menu Item Level 4 ---------------------------------------------
                    }
                }
            }
        }

        private Image RedrawMenuItemIcon(Image itemImage)
        {//this method will resize and center the image of the menu item
            var newItemIcon = new Bitmap(menuItemIcon.Width, menuItemIcon.Height);//Create a new bitmap with the dimensions specified previously.

            if (itemImage.Size.Width > newItemIcon.Size.Width)//if the size of the item image is larger than the specified icon image
                itemImage = new Bitmap(itemImage, new Size(newItemIcon.Width - 1, newItemIcon.Width - 1));//Resize the image subtracting 1 to apply padding.

            //Get centered position
            int locX = (menuItemIcon.Width - itemImage.Width) / 2;
            int locY = (menuItemIcon.Height - itemImage.Height) / 2;

            using (Graphics graphic = Graphics.FromImage(newItemIcon))//draw the image resized and centered on the created bitmap newItemIcon
            {
                graphic.DrawImage(itemImage, locX, locY);
            };
            return newItemIcon;//Return new item icon
        }

        #endregion -> Private methods

        #region -> Overridden methods

        public void Show(Control ownerControl, DropdownMenuPosition position)
        { //this method helps you to display and position drop down menu more quickly
            LoadItemAppearance();//Load setting

            int x = 0;
            int y = 0;

            x = ownerControl.Width;
            y = ownerControl.Height - Height / 2;
            this.Show(ownerControl, x, y); //send values to show dropdown menu
        }

        public new void Show()
        {
            LoadItemAppearance();
            base.Show();
        }

        public new void Show(Point screenLocation)
        {
            LoadItemAppearance();
            base.Show(screenLocation);
        }

        public new void Show(int x, int y)
        {
            LoadItemAppearance();
            base.Show(x, y);
        }

        public new void Show(Point position, ToolStripDropDownDirection direction)
        {
            LoadItemAppearance();
            base.Show(position, direction);
        }

        public new void Show(Control ownerControl, Point position)
        {
            LoadItemAppearance();
            base.Show(ownerControl, position);
        }

        public new void Show(Control ownerControl, int x, int y)
        {
            LoadItemAppearance();
            base.Show(ownerControl, x, y);
        }

        public new void Show(Control ownerControl, Point position, ToolStripDropDownDirection direction)
        {
            LoadItemAppearance();
            base.Show(ownerControl, position, direction);
        }

        #endregion -> Overridden methods
    }
}