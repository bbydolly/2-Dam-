namespace Ej_4
{

    //propfull tabulador tabulador-->set/get

    internal class ObjectoBMP
    {
        private int ancho_pixeles;

        public int Ancho_pixeles
        {
            get { return ancho_pixeles; }
            set { ancho_pixeles = value; }
        }

        private int alto_pixeles;

        public int Alto_pixeles
        {
            get { return alto_pixeles; }
            set { alto_pixeles = value; }
        }

        private bool compresion;

        public bool Compresion
        {
            get { return compresion; }
            set { compresion = value; }
        }

        private int bits_pixel;

        public int Bits_pixel
        {
            get { return bits_pixel; }
            set { bits_pixel = value; }
        }

        //Constructor
        public ObjectoBMP(int ancho, int alto, bool comprimido, int bits_pixel)
        {
            this.ancho_pixeles = ancho;
            this.alto_pixeles = alto;
            this.compresion = comprimido;
            this.bits_pixel = bits_pixel;

        }

        public void MostrarDatos()
        {
            Console.WriteLine("Ancho: " + ancho_pixeles);
            Console.WriteLine("Alto: " + alto_pixeles);
            Console.WriteLine("BMP comprimido: " + compresion);
            Console.WriteLine("Bits por píxel: " + bits_pixel);


        }




    }
}
