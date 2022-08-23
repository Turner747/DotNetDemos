using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class VideoPost : Post
    {
        protected bool isPlaying = false;
        protected int currDuration = 0;
        Timer timer;

        protected string VideoURL { get; set; }
        protected int Length { get; set; } // in milliseconds


        public VideoPost()
        {
            
        }

        public VideoPost(string title, string sendByUserName, string videoURL, int length, bool isPublic = true)
        {
            // base properties
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUserName = sendByUserName;
            this.IsPublic = isPublic;

            // video post properties
            this.VideoURL = videoURL;
            this.Length = length;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3} - by {4}", this.ID, this.Title, this.VideoURL, this.Length, this.SendByUserName);
        }

        public string GetVideoLengthString()
        {
            int milliseconds = this.Length % 1000;
            int tempSeconds = this.Length / 1000;
            int minutes = tempSeconds / 60;
            int seconds = tempSeconds % 60;

            return String.Format("{0}:{1}:{2} minutes", minutes, seconds, milliseconds);
        }

        public void Play()
        {
            if (!isPlaying)
            {
                Console.WriteLine("Playing");
                timer = new Timer(TimerCallback, null, 0, 1000);
                isPlaying = true;
            }
            else
            {
                Console.WriteLine("Video is already playing");
            }
            

        }

        private void TimerCallback(Object o)
        {
            if (currDuration < Length)
            {
                currDuration++;
                Console.WriteLine("Video at {0}s", currDuration);
                GC.Collect();
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            if (isPlaying)
            {
                Console.WriteLine("Stopped at {0s", currDuration);
                currDuration = 0;
                timer.Dispose();
                isPlaying = false;
            }
            else
            {
                Console.WriteLine("Video is not playing");
            }
            
        }
    }
}
