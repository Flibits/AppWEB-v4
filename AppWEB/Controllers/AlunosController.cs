using AppWEB.Data.Repositório.Interface;
using AppWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppWEB.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConfiguration _configuration;
        
        public AlunosController(IAlunoRepositorio alunoRepositorio, IConfiguration configuration)
        {
            _alunoRepositorio = alunoRepositorio;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            try
            {
                var alunos = _alunoRepositorio.BuscarAlunos();
                return View(alunos);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao conectar com o banco de dados";
                return View();
            }
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult EditarAluno(AlunoModel alunos)
        {
            _alunoRepositorio.EditarAluno(alunos);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            return View("Editar", aluno);
        }

        public IActionResult InserirAluno(AlunoModel alunos)
        {
            try
            {
                _alunoRepositorio.InserirAluno(alunos);
                TempData["MensagemSucesso"] = "Aluno adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                throw;     
            }      
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            
                cep = cep.Replace("-", "");

                EnderecoModel enderecoModel = new EnderecoModel();

                using var client = new HttpClient();

                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                }

                return View("Endereco", enderecoModel);
                         
        }

    }
}
