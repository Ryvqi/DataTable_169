using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace KoneksiDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strKoneksi = "Data Source = METEORITE\\SQL2019; " +
                "Initial Catalog = Pendataan Kematian; Integrated Security = True;";
            string strKoneksiSA = "Data Source = METEORITE\\SQL2019; " +
                "Initial Catalog = PacarJadi;User ID = sa; Password = meteorite";
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1, Koneksi Menggunakan Windows Authentication");
                    Console.WriteLine("2. Koneksi Menggunakan SQL Server Authentication");
                    Console.WriteLine("3, Buat Database PacarJadi");
                    Console.WriteLine("4. Buat Tabel DataPacar");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("\nEnter your Choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (ch)
                    {
                        case '1':
                            {
                                try
                                {
                                    
                                    SqlConnection koneksi = new SqlConnection();
                                    koneksi.ConnectionString = strKoneksi;
                                    koneksi.Open();
                                    if (koneksi.State == ConnectionState.Open)
                                    {
                                        koneksi.Close();
                                    }
                                    Console.WriteLine("Koneksi Berhasil");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Periksa Kembali Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '2':
                            {
                                try
                                {
                                    SqlConnection koneksi = new SqlConnection();
                                    koneksi.ConnectionString = strKoneksiSA;
                                    koneksi.Open();
                                    if (koneksi.State == ConnectionState.Open)
                                    {
                                        koneksi.Close();
                                    }
                                    Console.WriteLine("Koneksi Berhasil");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Prikasa Kembali Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '3':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksi;

                                string str = "CREATE DATABASE PacarJadi ON PRIMARY" +
                                    "(NAME = PacarJadi_Data, " +
                                    "FILENAME = 'D:\\PADB\\New folder\\PacarJadiData.mdf', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                                    "LOG ON (NAME = PacarJadi_Log, " +
                                    "FILENAME = 'D:\\PADB\\New folder\\PacarJadiLog.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Database Berhasil Dibuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '4':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TABLE DataPacar(" +
                                    "KD_PCR INT PRIMARY KEY IDENTITY," +
                                    "NmPCR VARCHAR(20)," +
                                    "NoTlpn CHAR(13)," +
                                    "AlmtPCR VARCHAR(50)," +
                                    "JK CHAR(1) CONSTRAINT CKJK CHECK(JK LIKE 'P' OR JK LIKE 'L')," +
                                    "STSHBG CHAR(5) CONSTRAINT CKSTS CHECK(STSHBG LIKE 'PUTUS' OR STSHBG LIKE 'MASIH')," +
                                    "MASANHBG VARCHAR(10)" +
                                    ")";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Tabel Berhasil Dibuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nOpsi tidak valid");
                                break;
                            }
                    }
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nPeriksa angka yang dimasukkan. \n" + e.Message.ToString());
                }
            }
        }
    }
}