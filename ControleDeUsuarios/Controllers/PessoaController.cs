using SistemaDeCadastro.Models;
using SistemaDeCadastro.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public IActionResult Index()
        {
          List<PessoaModel> pessoas = _pessoaRepositorio.BuscarTodos();
            return View(pessoas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
          PessoaModel pessoa = _pessoaRepositorio.ListarPorId(id);
            return View(pessoa);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            PessoaModel pessoa = _pessoaRepositorio.ListarPorId(id);
            return View(pessoa);
        }

        public IActionResult Apagar (int id)
        {
            try
            {
                bool apagado = _pessoaRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Pessoa apagada com sucesso!"; 
                else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar a pessoa, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar a pessoa, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(PessoaModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pessoa = _pessoaRepositorio.Adicionar(pessoa);

                    TempData["MensagemSucesso"] = "Pessoa cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(pessoa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar a pessoa, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(PessoaModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pessoa = _pessoaRepositorio.Atualizar(pessoa);

                    TempData["MensagemSucesso"] = "Pessoa alterada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(pessoa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar a pessoa, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
