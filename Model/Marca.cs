using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        public IEnumerable<Carro> Carros { get; set; }
    }
}
