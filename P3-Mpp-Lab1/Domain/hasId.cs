using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Domain
{
    public abstract class hasId<T>
    {

        protected T _id;
        protected hasId() { }

        protected hasId(T ids)
        {
            _id = ids;
        }

        public T id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public override string ToString()
        {
            return _id.ToString().PadRight(5);
        }

    }
}
