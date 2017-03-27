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
    public class AdminRepo
    {
        SQLiteConnection conn;

       public AdminRepo ()
        {
            conn = DBUtils.DBUtils.getConnection();
        }


        public bool exist(int key)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "select count(id) from admini where id = " + key.ToString() + " ; ";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount == 0)
                        throw new Exception("Nu exista admin cu datele introduse ! \n");
                    return true;

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


        public bool can_register(Admin x)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "select count(id) from admini where username = " + x.Username + " ;";
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount >0)
                        throw new Exception("Username este deja folosit !\n");
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





        public void add(Admin item)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "insert into participanti (Nume , Parola , Username ) values (@nume,@varsta, @ursname)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@nume", item.Nume);
                    cmd.Parameters.AddWithValue("@usrname", item.Username);
                    cmd.Parameters.AddWithValue("@Parola", item.Parola);
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

        public Boolean verify_login( Admin x)
        {
            try
            {
                conn.Open();
                
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = String.Format("select count(id) from Admini where username =  '{0}'  and  parola =  '{1}' " ,x.Username , x.Parola);
                    Console.WriteLine(cmd.CommandText);
                    cmd.CommandType = CommandType.Text;
                    int RowCount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount == 0)
                        throw new Exception("Nu exista admin cu datele introduse ! \n");
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



        public void update(Admin item)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "update admini set Nume= @nume , Username = @Username, parola = @parola  where id = @id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@nume", item.Nume);
                    cmd.Parameters.AddWithValue("@Username", item.Username);
                    cmd.Parameters.AddWithValue("@parola", item.Parola);
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


        public void delete(int key)
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "delete from admini where id = @id";
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


    }
}
