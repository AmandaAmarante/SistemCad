using SistemaDeCadastro.Data;
using SistemaDeCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PessoaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PessoaModel ListarPorId(int id)
        {
            return _bancoContext.Pessoas.FirstOrDefault(x => x.Id == id);
        }

        public List<PessoaModel> BuscarTodos()
        {
            return _bancoContext.Pessoas.ToList();
        }
        public PessoaModel BuscarPorCPF(string cpf)
        {
            return _bancoContext.Pessoas.FirstOrDefault(p => p.CPF == cpf);
        }
        public PessoaModel Adicionar(PessoaModel pessoa)
        {
            // gravar no banco de dados
            _bancoContext.Pessoas.Add(pessoa);
            _bancoContext.SaveChanges();
            return pessoa;
        }

        public PessoaModel Atualizar(PessoaModel pessoa)
        {
            PessoaModel usuarioDB = ListarPorId(pessoa.Id);
            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do pessoa");
            usuarioDB.Nome = pessoa.Nome;
            usuarioDB.CPF = pessoa.CPF;
            usuarioDB.DataNascimento = pessoa.DataNascimento;
            usuarioDB.Email = pessoa.Email;

            _bancoContext.Pessoas.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            PessoaModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do pessoa");
            _bancoContext.Pessoas.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
