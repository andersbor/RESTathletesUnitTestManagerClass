using System.Collections.Generic;
using System.Linq;
using athleteLibrary;

namespace athletesREST.Managers
{
    public class AthletesManager
    {
        private static int _nextId = 1;
        private static readonly List<Athlete> Data = new List<Athlete>
        {
            new Athlete {Id=_nextId++, Name = "Anne‑Marie Rindom", Country = "Denmark", Height = 172} , 
            new Athlete { Id=_nextId++, Name = "Emma McKeon", Country = "Australia", Height = 178},
            new Athlete { Id = _nextId++, Name ="Caeleb Dressel", Country = "USA", Height = 191},
            new Athlete { Id=_nextId++, Name = "Simone Biles",Country = "USA", Height = 148},
            new Athlete { Id = _nextId++, Name = "Anders B", Country = "Denmark", Height = 176}

        };

        public IEnumerable<Athlete> GetAll(string country=null, string sortBy=null)
        {
            List<Athlete> result = new List<Athlete>(Data);
            if (country != null)
            {
                result = result.FindAll(athlete => athlete.Country == country);
            }

            if (sortBy != null)
            {
                if (sortBy.ToLower() == "height")
                {
                    return result.OrderBy(athlete => athlete.Height);
                }

                if (sortBy.ToLower() == "country")
                {
                    return result.OrderBy(athlete => athlete.Country);
                }
            }
            return result;
        }

        public Athlete Add(Athlete athlete)
        {
            athlete.Id = _nextId++;
            Data.Add(athlete);
            return athlete;
        }

        public Athlete Delete(int id)
        {
            Athlete athlete = Data.FirstOrDefault(athlete1 => athlete1.Id == id);
            if (athlete == null) return null;
            Data.Remove(athlete);
            return athlete;
        }
    }
}
