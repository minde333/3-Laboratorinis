using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Konsolėje rašo lietuviškas raides

            Program p = new Program();

            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");
            VideoEnthusiastsContainer videoEnthusiastsContainer = new VideoEnthusiastsContainer();

            foreach (string path in filePaths)
            {
                videoEnthusiastsContainer.AddVideoEnthusiast(ReadVideoEnthusiastData(path));
            }

            //Duomenys sudedami į lentelę
            CreateAllReportTables(videoEnthusiastsContainer, "L3ReportTable.txt");
            Console.WriteLine();

            Console.ReadKey();
        }

        private static VideoEnthusiast ReadVideoEnthusiastData(string file)
        {
            VideoEnthusiast videoEnthusiast;

            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                string VideoEnthusiastName = values[0];
                string VideoEnthusiastSurname = values[1];
                string YearOfBirth = reader.ReadLine();
                string City = reader.ReadLine();
                videoEnthusiast = new VideoEnthusiast(VideoEnthusiastName, VideoEnthusiastSurname, YearOfBirth, City);

                while (null != (line = reader.ReadLine()))
                {
                    values = line.Split(',');
                    char type = line[0];
                    string Name = values[1];
                    string Genre = values[3];
                    string Studio = values[4];
                    string Actor1 = values[6];
                    string Actor2 = values[7];
                    switch (type)
                    {
                        case 'M':
                            int Release = int.Parse(values[2]);
                            string Director = values[5];
                            double Profit = double.Parse(values[8]);
                            Movie movie = new Movie(Name, Release, Genre, Studio, Director, Actor1, Actor2, Profit);

                            if (!videoEnthusiast.Movies.Contains(movie))
                            {
                                videoEnthusiast.AddMovie(movie);
                            }
                            break;
                        case 'S':
                            string StartDate = values[2];
                            string EndDate = values[5];
                            int Episodes = int.Parse(values[8]);
                            string Airing = values[9];
                            Series series = new Series(Name, StartDate, Genre, Studio, EndDate, Actor1, Actor2, Episodes, Airing);
                            if (!videoEnthusiast.Series.Contains(series))
                            {
                                videoEnthusiast.AddSeries(series);
                            }
                            break;
                    }
                }
            }
            return videoEnthusiast;
        }

        private static void CreateReportTable(VideoEnthusiast videoEnthusiast, string file)
        {
            for (int i = 0; i < videoEnthusiast.VideosEnthusiastsContainer.Count; i++)
            {
                using (StreamWriter writer = new StreamWriter(@file))
                {
                    writer.WriteLine("Duomenys apie įrašo mėgėją ir jo peržiurėtus įrašus");
                    writer.WriteLine(new string('-', 218));
                    writer.WriteLine("| Vardas: {0, -97} |", videoEnthusiast.VideosEnthusiastsContainer.GetVideoEnthusiast(i).VideoEnthusiastName);
                    writer.WriteLine(new string('-', 218));
                    writer.WriteLine("| Pavardė: {0, -97} |", videoEnthusiast.VideosEnthusiastsContainer.GetVideoEnthusiast(i).VideoEnthusiastSurname);
                    writer.WriteLine(new string('-', 218));
                    writer.WriteLine("| Gimimo metai: {0, -97} |", videoEnthusiast.VideosEnthusiastsContainer.GetVideoEnthusiast(i).YearOfBirth);
                    writer.WriteLine(new string('-', 218));
                    writer.WriteLine("| Miestas: {0, -97} |", videoEnthusiast.VideosEnthusiastsContainer.GetVideoEnthusiast(i).City);
                    writer.WriteLine(new string('-', 218));
                    writer.WriteLine("| {0, -40} | {1,-14} | {2,-30} | {3,-35} | {4,-20} | {5,-20} | {6,-20} | {7,-14} | {8,-14} | {9,-14} | {10,-14} | {11,-14} |",
                        "Pavadinimas", "Filmo leidimo metai", "Žanras", "Studija", "Filmo režisierius", "Aktorius 1", "Aktorius 2", "Filmo Pelnas", "Serialo pradžios metai", "Serialo pabaigos metai", "Serialo serijų skaičius", "Ar tęsiasi serialas");
                    writer.WriteLine(new string('-', 218));
                                      
                    for (int j = 0; j < videoEnthusiast.VideosContainer.Count; j++)
                    {
                        writer.WriteLine(videoEnthusiast.VideosContainer.GetVideo(j));
                    }
                    writer.WriteLine(new string('-', 218));
                }
            }
        }
        private static void CreateAllReportTables(VideoEnthusiastsContainer videoEnthusiastsContainer, string file)
        {
            for (var i = 0; i < videoEnthusiastsContainer.Count; i++)
            {
                CreateReportTable(videoEnthusiastsContainer.GetVideoEnthusiast(i), file);
            }
        }
    }
}
