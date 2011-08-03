This is a simple slideshow application. It assumes a single image, made up
of 800x600 "slides", and simply pans across it. When it reaches the end of a
"row" of slides, the next row is started.

SlipSlideShow can be included in any Visual Studio project; the buttons are only supplied for ease of testing. For example, I used it with the Kinect SDK to trigger presentations using gestures.

I'd like to make it configurable at some point; allow the user to specify the
width/height of their slides, and automatically read the total image size rather
than having to get it right in SlideShow.xaml
