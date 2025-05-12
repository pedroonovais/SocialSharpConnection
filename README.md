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

Execute o arquivo da solução (.sln) e execute dentro do visual studio ou a ide de sua preferência.

## 📬 Endpoints da API

Abaixo estão listadas as principais rotas RESTful organizadas por entidade:

### 🔹 Usuários (`/api/User`)

| Método | Rota                | Descrição                              | Corpo da Requisição |
|--------|---------------------|----------------------------------------|----------------------|
| GET    | `/api/User`         | Lista todos os usuários                | -                    |
| GET    | `/api/User/{id}`    | Retorna um usuário por ID              | -                    |
| POST   | `/api/User`         | Cria um novo usuário                   | `{ name, age, email, username }` |
| PUT    | `/api/User/{id}`    | Atualiza um usuário existente          | `{ id, name, age, email, username }` |
| DELETE | `/api/User/{id}`    | Remove um usuário pelo ID              | -                    |

---

### 🔹 Publicações (`/api/Post`)

| Método | Rota                | Descrição                              | Corpo da Requisição |
|--------|---------------------|----------------------------------------|----------------------|
| GET    | `/api/Post`         | Lista todas as publicações             | -                    |
| GET    | `/api/Post/{id}`    | Retorna uma publicação por ID          | -                    |
| POST   | `/api/Post`         | Cria uma nova publicação               | `{ idUser, author, username, content, date }` |
| PUT    | `/api/Post/{id}`    | Atualiza uma publicação existente      | `{ id, idUser, author, username, content, date }` |
| DELETE | `/api/Post/{id}`    | Remove uma publicação pelo ID          | -                    |

---

### 💡 Observações

- Os endpoints usam convenção REST.
- As rotas retornam `application/json`.
- Em caso de erro, os códigos de status HTTP são utilizados para indicar falhas (`400`, `404`, etc.).
- Todos os endpoints estão documentados e podem ser testados via Swagger (`/swagger`).

