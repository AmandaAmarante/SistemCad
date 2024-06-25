


# Sistema de Cadastro de Pessoas e Usuários

![GitHub repo size](https://img.shields.io/github/repo-size/AmandaAmarante/ControleDeUsuarios)
![GitHub issues](https://img.shields.io/github/issues/AmandaAmarante/ControleDeUsuarios)
![GitHub license](https://img.shields.io/github/license/AmandaAmarante/ControleDeUsuarios)

Este projeto é um sistema desenvolvido em C#, ASP.NET MVC, utilizando SQL Server como banco de dados, Bootstrap para o front-end e JavaScript para interações adicionais. O sistema oferece funcionalidades de cadastro e gestão de pessoas e usuários, com diferentes níveis de permissões baseadas no tipo de usuário.

## Tecnologias Utilizadas

- **C#**
- **ASP.NET MVC**
- **SQL Server**
- **Bootstrap**
- **JavaScript**

## Funcionalidades Implementadas

- **Cadastro de Pessoas:** Permite registrar novas informações de pessoas, como nome, idade, cpf, etc.
  
- **Cadastro de Usuários:** Permite registrar novos usuários no sistema, associando-os a uma pessoa existente no cadastro de pessoas.
  
- **Autenticação e Autorização:** Implementação de uma tela de login que valida as credenciais dos usuários e concede diferentes níveis de permissões baseadas no tipo de usuário (administrador, consulta, e cadastro.).
  
- **Gestão de Permissões:** Cada tipo de usuário tem acesso a funcionalidades específicas do sistema, controladas através de permissões atribuídas durante o cadastro.
  
- **Uso de Sessions:** Utilização do contexto de session do ASP.NET para gerenciar as sessões dos usuários logados no site, garantindo uma experiência personalizada e segura.

## Estrutura do Projeto

- **Controllers:** Contém os controladores que implementam a lógica de negócio e integração com as views.
  
- **Models:** Classes de modelo que representam entidades do sistema, como Pessoa, Usuário, etc.
  
- **Views:** Interfaces do usuário implementadas com HTML, Bootstrap e JavaScript para interação com o usuário final.
  
- **Contexto do Banco de Dados:** Configuração do DbContext para interação com o banco de dados SQL Server, incluindo migrações e configurações específicas do Entity Framework.

## Instruções para Utilização

### Configurar a Conexão com o Banco de Dados

Abra o arquivo `appsettings.json` e configure a string de conexão com o seu banco de dados SQL Server. Substitua `NomeDoSeuBancoDeDados` pelo nome do seu banco de dados e ajuste outros parâmetros conforme necessário:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=NomeDoSeuBancoDeDados;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### Executar Migrações (caso necessário)

Se estiver usando Entity Framework Core, execute as migrações para aplicar o esquema do banco de dados:

```bash
dotnet ef database update
```

Para Entity Framework (versões anteriores), use o Package Manager Console no Visual Studio:

```bash
Update-Database
```

### Compilar e Executar o Projeto

Pressione F5 no Visual Studio para compilar e executar o projeto.

### Acessar o Sistema

Abra um navegador web e vá para `http://localhost:porta`. A porta padrão pode variar dependendo da configuração do projeto no Visual Studio.

## Contribuições

Contribuições são bem-vindas! Se você quiser melhorar este projeto, sinta-se à vontade para enviar pull requests.



