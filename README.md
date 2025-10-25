# Movie Diary: Diário Pessoal de Filmes

Este repositório contém o projeto **Movie Diary**, desenvolvido como avaliação para o **Checkpoint 2 de ASP.NET Core MVC** da FIAP.

A aplicação é um "diário de filmes" pessoal, onde o usuário pode realizar as operações básicas de CRUD (Create, Read, Update e Delete) para catalogar e gerenciar os filmes que assistiu. O foco do projeto foi em atender todos os requisitos da disciplina, ao mesmo tempo em que se criava uma interface de usuário (UI) profissional, responsiva e moderna.

---

## 1. Integrantes do Grupo

- **Arthur Thomas Mariano de Souza** (RM: 561061)  
- **Davi Cavalcanti Jorge** (RM: 559873)  
- **Mateus da Silveira Lima** (RM: 559728)  

---

## 2. Visão Geral do Projeto

Movie Diary não é um clone de plataformas de descoberta como Letterboxd ou IMDb; ele é um **catálogo pessoal**. A premissa é que o usuário já assistiu ao filme e deseja registrá-lo em seu diário particular.

Ele é construído com o padrão **MVC**, utilizando **C#** e o framework **ASP.NET Core**. A persistência de dados é feita em memória (sem banco de dados), através de um Padrão de Repositório estático, como solicitado na avaliação.

---

## 3. Principais Características (Features)

O projeto implementa todas as funcionalidades exigidas e diversas melhorias de layout e usabilidade:

- **CRUD Completo:** O usuário pode Criar, Ler, Atualizar e Deletar registros de filmes.
- **Landing Page Profissional:** Uma página inicial (`Home/Index`) customizada com tipografia, layout profissional e CTAs (Call to Action).
- **Galeria de Pôsteres:** A página principal (`Filme/Index`) exibe os filmes em formato de "cards" responsivos, em vez de uma tabela HTML simples.
- **Formulários Estilizados:** As páginas `Cadastrar` e `Editar` possuem um layout de "card" centralizado e profissional.
- **Avaliação com 5 Estrelas:** Um componente interativo de 5 estrelas substitui o campo numérico padrão para a `Nota`.
- **Pesquisa de Títulos:** A página "Meu Diário" possui uma barra de busca funcional para filtrar filmes por nome.
- **Persistência em Memória:** Os dados são gerenciados por um `FilmeRepository` estático, garantindo que os dados de exemplo e os cadastros do usuário persistam durante a sessão da aplicação.
- **Validação de Dados Avançada:**
  - O campo `Ano` é travado entre 1888 e o ano atual, tanto no Model (`[Range]`) quanto no HTML (`min`/`max`).
  - O `Enum` de Gênero usa o atributo `[Display(Name = "...")]` para exibir nomes formatados (ex: "Ficção Científica") no dropdown.
- **Confirmação de Remoção:** O sistema possui uma tela de confirmação antes de deletar um registro.
- **Design Responsivo:** O layout se adapta a dispositivos móveis, com o Header, Footer e a Galeria de filmes se reajustando.

---

## 4. Telas da Aplicação (Screenshots e Explicações)

Abaixo estão os prints de todas as telas do sistema, com suas respectivas explicações de implementação e funcionamento.

### Tela 1: Landing Page (Home)

