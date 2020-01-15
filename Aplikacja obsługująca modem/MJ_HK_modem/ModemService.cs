using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJ_HK_modem
{
    class ModemService
    {

    }


    public class SerialPortDriver
    {
        private SerialPort serialPort;
        private SerialDataReceivedEventHandler dataReceived;
        private int packetCount;
        private int currentPacket;
        private bool firstPacket;
        private FileStream stream;

        public SerialPortDriver(SerialDataReceivedEventHandler dataReceived)
        {
            this.dataReceived = dataReceived;
        }

        public string[] GetAvailablePortList()
        {
            return SerialPort.GetPortNames();
        }

        public bool Connect(string portName)
        {
            if (serialPort != null)
                if (serialPort.IsOpen) serialPort.Close();

            try
            {
                serialPort = new SerialPort(portName);
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Handshake = Handshake.RequestToSend;
                serialPort.DtrEnable = true;
                serialPort.NewLine = "\r\n";
                serialPort.DataReceived += dataReceived;
                serialPort.Open();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (serialPort != null)
                if (serialPort.IsOpen) serialPort.Close();
        }

        public void TransmitData(string data)
        {
            serialPort.WriteLine(data);
        }

        public void TransmitFile(string filepath)
        {
            var data = File.ReadAllBytes(filepath);
            byte[] packetCount = { (byte)Math.Ceiling(data.Length / 512.0f) };
            serialPort.Write(packetCount, 0, 1);

            int currentPacket = 0;
            while (currentPacket < packetCount[0])
            {
                serialPort.Write(data, currentPacket * 512, 512);
            }
        }

        public void ReceiveFile(string filepath)
        {
            currentPacket = 0;
            packetCount = 0;
            firstPacket = true;

            serialPort.DataReceived -= dataReceived;
            serialPort.DataReceived += FileDataReceived;
        }

        public void FileDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = (SerialPort)sender;
            var data = serial.ReadExisting();
            if (firstPacket)
            {
                packetCount = data[0];
                firstPacket = false;
            }
            else
            {
                while (currentPacket < packetCount)
                {
                    byte[] packetData = new byte[512];
                    serialPort.Read(packetData, 0, 512);
                    stream.Write(packetData, 0, 512);
                    currentPacket++;
                }
                stream.Close();
                serialPort.DataReceived -= FileDataReceived;
                serialPort.DataReceived += dataReceived;
            }
        }
    }

}
