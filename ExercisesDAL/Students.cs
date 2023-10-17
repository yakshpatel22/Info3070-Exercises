using System;
using System.Collections.Generic;

namespace ExercisesDAL
{
    public partial class Students : SchoolEntity 
    {
       
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int DivisionId { get; set; }
        public byte[] Picture { get; set; }
       

        public virtual Divisions Division { get; set; }
    }
}