![Landing](https://github.com/user-attachments/assets/ea11dc98-8347-4512-abf4-7d33c85a3007)

- **Implementação:** `Views/Home/Index.cshtml`. Substitui o "Welcome" padrão do template.
- **Funcionamento:** Porta de entrada profissional do site com tipografia 'Inter', layout "Hero" e botões `pro-btn` direcionando para ver o diário ou adicionar filme.

### Tela 2: Meu Diário

![Home](https://github.com/user-attachments/assets/938035c4-4c30-4888-8c80-aa236d90625e)

- **Implementação:** `Views/Filme/Index.cshtml`. Renderiza um grid responsivo de "cards".
- **Funcionamento:** Cada card exibe o pôster (`PosterUrl`), fallback (`movie-poster-fallback`) e "badge" de nota. Ao passar o mouse, aparece overlay com botões "Editar" e "Remover".

### Tela 3: Cadastrar Filme (Formulário)

![Cadastrar](https://github.com/user-attachments/assets/bdd8a472-9304-40bb-8a9d-ed10423c3b44)

- **Implementação:** `Views/Filme/Cadastrar.cshtml` com formulário em "card" centralizado (`.form-container-pro`).
- **Funcionamento:** Utiliza **Tag Helpers** (`asp-for`, `asp-validation-for`). O campo "Gênero" é `<select asp-items="ViewBag.Generos">` populado pelo `FilmeController`. A "Nota" é o componente `.star-rating-5`.

### Tela 4: Editar Filme

![Editar](https://github.com/user-attachments/assets/9b0fc41e-7ed2-4afe-af19-39cbf7411efc)

- **Implementação:** Mesma estrutura CSS da página de cadastro. Inclui `<input type="hidden" asp-for="Id" />`.
- **Funcionamento:** Campos preenchidos automaticamente pelo Model passado pelo controller, incluindo dropdown e estrelas de nota.

### Tela 5: Confirmação de Remoção

![Remover](https://github.com/user-attachments/assets/9f30dab2-44f4-4c33-9737-9e31fd97f106)

- **Implementação:** `Views/Filme/Remover.cshtml`, exibe o filme a ser removido.
- **Funcionamento:** Tela de **confirmação de remoção**. Formulário `POST` envia apenas o `Id` do filme para deleção.

---

## 5. Arquitetura e Padrões

O projeto foi estruturado seguindo os padrões fundamentais do ASP.NET Core MVC.

### Padrão MVC (Model-View-Controller)

- **Model:** Representa os dados da aplicação.
  - `Filme.cs`: Classe principal com validações (`[Range]`, `[Required]` etc.).
  - `Genero.cs`: Enum de gêneros com `[Display(Name="...")]` para nomes amigáveis.
- **View:** Páginas `.cshtml` da interface.
  - `Views/Home/Index.cshtml`: Landing Page
  - `Views/Filme/Index.cshtml`: Galeria (Read)
  - `Views/Filme/Cadastrar.cshtml`: Formulário (Create)
  - `Views/Filme/Editar.cshtml`: Formulário (Update)
  - `Views/Filme/Remover.cshtml`: Confirmação (Delete)
  - `Views/Shared/_Layout.cshtml`: Template principal com Header e Footer
- **Controller:** Gerencia requisições e seleciona a View.
  - `FilmeController.cs`: Actions do CRUD (`Index`, `Cadastrar`, `Editar`, `Remover`)
  - `HomeController.cs`: Landing Page

### Padrão Repositório (Simplificado)

Para atender ao requisito de **não usar banco de dados**, foi implementado um repositório simples:

- `Data/FilmeRepository.cs`: Classe estática com `List<Filme>` e métodos CRUD (`Adicionar`, `Listar`, `ObterPorId`, `Atualizar`, `Remover`, `PesquisarPorTitulo`).

---

## 6. Tecnologias e Pacotes NuGet

- **Framework:** ASP.NET Core MVC (.NET)  
- **Linguagem:** C#  
- **IDE:** Visual Studio 2022  
- **Front-End:**
  - HTML5 e CSS3 (Flexbox e Grid)
  - **Bootstrap 5** para grid e componentes
  - **Bootstrap Icons** para ícones
  - **Google Fonts** (fonte Inter)
- **Pacotes NuGet:**
  - `Microsoft.AspNetCore.Mvc`
  - `Microsoft.VisualStudio.Web.CodeGeneration.Design`

---

## 7. Rotas da Aplicação (Endpoints)

| Verbo HTTP | Rota (URL) | Action (Controller) | Descrição |
| :--- | :--- | :--- | :--- |
| GET | `/` ou `/Home/Index` | `Home.Index()` | Exibe a Landing Page |
| GET | `/Filme` ou `/Filme/Index` | `Filme.Index()` | Exibe a galeria de filmes |
| GET | `/Filme/Index?busca=...` | `Filme.Index(string busca)` | Galeria filtrada por busca |
| GET | `/Filme/Cadastrar` | `Filme.Cadastrar()` | Exibe formulário de cadastro |
| POST | `/Filme/Cadastrar` | `Filme.Cadastrar(Filme filme)` | Cria novo filme |
| GET | `/Filme/Editar/{id}` | `Filme.Editar(int id)` | Exibe formulário de edição |
| POST | `/Filme/Editar` | `Filme.Editar(Filme filme)` | Atualiza filme |
| GET | `/Filme/Remover/{id}` | `Filme.Remover(int id)` | Confirmação de remoção |
| POST | `/Filme/RemoverPost` | `Filme.RemoverPost(int id)` | Remove filme |

---

## 8. Como Executar o Projeto

1. Clone este repositório:  
   ```bash
   git clone https://github.com/athomasmariano/movie-diary
   ```
2. Abra o arquivo da Solution (.sln) com o Visual Studio 2022.

3. Aguarde o Visual Studio restaurar todas as dependências do NuGet.

4. Pressione F5 (ou clique em "Start") para compilar e executar a aplicação.

5. O navegador será aberto automaticamente na localhost correspondente.
