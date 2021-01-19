using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InjectionIcinParametreveSorgu
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Injection a açık sorgu

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security = True");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories";

            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    int id = reader.GetInt32(0);
            //    string ad = reader.GetString(1);
            //    Console.WriteLine($"{id} - {ad}");
            //}
            //reader.Close();

            //Console.WriteLine("Kategori numarası giriniz:");
            //string kategori = Console.ReadLine(); 
            //cmd.CommandText = $"SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE CategoryID = {kategori}";
            //SqlDataReader urunler = cmd.ExecuteReader();

            //while (urunler.Read())
            //{
            //    int id = urunler.GetInt32(0);
            //    string ad = urunler.GetString(1);
            //    decimal fiyat = urunler.GetDecimal(2);
            //    short stok = urunler.GetInt16(3);
            //    Console.WriteLine($"{id} - {ad} - {fiyat} - {stok}");
            //}

            //con.Close();

            #endregion

            #region parametreli sorgu

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security = True");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories";
            //con.Open();

            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    int id = reader.GetInt32(0);
            //    string ad = reader.GetString(1);
            //    Console.WriteLine($"{id} - {ad}");
            //}
            //reader.Close();

            //Console.WriteLine("Lütfen kategori numarası giriniz.");
            //string kategori = Console.ReadLine();

            //cmd.CommandText = "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE CategoryID=@kid";
            //cmd.Parameters.AddWithValue("@kid", kategori);

            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    int id = reader.GetInt32(0);
            //    string ad = reader.GetString(1);
            //    decimal fiyat = reader.GetDecimal(2);
            //    short stok = reader.GetInt16(3);
            //    Console.WriteLine($"{id} - {ad} - {fiyat} - {stok}");
            //}

            //con.Close();

            #endregion

            #region ürün adı kategoriID unitsINstock unitPrice reorderlevel alıp

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security = True");
            //SqlCommand cmd = con.CreateCommand();


            //Console.WriteLine("Lütfen ürün adı giriniz.");
            //string UrunAdi = Console.ReadLine();

            //Console.WriteLine("Lütfen kategoriID giriniz.");
            //short KategoriID = Convert.ToInt16(Console.ReadLine());

            //Console.WriteLine("Lütfen stok giriniz.");
            //short Stok = Convert.ToInt16(Console.ReadLine());

            //Console.WriteLine("Lütfen fiyat giriniz.");
            //decimal Fiyat = Convert.ToDecimal(Console.ReadLine());

            //Console.WriteLine("Lütfen güvenlik stoğu giriniz.");
            //short GuvenlikStogu = Convert.ToInt16(Console.ReadLine());

            //cmd.CommandText = "INSERT INTO Products(ProductName, CategoryID, UnitsInStock, UnitPrice, ReorderLevel)  VALUES(@Uru, @Kat, @Stok, @Price, @Reo) ";
            //cmd.Parameters.Clear();//Her addwithvalue yazılmadan önce eklenmelidir.
            //cmd.Parameters.AddWithValue("@Uru", UrunAdi);
            //cmd.Parameters.AddWithValue("@Kat", KategoriID);
            //cmd.Parameters.AddWithValue("@Stok", Stok);
            //cmd.Parameters.AddWithValue("@Price", Fiyat);
            //cmd.Parameters.AddWithValue("@Reo", GuvenlikStogu);

            //con.Open();
            //cmd.ExecuteNonQuery();

            //con.Close();

            #endregion

            #region tedarikçileri listele bilgileri güncellemek istediğinizin ID sini seçin güncelleyin

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security = True");
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT SupplierID, CompanyName, ContactName, ContactTitle FROM Suppliers";
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string ad = reader.GetString(1);
                    string yetkili = reader.GetString(2);
                    string yetkiliUnvan = reader.GetString(3);
                    Console.WriteLine($"{id} - {ad} - {yetkili} - {yetkiliUnvan}");
                }
                reader.Close();

                Console.WriteLine("Lütfen bilgileri güncellenecek tedarikçi numarasını yazınız.");
                int tedid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Lütfen firma adı giriniz.");
                string FirmaAdi = Console.ReadLine();

                Console.WriteLine("Lütfen Yetkili giriniz.");
                string Yetkili = Console.ReadLine();

                Console.WriteLine("Lütfen yetkili ünvanı giriniz.");
                string Unvan = Console.ReadLine();

                cmd.CommandText = "UPDATE Suppliers SET CompanyName = @FirmaAdi, ContactName = @Yetkili, ContactTitle = @YetkiliUnvan WHERE SupplierID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FirmaAdi", FirmaAdi);
                cmd.Parameters.AddWithValue("@Yetkili", Yetkili);
                cmd.Parameters.AddWithValue("@YetkiliUnvan", Unvan);
                cmd.Parameters.AddWithValue("@id", tedid);

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Bir hata oluştu.");
            }
            finally
            {
                con.Close();
            }


            #endregion
        }
    }
}
