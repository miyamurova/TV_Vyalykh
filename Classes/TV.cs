using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TV_Vyalykh.Classes
{
    public class TV
    {
        private int activeChannel;
        private int activeVolume;
        public int ActiveChannel
        {
            get
            {
                return activeChannel;
            }
            set
            {
                if (activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = Channels.Count - 1;
            }
        }
        public List<Channel> Channels = new List<Channel>();
        public TV()
        {
            Channels.Add(new Channel()
            {
                Name = "6",
                Src = ""
            });
            Channels.Add(new Channel()
            {
                Name = "4",
                Src = ""
            });
            Channels.Add(new Channel()
            {
                Name = "5",
                Src = ""
            });
        }
        public void SwapChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.ActiveChannel].Src);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 1;
                EndAnimation.To = 0;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Content = this.Channels[this.ActiveChannel].Name;
        }
        public void NextChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel++;
            SwapChannel(_MediaElement, _NameChannel);
        }
        public void BackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel--;
            SwapChannel(_MediaElement, _NameChannel);
        }
        public void UpSound()
        {

        }
        public void DownSound()
        {
        }
    }
}

