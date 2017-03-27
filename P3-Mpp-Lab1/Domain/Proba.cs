using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Domain
{
    public class Proba :hasId<int>
    {
        int _distanta;
        String _stil;
        int _nr_participanti;

        public int Distanta
        {
            get
            {
                return _distanta;
            }

            set
            {
                _distanta = value;
            }
        }

        public string Stil
        {
            get
            {
                return _stil;
            }

            set
            {
                _stil = value;
            }
        }

        public int Nr_participanti
        {
            get
            {
                return _nr_participanti;
            }

            set
            {
                _nr_participanti = value;
            }
        }
    }
}
