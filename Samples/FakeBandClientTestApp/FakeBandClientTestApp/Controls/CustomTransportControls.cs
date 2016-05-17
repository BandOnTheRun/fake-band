using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FakeBandClientTestApp.Controls
{
    public sealed class CustomTransportControls : Control
    {
        public ITransport TransportProvider
        {
            get { return (ITransport)GetValue(TransportProviderProperty); }
            set { SetValue(TransportProviderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TransportProvider.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TransportProviderProperty =
            DependencyProperty.Register("TransportProvider", typeof(ITransport), 
                typeof(CustomTransportControls), new PropertyMetadata(0));

        public CustomTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomTransportControls);
        }

        private Grid _rootGrid;
        private TextBlock _currentTime;

        protected override void OnApplyTemplate()
        {
            // Find the custom button and create an event handler for its Click event. 
            var playPauseButton = GetTemplateChild("PlayPauseButton") as Button;
            playPauseButton.Click += PlayPauseButtonClick;
            var recordButton = GetTemplateChild("RecordButton") as Button;
            recordButton.Click += RecordButtonClick;
            var stopButton = GetTemplateChild("StopButton") as Button;
            stopButton.Click += StopButtonClick;

            _rootGrid = GetTemplateChild("RootGrid") as Grid;
            _currentTime = GetTemplateChild("CurrentTime") as TextBlock;
            
            TransportProvider.Tick += OnTick;
            base.OnApplyTemplate();
        }

        private void StopButtonClick(object sender, RoutedEventArgs e)
        {
            _currentTime.Text = "00:00:00";
            TransportProvider?.Stop();
        }

        private void OnTick(TimeSpan time)
        {
            _currentTime.Text = time.ToString(@"mm\:ss\:f");
        }

        private void RecordButtonClick(object sender, RoutedEventArgs e)
        {
            var pb = sender as Button;
            TransportProvider?.Record();
        }

        private void PlayPauseButtonClick(object sender, RoutedEventArgs e)
        {
            var pb = sender as AppBarButton;
            if (TransportProvider?.CurrentState == PlayState.Playing)
            {
                TransportProvider?.Pause();
                var res = VisualStateManager.GoToState(this, "PauseState", false);
            }
            else if (TransportProvider?.CurrentState == PlayState.Paused)
            {
                TransportProvider?.Play();
                VisualStateManager.GoToState(this, "PlayState", false);
            }
        }
    }

    public delegate void TransportTickHandler(TimeSpan time);

    public interface ITransport
    {
        void Play();
        void Pause();
        void Record();
        void Stop();

        PlayState CurrentState { get; set; }
        event TransportTickHandler Tick;
    }

    public enum PlayState
    {
        Playing,
        Paused,
        Recording,
    }
}
