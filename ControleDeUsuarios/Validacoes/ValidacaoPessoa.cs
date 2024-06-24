using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SistemaDeCadastro.Validacoes
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("O CPF é obrigatório.");
            }

            var cpf = value.ToString();

            if (!IsValidCpf(cpf))
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            return ValidationResult.Success;
        }

        private bool IsValidCpf(string cpf)
        {
            // Remover caracteres especiais
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verificar se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verificar se todos os dígitos são iguais
            bool todosDigitosIguais = true;
            for (int i = 1; i < 11 && todosDigitosIguais; i++)
            {
                if (cpf[i] != cpf[0])
                    todosDigitosIguais = false;
            }

            if (todosDigitosIguais)
                return false;

            // Calcular o primeiro dígito verificador
            int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
