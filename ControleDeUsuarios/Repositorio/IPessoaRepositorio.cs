using SistemaDeCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Repositorio
{
  public interface IPessoaRepositorio
    {
        PessoaModel ListarPorId(int id);
        List<PessoaModel> BuscarTodos();
        PessoaModel Adicionar(PessoaModel pessoa);
        PessoaModel Atualizar(PessoaModel pessoa);
        PessoaModel BuscarPorCPF(string cpf);
        bool Apagar(int id);
    }
}
