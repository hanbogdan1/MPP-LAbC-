using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Mpp_Lab1.Domain;

namespace P3_Mpp_Lab1.Repository
{
    public interface IRepository<ID, T> where T : hasId<ID>
                                        where ID : IComparable<ID>
    {
        void add(T item);
        void delete(ID key);
        void update( T newItem);
        bool exist(ID key);
        T findByID(ID key);
        List<T> getAll();
        void sort();
        Boolean exist_data(T item);

    }
}
