using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class FilmeController : Controller
    {
        private void CarregarGenerosNoViewBag()
        {
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)));
        }

        // READ (Listar todos) + PESQUISA
        public IActionResult Index(string busca)
        {
            List<Filme> filmes;
            if (string.IsNullOrEmpty(busca))
            {
                filmes = FilmeRepository.Listar();
            }
            else
            {
                filmes = FilmeRepository.PesquisarPorTitulo(busca);
                ViewBag.Busca = busca; // Para manter o termo no campo de busca
            }
            return View(filmes);
        }

        // CREATE (GET - Carrega o formulário)
        public IActionResult Cadastrar()
        {
            CarregarGenerosNoViewBag();
            return View();
        }

        // CREATE (POST - Salva os dados)
        [HttpPost]
        public IActionResult Cadastrar(Filme filme)
        {
            if (ModelState.IsValid)
            {
                FilmeRepository.Adicionar(filme);
                return RedirectToAction("Index"); // Volta para a lista
            }
            // Se o modelo não for válido, recarrega a página com os dados
            CarregarGenerosNoViewBag();
            return View(filme);
        }

        // UPDATE (GET - Carrega o formulário de edição)
        public IActionResult Editar(int id)
        {
            var filme = FilmeRepository.ObterPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            CarregarGenerosNoViewBag();
            return View(filme);
        }

        // UPDATE (POST - Salva as alterações)
        [HttpPost]
        public IActionResult Editar(Filme filme)
        {
            if (ModelState.IsValid)
            {
                FilmeRepository.Atualizar(filme);
                return RedirectToAction("Index");
            }
            CarregarGenerosNoViewBag();
            return View(filme);
        }

        // DELETE (GET - Carrega a página de confirmação )
        public IActionResult Remover(int id)
        {
            var filme = FilmeRepository.ObterPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme); // Passa o filme para a View de confirmação
        }

        // DELETE (POST - Executa a remoção)
        [HttpPost]
        public IActionResult RemoverPost(int id) // Nome diferente para evitar conflito
        {
            FilmeRepository.Remover(id);
            return RedirectToAction("Index");
        }
    }
}