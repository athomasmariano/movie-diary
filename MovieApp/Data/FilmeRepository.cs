using MovieApp.Models;

namespace MovieApp.Data
{
    public static class FilmeRepository
    {
        private static List<Filme> _filmes = new List<Filme>();
        private static int _nextId = 1;

        // CREATE
        public static void Adicionar(Filme filme)
        {
            filme.Id = _nextId++;
            _filmes.Add(filme);
        }

        // READ (Todos)
        public static List<Filme> Listar()
        {
            return _filmes;
        }

        // READ (Por Id)
        public static Filme? ObterPorId(int id)
        {
            return _filmes.FirstOrDefault(f => f.Id == id);
        }
        
        // READ (Pesquisa)
        public static List<Filme> PesquisarPorTitulo(string titulo)
        {
            return _filmes.Where(f => f.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
                          .ToList();
        }

        // UPDATE
        public static void Atualizar(Filme filmeAtualizado)
        {
            var filmeExistente = ObterPorId(filmeAtualizado.Id);
            if (filmeExistente != null)
            {
                filmeExistente.Titulo = filmeAtualizado.Titulo;
                filmeExistente.Ano = filmeAtualizado.Ano;
                filmeExistente.DataAssistido = filmeAtualizado.DataAssistido;
                filmeExistente.Nota = filmeAtualizado.Nota;
                filmeExistente.Genero = filmeAtualizado.Genero;
                filmeExistente.Review = filmeAtualizado.Review;
            }
        }

        // DELETE
        public static void Remover(int id)
        {
            var filme = ObterPorId(id);
            if (filme != null)
            {
                _filmes.Remove(filme);
            }
        }
    }
}