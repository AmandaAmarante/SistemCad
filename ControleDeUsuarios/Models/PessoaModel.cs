using System;
using System.ComponentModel.DataAnnotations;
using SistemaDeCadastro.Validacoes;

namespace SistemaDeCadastro.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da Pessoa")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o CPF da Pessoa")]
        [Cpf(ErrorMessage = "O CPF informado não é válido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento da Pessoa")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve estar no formato dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Digite o e-mail da Pessoa")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
    }
}
