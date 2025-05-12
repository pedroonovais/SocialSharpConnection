# SocialSharpConnection

**SocialSharpConnection** é uma API desenvolvida em .NET com o objetivo de simular o funcionamento básico de uma rede social, permitindo o gerenciamento de usuários e publicações (posts). O projeto segue uma arquitetura em camadas bem definida, utilizando Entity Framework Core com banco de dados Oracle e documentação interativa via Swagger.

---

## 📌 Funcionalidades

- Cadastro, visualização, edição e exclusão de **usuários**
- Criação e exibição de **posts**
- API RESTful com retorno em JSON
- Documentação com Swagger UI
- Banco de dados Oracle com migrações automatizadas via EF Core

---

## 🏗 Estrutura do Projeto

- **api**: Camada de apresentação (controllers, Swagger, configuração geral)
- **service**: Camada de regras de negócio (serviços)
- **data**: Contexto de banco de dados (AppDbContext, configurações EF Core)
- **library**: Contém os modelos de domínio (User, Post, Publicacao)

---

## 💻 Tecnologias Utilizadas

- .NET 8 / .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- Oracle.EntityFrameworkCore
- Swagger / Swashbuckle
- C#

---

## 🚀 Como Executar o Projeto

Clone o repositório:

```bash
git clone https://github.com/seu-usuario/SocialSharpConnection.git
cd SocialSharpConnection
```

Execute o arquivo da solução (.sln) e execute dentro do visual studio ou a ide de sua preferência
