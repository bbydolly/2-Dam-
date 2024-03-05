namespace Ej_4
{
    //VALIDADO 
   //queda control de excepciones en infoBmp ==a isBmp
   //Puedo hacer una función, usando delegados que me gestione las excepciones e ir llamándola con distintas funciones 
    internal class BMP
    {
        public String ruta;
        public BMP(String ruta)
        {
            this.ruta = ruta;

        }
        public bool IsBmp()
        {
            if (File.Exists(ruta))
            {
                try
                {

                    using (FileStream fs = new FileStream(ruta, FileMode.Open))
                    {

                        string format = ((char)fs.ReadByte()).ToString() + ((char)fs.ReadByte()).ToString();

                        if (format == "BM") ///sEGUIR AQUÍ
                        {
                            FileInfo fi = new FileInfo(ruta);
                            int tArchivo_BMP = (int)fi.Length;
                           // Console.WriteLine("Tamaño del archivo: " + tArchivo_BMP);
                            //Lectura de 4 bytes desde la posicion 2-> 2,3,4,5
                            BinaryReader br = new BinaryReader(fs);  //using
                            fs.Seek(2, SeekOrigin.Begin); //esto sitúa el cursor en la posición que quiero
                            int t = br.ReadInt32();//leo 4 bytes, cada bytes ocupa max 255
                                                   //Console.WriteLine("t vale: " + t);--->coindicen los tamaños

                            if (tArchivo_BMP == t)
                            {
                                // InfoBmp();
                                return true;
                            }
                            else
                            {
                                return false;
                            }


                        }

                    }
                }
                catch (IOException ioex)
                {

                    Console.WriteLine("El archivo está siendo usado");
                }
            }
            return false;


        }
        public Object InfoBmp()
        {
            //Contro excep
            ObjectoBMP ob1;
            bool is_or_not = IsBmp();
            if (is_or_not)
            {
                using (BinaryReader br = new BinaryReader(new FileStream(ruta, FileMode.Open)))
                {
                    br.BaseStream.Seek(18, SeekOrigin.Begin);//ANCHO píxeles
                    int ancho = br.ReadInt32();

                    br.BaseStream.Seek(22, SeekOrigin.Begin);//ALTO píxeles, 22--s la posición en decimal
                    int alto = br.ReadInt32();

                    br.BaseStream.Seek(30, SeekOrigin.Begin);//COMPRESION
                    int compresion = br.ReadInt32();
                    bool aux_compresion = false;
                    if (compresion == 0)
                    {
                        aux_compresion = true;
                        //No está comprimido
                    }

                    //bits por pixel
                    br.BaseStream.Seek(28, SeekOrigin.Begin);//bits por píxeles
                    int bits_pixel = br.ReadInt16();

                    ob1 = new ObjectoBMP(ancho, alto, aux_compresion, bits_pixel);


                    return ob1;

                }
            }
            else
            {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                return null; //?si
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
            }

        }
    }
}
