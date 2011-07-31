using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlipSlideShow
{
    /// <summary>
    /// SlideShow for showing a grid of images and moving through them.
    /// Images are divided into rows of length SLIDE_SPLIT, so when you
    /// reach the end of the row, it animates up or down accordingly.
    /// </summary>
    public partial class SlideShow : UserControl
    {
        /// <summary>
        /// The slide we are pointing at at the moment, kind of like an
        /// array index.
        /// </summary>
        private int slideIndex = 0;

        protected const int SLIDE_WIDTH = 800;
        protected const int SLIDE_HEIGHT = 600;

        /// <summary>
        /// The split point of the display - so when we get to 
        /// a slide number % SLIDE_SPLIT == 0, we know to go to another
        /// row. This works going next OR previous slide.
        /// </summary>
        protected const int SLIDE_SPLIT = 4;

        /// <summary>
        /// When the user is going through the slides, they can go either
        /// next or previous. This gives a little context and encapsulation to
        /// the directions.
        /// </summary>
        protected enum Direction {Previous=-1, Next=1};

        public SlideShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select the next slide and update the display accordingly. Updates are
        /// animated.
        /// </summary>
        public void nextSlide()
        {
            this.update(Direction.Next);
        }

        /// <summary>
        /// If we are not at the start of the slideshow, select the previous slide
        /// and update the display accordingly. Updates are animated.
        /// </summary>
        public void prevSlide()
        {
            if (slideIndex <= 0)
            {
                return;
            }
            this.update(Direction.Previous);
        }

        /// <summary>
        /// Use "dir" to determine which slide is next. Update slideIndex
        /// to point to that slide, and add a horizontal animation, and,
        /// if we are at the end/beginning of a row and moving to the
        /// beginning/end of a row respectively, add a vertical animation.
        /// </summary>
        /// <param name="dir">Are we going previous or next?</param>
        protected void update(Direction dir)
        {
            int animFrom = getLeftCoordOfCurrentSlide();

            if (nextSlideIsOnAnotherRow(dir))
            {
                this.addVerticalAnimation(dir);
            }
            
            slideIndex += (int)dir;

            int animTo = getLeftCoordOfCurrentSlide();

            this.addAnimation(Canvas.LeftProperty, animFrom, animTo);
        }

        /// <summary>
        /// Given that slideIndex tells us what slide we are currently looking
        /// at, calculate its left position based on the SLIDE_WIDTH and where
        /// we are in terms of rows using SLIDE_SPLIT
        /// </summary>
        /// <returns>Left co-ordinate of the current slide</returns>
        protected int getLeftCoordOfCurrentSlide()
        {
            return -1 * (slideIndex % SLIDE_SPLIT) * SLIDE_WIDTH;
        }

        /// <summary>
        /// Use "dir" to peek at the next slide and work out if it's on a different
        /// row to the current slide
        /// </summary>
        /// <param name="dir">Used to determine whether we look "left" or "right" in
        /// terms of the slides</param>
        /// <returns>true if the newly selected slide is on a different row to
        /// the current one</returns>
        protected bool nextSlideIsOnAnotherRow(Direction dir)
        {
            if (dir == Direction.Next)
            {
                if ((slideIndex + (int)dir) % SLIDE_SPLIT == 0)
                {
                    return true;
                }
            }
            else if (dir == Direction.Previous)
            {
                if ((slideIndex) % SLIDE_SPLIT == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The next slide is on a different row to the current one, so add an animation
        /// to slide vertically
        /// </summary>
        /// <param name="dir">Determines which direction the animation slides in</param>
        protected void addVerticalAnimation(Direction dir)
        {
            int curRow = Math.Abs((slideIndex) / SLIDE_SPLIT);
            int nextRow = Math.Abs((slideIndex + (int)dir) / SLIDE_SPLIT);

            this.addAnimation(Canvas.TopProperty, SLIDE_HEIGHT * curRow * -1, SLIDE_HEIGHT * nextRow * -1);
        }

        /// <summary>
        /// Add an animation to the slideshow
        /// </summary>
        /// <param name="dp">What property to animate. Probably Canvas.TopProperty or Canvas.LeftProperty</param>
        /// <param name="from">Value to animmate from</param>
        /// <param name="to">Value to animate to</param>
        protected void addAnimation(DependencyProperty dp, int from, int to)
        {
            DoubleAnimation animationHorizontal = new DoubleAnimation();
            animationHorizontal.From = from;
            animationHorizontal.To = to;
            animationHorizontal.Duration = new Duration(TimeSpan.FromSeconds(0.75));
            animationHorizontal.EasingFunction = new CubicEase();
            image1.BeginAnimation(dp, animationHorizontal);
        }

    }
}