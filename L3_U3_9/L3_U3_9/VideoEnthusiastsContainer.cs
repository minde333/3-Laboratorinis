using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_9
{
    //Įrašų entuziastų konteineris
    class VideoEnthusiastsContainer
    {
        private const int MaxVideoEnthusiasts = 50;
        public VideoEnthusiast[] VideoEnthusiasts;
        public int Count { get; private set; }

        public VideoEnthusiastsContainer()
        {
            VideoEnthusiasts = new VideoEnthusiast[MaxVideoEnthusiasts];
            Count = 0;
        }

        public void AddVideoEnthusiast(VideoEnthusiast videoEnthusiast)
        {
            VideoEnthusiasts[Count++] = videoEnthusiast;
        }

        public void AddVideoEnthusiast(VideoEnthusiast videoEnthusiast, int index)
        {
            VideoEnthusiasts[index] = videoEnthusiast;
        }

        public VideoEnthusiast GetVideoEnthusiast(int index)
        {
            return VideoEnthusiasts[index];
        }

        public bool Contains(VideoEnthusiast videoEnthusiast)
        {
            return VideoEnthusiasts.Contains(videoEnthusiast);
        }
    }
}
