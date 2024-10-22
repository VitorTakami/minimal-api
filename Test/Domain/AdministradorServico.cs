using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Entidades
{
    [TestClass]
    
    public class AdministradorServicoTest
    {

        //public DbContexto Context { get; }

        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", "..", ".."));
        
            var builder = new ConfigurationBuilder()
                //.SetBasePath(path ?? Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory))
                .AddJsonFile("/home/vtakami/Documents/Cursos/FullStackDeveloper-dotnet/ConstruindoAPIs/MinimalsAPIs/minimal-api/Test/appsettings.json", optional:false, reloadOnChange: true)
                
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("Truncate Table Administradores");

            var adm = new Administrador();
            adm.Id=1;
            adm.Email="teste@teste.com";
            adm.Senha="teste";
            adm.Perfil="Adm";
            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);
            var admDoBanco = administradorServico.BuscaPorId(adm.Id);

            // Assert
            Assert.AreEqual(1, admDoBanco.Id);
            //Assert.AreEqual("teste@teste.com", adm.Email);
            //Assert.AreEqual("teste", adm.Senha);
            //Assert.AreEqual("Adm", adm.Perfil);
            
        }
        
    }
}
