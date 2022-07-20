using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticasC
{
    public class Menu
    {
        public void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("1- Listar todos os carros");
                Console.WriteLine("2- Procurar um carro");
                Console.WriteLine("3- Gerenciar carros");
                Console.WriteLine("4- Sair");
                char escolha = Console.ReadLine().ToCharArray()[0];
                Console.Clear();
                if (escolha == '1')
                {
                    ListarCarros();
                }
                else if (escolha == '2')
                {
                    listarCarrosPorNome();

                }
                else if (escolha == '3')
                {
                    Console.WriteLine("1- Cadastrar Carro");
                    Console.WriteLine("2- Editar Carro");
                    Console.WriteLine("3- Deletar Carro");
                    char opcao = Console.ReadLine().ToCharArray()[0];
                    if(opcao == '1')
                    {
                        CadastrarCarro();
                    }
                    else if(opcao == '2')
                    {
                        EditarCarro();
                    }
                    else if (opcao == '3')
                    {

                        DeletarCarro();
                    }
                    else
                    {
                        Console.WriteLine(opcao + " Operacao invalida");
                    }

                }
                else if (escolha == '4')
                {
                    Console.WriteLine("Encerrando programa...");
                    break;
                }
                else
                {
                    Console.WriteLine("Operacao invalida, selecione novamente");

                }
            }

        }

        private void DeletarCarro()
        {
            Console.WriteLine("Digite o carro que deseja deletar: ");
            var id = Int32.Parse(Console.ReadLine());
            var carro = CarroRepository.FindCarsById(id);
            Console.WriteLine("Deseja apagar o carro " + carro.Modelo + " ano " + carro.Ano + " ?");
            Console.WriteLine("S - Para aceitar");
            Console.WriteLine("N - Para cancelar");
            var escolha = Console.ReadLine().ToLower();
            if(escolha == "s")
            {
                CarroRepository.DeleteCar(id);
            }
            else
            {
                Console.WriteLine("Voltando...");
            }
            
        }

        public void CadastrarCarro()
        {
            Console.Clear();
            Console.WriteLine("Adicionando Carro ao Sistema!");
            int id = CarroRepository.GetCarListSize() + 1;
            Console.WriteLine("Modelo do carro: ");
            var modelo = Console.ReadLine();
            Console.WriteLine("Ano do carro: ");
            var ano = Console.ReadLine();
            Console.WriteLine("Potencia do carro: ");
            var potencia = Console.ReadLine();
            CarroRepository.CreateCar(id, ano, modelo, potencia);
        }
        public void EditarCarro()
        {
            Console.Clear();
            ListarCarros();
            Console.WriteLine("Qual ID do carro que deseja alterar?: ");
            var id = Int32.Parse(Console.ReadLine());

            Carro carro = new Carro();
            carro.Id = id;
            Console.WriteLine("Modelo do carro: ");
            carro.Modelo = Console.ReadLine();
            Console.WriteLine("Ano do carro: ");
            carro.Ano = Console.ReadLine();
            Console.WriteLine("Potencia do carro: ");
            carro.Potencia = Console.ReadLine();
            
            
            CarroRepository.UpdateCar(carro);

        }
        public void listarCarrosPorNome()
        {
            Console.WriteLine("Digite o nome do carro que deseja procurar: ");
            var carrofind = Console.ReadLine();
            var cars = CarroRepository.FindAllCarsByName(carrofind);
            Console.Clear();
            foreach (var car in cars)
            {
                Console.Write("Carro id: " + car.Id + "|");
                Console.Write("Modelo: " + car.Modelo + "|");
                Console.Write("Ano: " + car.Ano + "|");
                Console.Write("Potencia: " + car.Potencia);
                Console.WriteLine("");
            }
        }
        public void ListarCarros()
        {
            var cars = CarroRepository.ListAllCars();
            Console.Clear();
            if(cars.Count() == 0)
            {
                Console.WriteLine("Nenhum carro cadastrado no sistema");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.Write("Carro id: " + car.Id + "|");
                    Console.Write("Modelo: " + car.Modelo + "|");
                    Console.Write("Ano: " + car.Ano + "|");
                    Console.Write("Potencia: " + car.Potencia);
                    Console.WriteLine("");
                }
            }

        }
        public ICarroRepository CarroRepository
        {
            get { return new CarroRepository(); }
        }
    }
}
