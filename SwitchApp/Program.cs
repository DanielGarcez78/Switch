using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using Switch.Infra.CrossCutting.Logging;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SwitchApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("Server=localhost;userid=root;password=root;database=SwitchDB;", m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {

                Usuario CriarUsuario(string nome)
                {
                    return new Usuario()
                    {
                        Nome = nome,
                        SobreNome = "SobreNomeUsuario",
                        Email = "usuario@email.com",
                        DataNascimento = Convert.ToDateTime("08/24/1978"),
                        Genero = Switch.Domain.Enum.GeneroEnum.Masculino,
                        Senha = "123456"
                    };
                }

                //var usuario1 = CriarUsuario("usuario1");
                //var usuario2 = CriarUsuario("usuario2");
                //var usuario3 = CriarUsuario("usuario3");
                //var usuario4 = CriarUsuario("usuario4");
                //var usuario5 = CriarUsuario("usuario5");
                //var usuario6 = CriarUsuario("usuario6");
                //var usuario7 = CriarUsuario("usuario7");
         
                using (var dbContext = new SwitchContext(optionsBuilder.Options))
                {
                    //dbContext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //var usuario123 = CriarUsuario("Usuario123");
                    //var usuario124 = CriarUsuario("Usuario123");

                    //dbContext.Usuarios.Add(usuario123);
                    //dbContext.Usuarios.Add(usuario124);

                    //dbContext.SaveChanges();

                    var totalUsuarios = dbContext.Usuarios.Count(u => u.Nome == "Usuario123");
                    Console.WriteLine("Total de Usuarios Antes: " + totalUsuarios.ToString());

                    Console.WriteLine("Excluindo usuario...");
                    var usuarioMorto = dbContext.Usuarios.FirstOrDefault(u => u.Nome == "Usuario123");
                    if (usuarioMorto != null)
                    {
                        dbContext.Usuarios.Remove(usuarioMorto);
                        dbContext.SaveChanges();
                    }

                    totalUsuarios = dbContext.Usuarios.Count(u => u.Nome == "Usuario123");
                    Console.WriteLine("Total de Usuarios Depois: " + totalUsuarios.ToString());





                    //var usuario0 = CriarUsuario("usuario0");
                    //Console.WriteLine("Criando usuario0...");
                    //Console.WriteLine("Verificando o ChangeTracker de usuario0");
                    //dbContext.Usuarios.Add(usuario0);
                    //ExibirChangeTracker(dbContext.ChangeTracker);

                    //////Obtendo
                    //var usuario1 = dbContext.Usuarios.FirstOrDefault(u => u.Nome == "usuarioNovo1");
                    //Console.WriteLine("Obtendo usuarioNovo1...");
                    //Console.WriteLine("Verificando o ChangeTracker de usuarioNovo1");
                    //ExibirChangeTracker(dbContext.ChangeTracker);

                    ////// Editando
                    //Console.WriteLine("Editando usuarioNovo1");
                    //usuario1.Nome = "NovoNomeUsuario";
                    //Console.WriteLine("Verificando o ChangeTracker de usuarioNovo1");
                    //ExibirChangeTracker(dbContext.ChangeTracker);

                    ////// Adicionando Novo
                    //var usuarioNovo2 = CriarUsuario("usuarioNovo2");
                    //Console.WriteLine("Criando usuarioNovo2");
                    //dbContext.Usuarios.Add(usuarioNovo2);
                    //Console.WriteLine("Verificando o ChangeTracker de usuarioNovo2");                    
                    //ExibirChangeTracker(dbContext.ChangeTracker);

                    ////Desanexado
                    //var usuario3 = CriarUsuario("Usuairo3");
                    //Console.WriteLine("Status do Usuario3");
                    //Console.WriteLine(dbContext.Entry(usuario3).State);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-----------------EXCEPTION--------------");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
                Console.WriteLine("----------------------------------------");
                if (e.InnerException != null)
                {
                    Console.WriteLine("------------INNER EXCEPTION-------------");
                    Console.WriteLine(e.InnerException.Message);
                    Console.WriteLine(e.InnerException.StackTrace);
                    Console.WriteLine(e.InnerException.Source);
                    Console.WriteLine("----------------------------------------");
                }                
            }

            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }

        private static void AtualizarDadosContato(Usuario usario)
        {

        }

        public static void ExibirChangeTracker(ChangeTracker changeTracker)
        {
            foreach(var entry in changeTracker.Entries())
            {
                Console.WriteLine("Nome da Entidade: " + entry.Entity.GetType().FullName);
                Console.WriteLine("Status da Entidade: " + entry.State);
                Console.WriteLine("-------------------------");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
