using System;
using System.Collections.Generic;

namespace ExercisesDAL
{
    public partial class Divisions : SchoolEntity
    {
        public Divisions()
        {
            Students = new HashSet<Students>();

        }

      
        public string Name { get; set; }
      

        public virtual ICollection<Students> Students { get; set; }
    }
}
