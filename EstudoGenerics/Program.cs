using System;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Id = 1;
            pessoa.Nome = "TreinaWeb";

            Animal animal = new Animal();
            animal.Id = 1;
            animal.Especie = "Cachorro";
            RepositorioGenerico<Pessoa> repositorioPessoa = new RepositorioGenerico<Pessoa>();
            RepositorioGenerico<Animal> repositorioAnimal = new RepositorioGenerico<Animal>();
          

            repositorioPessoa.Insert(pessoa);
            repositorioAnimal.Insert(animal);

            foreach (Pessoa p in repositorioPessoa.Get())
            {
                Console.WriteLine("Nome da pessoa: " + p.Nome);
            }

            foreach (Animal a in repositorioAnimal.Get())
            {
                Console.WriteLine("Nome do animal: "  + a.Especie);
            }
        }

    }
}
