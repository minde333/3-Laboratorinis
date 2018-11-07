using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_9
{
    //Įrašų konteineris
    class VideoContainer
    {
        private const int MaxVideos = 50;
        private Video[] Videos { get; set; }
        public int Count { get; private set; }

        public VideoContainer()
        {
            Videos = new Movie[MaxVideos];
        }

        public void AddVideo(Video video)
        {
            Videos[Count] = video;
            Count++;
        }

        public void AddVideo(Video video, int index)
        {
            Videos[index] = video;
        }

        public Video GetVideo(int index)
        {
            return Videos[index];
        }

        public bool Contains(Video video)
        {
            return Videos.Contains(video);
        }
    }
}
