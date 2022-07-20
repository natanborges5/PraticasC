using Model;

namespace Repository
{
    public class CarroRepository : ICarroRepository
    {
        static List<Carro> carroList = new List<Carro>();

        public void CreateCar(int id, string ano, string modelo, string potencia)
        {
            var newCarro = new Carro()
            {
                Id = id,
                Ano = ano,
                Modelo = modelo,
                Potencia = potencia,

            };
            carroList.Add(newCarro);
        }

        public void DeleteCar(int id)
        {
            var carro = FindCarsById(id);
            carroList.Remove(carro);
        }

        public IEnumerable<Carro> FindAllCarsByName(string carroName)
        {
            List<Carro> listCarByName = new List<Carro>();
            foreach (Carro cars in carroList)
            {
                if (cars.Modelo.Contains(carroName))
                {
                    listCarByName.Add(cars);
                }
            }
            return listCarByName;
        }

        public Carro FindCarsById(int id)
        {
            var carro = new Carro();
            foreach (Carro car in carroList)
            {
                if(car.Id == id)
                {
                    carro = car;
                }
            }
            return carro;
        }

        public int GetCarListSize()
        {
            var size = carroList.Count();
            return size;
        }

        public IEnumerable<Carro> ListAllCars()
        {
            return carroList;
        }

        public void UpdateCar(Carro carro)
        {
            var contador = 0;
            foreach(Carro car in carroList)
            {
                if(car.Id == carro.Id)
                {
                    if(carro.Modelo != "")
                    {
                        car.Modelo = carro.Modelo;
                    }
                    if(carro.Potencia != "")
                    {
                        car.Potencia = carro.Potencia;
                    }
                    if(carro.Ano != "")
                    {
                        car.Ano = carro.Ano;
                    }
                    break;
                }
                contador++;
            }

        }
    }
}