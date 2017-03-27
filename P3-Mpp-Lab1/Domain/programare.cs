using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Domain
{
    public class programare:hasId<int>
    {
        int _id_participant;
        int _id_proba;

        public int Id_participant
        {
            get
            {
                return _id_participant;
            }

            set
            {
                _id_participant = value;
            }
        }

        public int Id_proba
        {
            get
            {
                return _id_proba;
            }

            set
            {
                _id_proba = value;
            }
        }
    }
}
