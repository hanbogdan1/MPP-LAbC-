using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Domain
{
   public class Admin:hasId<int>
    {
        String _username;
        String _nume;
        String _parola;

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Nume
        {
            get
            {
                return _nume;
            }

            set
            {
                _nume = value;
            }
        }

        public string Parola
        {
            get
            {
                return _parola;
            }

            set
            {
                _parola = value;
            }
        }
    }

}
