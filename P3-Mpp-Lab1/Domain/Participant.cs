using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Domain
{
    public class Participant:hasId<int>
    {
        String _nume;
        int _varsta;
        
        public String Nume
        {
            get { return _nume; }
            set { _nume = value; }
        }
        public int Varsta
        {
            get { return _varsta; }
            set { _varsta = value; }
        }


    }
}
