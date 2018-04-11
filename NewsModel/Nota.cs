using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;

namespace NewsModel
{
    public class Nota
    {
        public int Notaid { get; set; }        
        public string  Titulo { get; set; }
        public string  Reportero { get; set; }
        public string Seccion { get; set; }
        public string Categoria  { get; set; }
        public DateTime Fecha { get; set; }
        public string  Ubicacion { get; set; }
        public string Relevancia { get; set; }
        public string Espacio { get; set; }
        public string Archivo { get; set; }
        public string Dimensiones { get; set; }
        public decimal Precio { get; set; }
        public char Privacidad { get; set; }
        public string DiarioImpreso { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}
