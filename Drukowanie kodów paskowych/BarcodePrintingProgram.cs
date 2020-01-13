using Spire.Barcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kody_Kreskowe
{
    public class BarcodePrintingProgram
    {
        Image barcode_img;
        public void Main()
        {
            Console.WriteLine("Wprowadz 12 cyfrowy kod EAN-13, który chcesz wydrukowac");
            Boolean check = false;
            string code = "";
            while (check == false)
            {
                code = Console.ReadLine();
                if (code.Count() == 12)
                {
                    check = true;
                    Console.WriteLine("Rozpoczynanie drukowania");
                }
                else
                {
                    if (code.Count() < 12)
                    {
                        Console.WriteLine("Wprowadzono za krótki kod, spróbuj jeszcze raz");
                    }
                    if (code.Count() > 12)
                    {
                        Console.WriteLine("Wprowadzono za długi kod, spróbuj jeszcze raz");
                    }
                }
            }
            generateBarcode(code);
            printBarcode(code);
            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć");
            Console.ReadKey();
        }


        public void generateBarcode(string code)
        {
            code = code.Trim();

            var bar_code_generator = new BarCodeGenerator(new BarcodeSettings()
            {
                Type = BarCodeType.EAN13,
                BackColor = Color.White,
                ForeColor = Color.Black,

                Data = code,
                ShowText = true,
                ShowTextOnBottom = true,
                UseChecksum = CheckSumMode.ForceEnable,
                TextAlignment = StringAlignment.Center,

            });

            // Obraz kodu kreskowego
            barcode_img = bar_code_generator.GenerateImage();
            barcode_img = cropImage(barcode_img, new Rectangle(0, 15, barcode_img.Width, barcode_img.Height - 15));

        }

        public void printBarcode(string code)
        {
            // sprawdzenie czy jest co drukować
            if (barcode_img == null)
            {
                Console.WriteLine("Rysunek kodu paskowego nie zostal wygenerowany");
                return;
            }

            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(barcode_img, typeof(byte[]));

            // drukowany dokument do przekazania do druku
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);

            // otworzenie menu drukowania
            PrintDialog pdi = new PrintDialog();
            pdi.Document = pd;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                pd.Print(); // drukowanie
            }
            else
            {
                Console.WriteLine("Drukowanie zostało anulowane ");
            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmp_image = new Bitmap(img);
            return bmp_image.Clone(cropArea, bmp_image.PixelFormat);
        }


        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                // rozmiar obrazka
                Rectangle m = e.MarginBounds;
                m.Height = 300;
                m.Width = 600;

                // drukowanie kodu kreskowego
                System.Drawing.Image image = barcode_img;
                e.Graphics.DrawImage(image, m);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
