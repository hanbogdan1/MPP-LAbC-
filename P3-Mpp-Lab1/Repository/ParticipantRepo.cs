using P3_Mpp_Lab1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace P3_Mpp_Lab1.Repository
{
    public class ParticipantRepo : IRepository<int, Participant>
    {
        SQLiteConnection conn;

        public ParticipantRepo( )
        {
            conn = DBUtils.DBUtils.getConnection();
        }

       public int get_id_by_details(Participant x)
        {
            if (exist_data(x) == false)
            {
                try
                {

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        int rez;
                        string sql =String.Format( "SELECT id FROM participanti  where nume  = '{0}' and varsta =  " + x.Varsta.ToString(),x.Nume);
                        cmd.CommandText = sql;
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            rez = Int32.Parse(reader["id"].ToString());
                            return rez;
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
            else
                return -1;
        
        }


        public Boolean exist_data (Participant x)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = String.Format("SELECT id FROM participanti  where nume  = '{0}' and varsta =  " + x.Varsta.ToString(), x.Nume);
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    if (RowCount > 0)
                        return false;   
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
    

        public void add(Participant item)
        {
            try
            {
                conn.Open();
                using ( SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "insert into participanti (Nume , Varsta ) values (@nume,@varsta)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Nume", item.Nume);
                    cmd.Parameters.AddWithValue("@Varsta", item.Varsta);
                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        //MessageBox.Show("Insert succesfull !");
                    }

                }
                item = null;
            }
            catch   (Exception ex)
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
                        cmd.CommandText = "delete from participanti where id = @id";
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

        public bool exist(int key)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "select count(id) from participanti where id = " + key.ToString() + " ; ";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount == 0)
                        throw new Exception("Nu exista participant cu id introdus ! \n");
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

        public Participant findByID(int key)
        {
            Participant x = new Participant();
            if (exist(key))
            {
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand( conn))
                    {
                        conn.Open();
                        string sql = "SELECT * FROM participanti WHERE Id = " + key.ToString();
                        cmd.CommandText = sql;
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            x.id = Int32.Parse(reader["id"].ToString());
                            x.Varsta = Int32.Parse(reader["Varsta"].ToString());
                            x.Nume = reader["nume"].ToString();
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

        public List<Participant> getAll()
        {
            List<Participant> lst = new List<Participant>();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    string sql = "SELECT * FROM participanti ";
                    cmd.CommandText = sql;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Participant x = new Participant();
                            x.id = Int32.Parse(reader["id"].ToString());
                            x.Varsta = Int32.Parse(reader["Varsta"].ToString());
                            x.Nume = reader["nume"].ToString();
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

        public void update( Participant item)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "update participanti set Nume= @nume , Varsta = @varsta  where id = @id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Nume", item.Nume);
                    cmd.Parameters.AddWithValue("@Varsta", item.Varsta);
                    cmd.Parameters.AddWithValue("@id", item.id);
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
    }
}
