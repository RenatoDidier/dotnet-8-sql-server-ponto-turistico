## 📍 Projeto – Back-end de Pontos Turísticos

Este projeto é uma aplicação **back-end simples**, desenvolvida com **Dotnet 8.0** e **Entity Framework + Store Procedures**, responsável por **cadastrar, editar, listar e excluir pontos turísticos** associados ao usuário.
Esse projeto está dentro de docker, portanto, será necessário instalar o Docker Desktop para o correto funcionamento, além de ter a biblioteca do Entity para conseguir fazer a correta configuração do banco de dados.

### 🔗 Front-end relacionado

Para rodar o projeto localmente, é obrigatório utilizar o repositório de back-end abaixo:

👉 https://github.com/RenatoDidier/react-1920-typescript-ponto-turistico

---

Certifique-se de estar com o Docker Desktop aberto.

## ▶️ Como rodar o projeto localmente

1. Clone este repositório:

   ```bash
   git clone <url-do-repositorio>

   ```

2. Criação do contâiner do Sql Server e da API:
   Abra o terminal, vá na pasta raiz do repository e rode o seguinte comando:

   ```bash
   docker-compose up -d

   ```

3. Atualize o SQL Server com a tabela:
   Abra o terminal, vá na pasta raiz do repository e rode o seguinte comando:

   ```bash
   dotnet ef database update --project src/External/Tourism.Infrastructure --startup-project src/External/Public/Tourism.API

   ```

Você conseguirá acessar a API através da url: http://localhost:8080, e, caso tiver utilizando o Front-End, ele já estará automaticamente conectado.
