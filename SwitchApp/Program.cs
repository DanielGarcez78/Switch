using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using System;

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
                //var usuario = new Usuario() {
                //    Nome = "Usuario1",
                //    SobreNome = "SobreNomeUsuario",
                //    Email ="usuario@email.com",
                //    DataNascimento = Convert.ToDateTime("08/24/1978"),
                //    Genero = Switch.Domain.Enum.GeneroEnum.Masculino,
                //    Senha="123456"
                //};

                var acesso = new Acesso()
                {
                    Descricao = "Teste"
                };

                using (var dbContext = new SwitchContext(optionsBuilder.Options))
                {
                    //dbContext.Usuarios.Add(usuario);
                    dbContext.Acessos.Add(acesso);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                    Console.WriteLine(e.InnerException.StackTrace);
                }                
            }

            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}
