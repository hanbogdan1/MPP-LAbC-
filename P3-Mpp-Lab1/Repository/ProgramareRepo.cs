using P3_Mpp_Lab1.Domain;
using P3_Mpp_Lab1.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Repository
{
    class ProgramareRepo : IRepository<int, programare>
    {

        SQLiteConnection conn;

        public ProgramareRepo(SQLiteConnection connection)
        {
            conn = new SQLiteConnection(connection);
        }
        public void add(programare item)
        {
            try
            {
                exist_data(item.Id_participant, item.Id_proba);
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "insert into programari (id_participant , id_proba ) values (@id_participant , @id_proba)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@id_participant",item.Id_participant);
                    cmd.Parameters.AddWithValue("@id_proba", item.Id_proba);
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
                    cmd.CommandText = "delete from programari where id = @id";
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

                    cmd.CommandText = "select count(id) from programari where id = " + key.ToString() + " ; ";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount == 0)
                        throw new Exception("Nu exista programari cu datele introduse ! \n");
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

        public bool exist_data(programare item)
        {
           return exist_data(item.Id_participant, item.Id_proba);
        }

        public bool exist_data(int id_part,int id_proba)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "select count(id) from programari where id_participant  = " + id_part.ToString() + " and id_proba =  " + id_proba.ToString() + ";";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount >0)
                        throw new Exception("Exista programare cu datele introduse ! \n");
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

        

        public programare findByID(int key)
        {
            programare x = new programare();
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        string sql = "SELECT * FROM participanti WHERE Id = " + key.ToString();
                        cmd.CommandText = sql;
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            x.id = Int32.Parse(reader["id"].ToString());
                            x.Id_participant = Int32.Parse(reader["Id_participant"].ToString());
                            x.Id_proba = Int32.Parse(reader["nume"].ToString());
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
            
            return x;
        }
    

        public List<programare> getAll()
        {
            List<programare> xsd = new List<programare>();
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
                            programare x = new programare();
                            x.id = Int32.Parse(reader["id"].ToString());
                            x.Id_participant = Int32.Parse(reader["Id_participant"].ToString());
                            x.Id_proba = Int32.Parse(reader["nume"].ToString());
                            xsd.Add(x);
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

            return xsd;
        }

        public void sort()
        {
            throw new NotImplementedException();
        }

        public void update(programare item)
        {

            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "update participanti set id_participant= @id_participant , id_proba = @id_proba  where id = @id";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@id_participant", item.Id_participant);
                        cmd.Parameters.AddWithValue("@id_proba", item.Id_proba);
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
}
