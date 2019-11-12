using System;
using WMPLib;
using SharpDX;
using SharpDX.DirectSound;
using SharpDX.IO;
using SharpDX.Multimedia;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        private static WindowsMediaPlayer player;
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Direct sound");
            Console.WriteLine("2 - Windows media player");
            Console.WriteLine("Twój wybór:");
            string wartosc = Console.ReadLine();
            if (wartosc == "1")
            {
                Console.Write("Podaj nazwe pliku z pulpitu: ");
                string nazwa_pliku = Console.ReadLine();
                var path = "C:\\Users\\lab\\Desktop\\" + nazwa_pliku;
                DirectSound directSound = new DirectSound();

                var primaryBufferDesc = new SoundBufferDescription();
                primaryBufferDesc.Flags = BufferFlags.PrimaryBuffer;

                var primarySoundBuffer = new PrimarySoundBuffer(directSound, primaryBufferDesc);

                primarySoundBuffer.Play(0, PlayFlags.Looping);

                WaveFormat waveFormat = new WaveFormat();

                var secondaryBufferDesc = new SoundBufferDescription();
                secondaryBufferDesc.BufferBytes = waveFormat.ConvertLatencyToByteSize(60000);
                secondaryBufferDesc.Format = waveFormat;
                secondaryBufferDesc.Flags = BufferFlags.GetCurrentPosition2 | BufferFlags.ControlPositionNotify | BufferFlags.GlobalFocus |
                                            BufferFlags.ControlVolume | BufferFlags.StickyFocus;
                secondaryBufferDesc.AlgorithmFor3D = Guid.Empty;
                var secondarySoundBuffer = new SecondarySoundBuffer(directSound, secondaryBufferDesc);
                var capabilities = secondarySoundBuffer.Capabilities;

                //Stream stream = File.Open(path, FileMode.Open);
                //byte[] arrayTest = ReadFully(stream);
                byte[] array = File.ReadAllBytes(path);
                DataStream dataPart2;
                var dataPart1 = secondarySoundBuffer.Lock(0, capabilities.BufferBytes, LockFlags.EntireBuffer, out dataPart2);
                dataPart1.Read(array, 0, array.Length);
                int numberOfSamples = capabilities.BufferBytes / waveFormat.BlockAlign;
                for (int i = 0; i < numberOfSamples; i++)
                {
                    double vibrato = Math.Cos(2 * Math.PI * 10.0 * i / waveFormat.SampleRate);
                    short value = (short)(Math.Cos(2 * Math.PI * (220.0 + 4.0 * vibrato) * i / waveFormat.SampleRate) * 16384); // Not too loud
                    dataPart1.Write(value);
                }
                secondarySoundBuffer.Unlock(dataPart1, dataPart2);
                secondarySoundBuffer.Play(0, PlayFlags.None);
            }
            else
            {
                Console.Write("Podaj nazwe pliku z pulpitu: ");
                string nazwa_pliku = Console.ReadLine();
                player = new WindowsMediaPlayer();
                player.URL = "C:\\Users\\lab\\Desktop\\" + nazwa_pliku;
                player.controls.play();
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}

