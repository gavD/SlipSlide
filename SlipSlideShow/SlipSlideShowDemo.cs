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

        private void button2_Click(object sender, EventArgs e)
        {
            this.slideShow1.nextSlide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.slideShow1.prevSlide();
        }
    }
}
