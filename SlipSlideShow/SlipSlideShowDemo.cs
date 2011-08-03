using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlipSlideShow
{
    /// <summary>
    /// Simple class that contains the SlideShow to demonstrate how to use it
    /// </summary>
    public partial class SlipSlideShowDemo : Form
    {
        public SlipSlideShowDemo()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.nextSlide();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.prevSlide();
        }

        public void nextSlide()
        {
            this.slideShow1.nextSlide();
        }

        public void prevSlide()
        {
            this.slideShow1.prevSlide();
        }

        public void hideButtons()
        {
            btnNext.Hide();
            btnPrev.Hide();
        }

        public void goFullscreen()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            this.goFullscreen();
            btnFullscreen.Visible = false; 
        }
    }
}
