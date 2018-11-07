using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_9
{
    class VideoEnthusiast
    {
        //Įrašų megėjo vardas
        public string VideoEnthusiastName { get; set; }
        //Įrašų megėjo pavardė
        public string VideoEnthusiastSurname { get; set; }
        //Įrašų megėjo gimimo metai
        public string YearOfBirth { get; set; }
        //Įrašų megėjo miestas
        public string City { get; set; }
        //Įrašų konteineris
        public VideoContainer Movies { get; set; }
        public VideoContainer Series { get; set; }
        public VideoEnthusiastsContainer VideosEnthusiastsContainer { get; set; }
        public VideoContainer VideosContainer { get; set; }

        public VideoEnthusiast(string videoEnthusiastName, string videoEnthusiastSurname, string yearOfBirth, string city)
        {
            VideoEnthusiastName = videoEnthusiastName;
            VideoEnthusiastSurname = videoEnthusiastSurname;
            YearOfBirth = yearOfBirth;
            City = city;
            Movies = new VideoContainer();
            Series = new VideoContainer();
            VideosEnthusiastsContainer = new VideoEnthusiastsContainer();
            VideosContainer = new VideoContainer();
        }
        public void AddMovie(Movie movie)
        {
            Movies.AddVideo(movie);
        }
        public void AddSeries(Series series)
        {
            Series.AddVideo(series);
        }
    }
}
