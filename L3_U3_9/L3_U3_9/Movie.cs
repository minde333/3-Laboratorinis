using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_9
{
    /// Klasė saugoti duomenis apie filmą
    class Movie : Video
    {
        // Filmo išleidimo metai 
        public int Release { get; set; }
        // Filmą sukūrusio režisieriaus vardas
        public string Director { get; set; }
        // Filmo pelnas
        public double Profit { get; set; }

        public Movie(string name, int release, string genre, string studio, string director, string actor1, string actor2, double profit) : base(name, genre, studio, actor1, actor2)
        {
            Release = release;
            Director = director;
            Profit = profit;
        }
      
        public override string ToString()
        {
            return String.Format("| {0, -40} | {1,-14} | {2,-30} | {3,-35} | {4,-20} | {5,-20} | {6,-20} | {7,-14} | {8,-14} | {9,-14} | {10,-14} | {11,-14} |",
                        Name, Release, Genre, Studio, Director, Actor1, Actor2, Profit, "", "", "", "");
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Movie other))
            {
                return false;
            }
            return Name == other.Name &&
                   Release == other.Release &&
                   Genre == other.Genre &&
                   Studio == other.Studio &&
                   Director == other.Director &&
                   Actor1 == other.Actor1 &&
                   Actor2 == other.Actor2 &&
                   Math.Abs(Profit - other.Profit) < 0.1;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Genre.GetHashCode() ^ Studio.GetHashCode() ^ Director.GetHashCode() ^ Actor1.GetHashCode() ^ Actor2.GetHashCode() ^ Profit.GetHashCode();
        }

        public static bool operator ==(Movie lhs, Movie rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Movie lhs, Movie rhs)
        {
            return !(lhs == rhs);
        }
    }
}
