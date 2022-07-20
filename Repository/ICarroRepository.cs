using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICarroRepository
    {
        public IEnumerable<Carro>ListAllCars();
        public IEnumerable<Carro> FindAllCarsByName(string carroName);    
        public Carro FindCarsById(int id);
        public void CreateCar(int id, string ano, string modelo, string potencia);
        public void UpdateCar(Carro carro);
        public void DeleteCar(int id);
        public int GetCarListSize();

    }
}
