using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "";
            Console.WriteLine("Wprowadz adres IP urządzenia analizującego:");
            ip = Console.ReadLine();
            TcpClient connection = new TcpClient();
            NetworkStream stream;
            try
            {
                connection.Connect(ip, 502);
                stream = connection.GetStream();
                ModbusClient modClient;
                modClient = new ModbusClient(ip, 502);
            }
            catch(SocketException error)
            {
                Console.WriteLine("Nie można się połączyć, wiadomość exception: " + error.Message);
                return;
            }


            string napiecie, natezenie, moc, faza;
            byte[] zapytanie;
            byte[] odpowiedz = new byte[100];
            byte[] odpowiedz_wartosc = new byte[4];
            string wartosc_hex;
            int wartosc_dec;


            while (true)
            {
                Console.Clear();

                ///////////////  ***  Napięcie ***  ///////////////
                zapytanie = new byte[] { 0x06, 0x10, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x10, 0x02, 0x00, 0x07 };
                stream.Write(zapytanie, 0, zapytanie.Length);
                stream.Read(odpowiedz, 0, odpowiedz.Length);
                Array.ConstrainedCopy(odpowiedz, 9, odpowiedz_wartosc, 0, 4);
                wartosc_hex = BitConverter.ToString(odpowiedz_wartosc).Replace("-", String.Empty);
                wartosc_dec = int.Parse(wartosc_hex, System.Globalization.NumberStyles.HexNumber);
                napiecie = "Napiecie: " + (float)wartosc_dec / 1000 + " V";
                ///////////////  ***  Napięcie ***  ///////////////


                ///////////////  ***  Natężenie ***  ///////////////
                zapytanie = new byte[] { 0x06, 0x10, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x10, 0x10, 0x00, 0x07 };
                stream.Write(zapytanie, 0, zapytanie.Length);
                byte[] odpowiedz_natezenie = new byte[100];
                stream.Read(odpowiedz_natezenie, 0, odpowiedz_natezenie.Length);
                Array.ConstrainedCopy(odpowiedz_natezenie, 9, odpowiedz_wartosc, 0, 4);
                wartosc_hex = BitConverter.ToString(odpowiedz_wartosc).Replace("-", "");
                wartosc_dec = int.Parse(wartosc_hex, System.Globalization.NumberStyles.HexNumber);
                natezenie = "Natezenie: " + (float)wartosc_dec / 1000 + " A";
                ///////////////  ***  Natężenie ***  ///////////////


                ///////////////  ***  Faza ***  ///////////////   
                zapytanie = new byte[] { 0x06, 0x10, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x10, 0x20, 0x00, 0x07 };
                stream.Write(zapytanie, 0, zapytanie.Length);
                odpowiedz = new byte[100];
                stream.Read(odpowiedz, 0, odpowiedz.Length);
                Array.ConstrainedCopy(odpowiedz, 9, odpowiedz_wartosc, 0, 4);
                wartosc_hex = BitConverter.ToString(odpowiedz_wartosc).Replace("-", "");
                wartosc_dec = int.Parse(wartosc_hex, System.Globalization.NumberStyles.HexNumber);
                faza = "Faza: " + (float)wartosc_dec / 1000;
                ///////////////  ***  Faza ***  ///////////////


                ///////////////  ***  Moc ***  ///////////////
                zapytanie = new byte[] { 0x06, 0x10, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x10, 0x30, 0x00, 0x07 };
                stream.Write(zapytanie, 0, zapytanie.Length);
                odpowiedz = new byte[100];
                stream.Read(odpowiedz, 0, odpowiedz.Length);
                Array.ConstrainedCopy(odpowiedz, 9, odpowiedz_wartosc, 0, 4);
                wartosc_hex = BitConverter.ToString(odpowiedz_wartosc).Replace("-", "");
                wartosc_dec = int.Parse(wartosc_hex, System.Globalization.NumberStyles.HexNumber);
                moc = "Moc: " + (float)wartosc_dec / 1000 + "kW";
                ///////////////  ***  Moc ***  ///////////////


                Console.WriteLine(napiecie);
                Console.WriteLine(natezenie);
                Console.WriteLine(moc);
                Console.WriteLine(faza);

                if (Console.ReadLine() == "q")
                {
                    break;
                }
            }
        }
    }
}
