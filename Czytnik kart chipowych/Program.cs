using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PCSC;
using PCSC.Exceptions;
using PCSC.Utils;

namespace ConsoleApplication1
{
    class Program
    {
        private static SCardError err;              
        private static SCardReader reader;          
        private static System.IntPtr protocol;
        private static SCardContext hContext;
        static bool Connected = false;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter - Sprobój sie połączyć.");
                Console.ReadLine();
                try
                {
                    connect();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nie udało się połączyć, wiadomość błędu:" + e.Message);
                }
            }

            while (true)
            {
                Console.WriteLine("Wybierz akcję:");
                Console.WriteLine("1.SELECT TELECOM");
                Console.WriteLine("2.SELECT SMS");
                Console.WriteLine("3.READ RECORD");
                Console.WriteLine("4.Zakończ");
                Console.WriteLine("\nTwoj wybór: ");
                string wybor = Console.ReadLine();
                try
                {
                    byte[] commandBytes;
                    if (wybor == "1")
                    {
                        byte[] response4 = new byte[256];
                        commandBytes = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 };
                        sendCommand(commandBytes, "SELECT TELECOM");

                        commandBytes = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3A };
                        var response2 = sendCommand(commandBytes, "SELECT TELECOM");

                        commandBytes = new byte[] { 0xA0, 0xC0, 0x00, 0x00, response2[1] };
                        var response3 = sendCommand(commandBytes, "SELECT TELECOM");

                        for (byte i = 1; i < response3[14]; i++)
                        {

                            byte[] record = { 0xA0, 0xB2, i, 0x04, response3[14] };
                            response4 = sendCommand(record, "SELECT TELECOM");
                            foreach (byte bb in response4)
                            {
                                if (bb > 0x19 && bb < 0x7B)
                                {
                                    char anwser = Convert.ToChar(bb);
                                    Console.Write(anwser);
                                }
                                else Console.Write("{0:X2} ", bb);
                            }
                            Console.Write("\n");
                        }
                        Console.ReadKey();
                    }
                    else if (wybor == "2")
                    {
                        commandBytes = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C };
                        var response = sendCommand(commandBytes, "SELECT SMS");

                        commandBytes = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x0F };
                        sendCommand(commandBytes, "GET RESPONSE");

                        commandBytes = new byte[] { 0xA0, 0xB2, 0x01, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");


                        foreach (byte bb in response)
                        {
                            if (bb > 0x19 && bb < 0x7B)
                            {
                                char anwser = Convert.ToChar(bb);
                                Console.Write(anwser);
                            }
                            else
                            {
                                Console.Write("{0:X2} ", bb);
                            }
                        }
                        Console.Write("\n");
                        Console.ReadKey();
                    }


                    else if (wybor == "3")
                    {
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x00, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x01, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x02, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x03, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x04, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x05, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x06, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x07, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                        commandBytes = new byte[] { 0xA0, 0xB2, 0x08, 0x04, 0xB0 };
                        sendCommand(commandBytes, "READ RECORD");
                    }
                    else if (wybor == "4")
                    {
                        hContext.Release();
                        break;
                    }
                }
                catch (PCSCException ex)
                {
                    Console.WriteLine("Blad: " + ex.Message + " (" + ex.SCardError.ToString() + ")");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Nieznany blad, wiadomość wyjątku: " + e.Message);
                }
                Console.WriteLine("\n");
            }
        }

        public static void connect()
        {
            hContext = new SCardContext();  //defincja kontekstu            
            hContext.Establish(SCardScope.System);  // przekazanie kontekstu do zarządcy 

            string[] readerList = hContext.GetReaders();    // lista czytników            
            Boolean noReaders = readerList.Length <= 0;
            if (noReaders)
            {
                throw new PCSCException(SCardError.NoReadersAvailable, "Blad czytnika");
            }

            Console.WriteLine("Nazwa czytnika: " + readerList[0]);

            reader = new SCardReader(hContext); // definicja czytnika 

            err = reader.Connect(readerList[0], SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);
            checkError(err);                            // sprawdza, czy przypisanie sie powiodło 


            switch (reader.ActiveProtocol)  // wybór protokołu      
            {
                case SCardProtocol.T0:
                    protocol = SCardPCI.T0;
                    break;
                case SCardProtocol.T1:
                    protocol = SCardPCI.T1;
                    break;
                default:
                    throw new PCSCException(SCardError.ProtocolMismatch, "nieobslugiwany protokol: " + reader.ActiveProtocol.ToString());
            }
            Connected = true;
        }


        public static byte[] sendCommand(byte[] comand, String name)
        {
            byte[] recivedBytes = new byte[256];
            err = reader.Transmit(protocol, comand, ref recivedBytes);  //przesyła dane APDU do karty, zwraca błąd :|         
            checkError(err);    //sprawdza czy wystąpił błąd   
            writeResponse(recivedBytes, name);
            return recivedBytes;
        }

        public static void writeResponse(byte[] recivedBytes, String responseCode)
        {
            Console.Write(responseCode + ": ");
            for (int i = 0; i < recivedBytes.Length; i++)
            {
                Console.Write("{0:X2} ", recivedBytes[i]);
            }
            Console.WriteLine();
        }

        static void checkError(SCardError err)
        {
            if (err != SCardError.Success)
            {
                throw new PCSCException(err, SCardHelper.StringifyError(err));
            }
        }

    }
}


