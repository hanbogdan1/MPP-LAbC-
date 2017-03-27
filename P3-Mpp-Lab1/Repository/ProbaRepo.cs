using P3_Mpp_Lab1.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Repository
{
    class ProbaRepo : IRepository<int, Proba>
    {
        SQLiteConnection conn;

        public ProbaRepo(SQLiteConnection connection)
        {
            conn = new SQLiteConnection(connection);
        }
        public void update(Proba item)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "update probe set Distanta = @Distanta  Stil= @Stil  Nr_participanti = @Nr  where id = @id ";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Distanta", item.Distanta);
                    cmd.Parameters.AddWithValue("@Stil", item.Stil);
                    cmd.Parameters.AddWithValue("@Nr", item.Nr_participanti);

                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        //MessageBox.Show("Insert succesfull !");
                    }

                }
                item = null;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {
                conn.Close();
            }
        }

        public void delete(int key)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "delete from probe where id = @id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@id", key);
                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        //MessageBox.Show("Insert succesfull !");
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {
                conn.Close();
            }
        }

        public Proba findByID(int key)
        {
            Proba x = new Proba();
            if (exist(key))
            {
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        string sql = "SELECT * FROM probe WHERE Id = " + key.ToString();
                        cmd.CommandText = sql;
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            x.id = Int32.Parse(reader["id"].ToString());
                            x.Distanta = Int32.Parse(reader["Distanta"].ToString());
                            x.Stil = reader["Stil"].ToString();
                            x.Nr_participanti = Int32.Parse(reader["nr_participanti"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex ;
                }
                finally
                {
                    conn.Close();
                }
            }
            return x;
        }

        public List<Proba> getAll()
        {
           List< Proba> lst = new List<Proba>();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    string sql = "SELECT * FROM probe";
                    cmd.CommandText = sql;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proba x = new Proba();
                            x.id = Int32.Parse(reader["id"].ToString());
                            x.Distanta = Int32.Parse(reader["Distanta"].ToString());
                            x.Stil = reader["Stil"].ToString();
                            x.Nr_participanti = Int32.Parse(reader["nr_participanti"].ToString());
                            lst.Add(x);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex ;
            }
            finally
            {
                conn.Close();
            }
            
            return lst;
        }

        public void sort()
        {
            throw new NotImplementedException();
        }

        public void increment_nr_participanti(int id)
        {

            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "update probe Set Nr_participanti = Nr_participanti + 1 where id = " + id.ToString();
                    cmd.Prepare();

                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        //MessageBox.Show("Insert succesfull !");
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void add(Proba item)
        {

            String[] names = new String[4] { " liber", "spate", "fluture", "mixt" };
            var matchingvalues =names.Where(stringToCheck => stringToCheck.Equals(item.Stil));
            if (matchingvalues == null)
                throw new Exception("Stilul ales nu este corect ! \n");

            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "insert into probe (Distanta , Stil , Nr_participanti ) values (@Distanta,@Stil , @Nr)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Distanta", item.Distanta);
                    cmd.Parameters.AddWithValue("@Stil", item.Stil);
                    cmd.Parameters.AddWithValue("@Nr", item.Nr_participanti);

                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        //MessageBox.Show("Insert succesfull !");
                    }

                }
                item = null;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool exist(int key)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "select count(id) from proba where id = " + key.ToString() + " ; ";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount == 0)
                        throw new Exception("Nu exista proba cu datele introduse ! \n");
                    return true;

                }


            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {

                conn.Close();
            }
        }

        public bool exist_data(Proba x)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "select count(id) from probe where distanta = " + x.Distanta + " and stil =  " + x.Stil + ";";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount > 0)
                        throw new Exception("Exista proba cu datele introduse ! \n");
                    return true;
                }


            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {

                conn.Close();
            }
        }
    }
}
