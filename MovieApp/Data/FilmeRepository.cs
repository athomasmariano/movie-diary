using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Data
{
    public static class FilmeRepository
    {
        private static List<Filme> _filmes = new List<Filme>
        {
            new Filme
            {
                Id = 1,
                Titulo = "Blade Runner",
                Ano = 1982,
                DataAssistido = new DateTime(2024, 12, 20),
                Genero = Genero.FiccaoCientifica,
                Nota = 5,
                Review = "O melhor filme de ficção científica que já vi. A trilha sonora e os visuais são espetaculares.",
                PosterUrl = "https://m.media-amazon.com/images/M/MV5BMWMwZjZjZjctMjI1ZC00MTRlLWE1MzktMDZjZDI1MjU2OTQxXkEyXkFqcGc@._V1_FMjpg_UX640_.jpg"
            },
            new Filme
            {
                Id = 2,
                Titulo = "O Poderoso Chefão",
                Ano = 1972,
                DataAssistido = new DateTime(2025, 10, 15),
                Genero = Genero.Drama,
                Nota = 5,
                Review = "Obra-prima. Atuações impecáveis e direção genial.",
                PosterUrl = "http://m.media-amazon.com/images/M/MV5BYTRmMjkwYzYtYTRiMi00NDJjLTk1NjctMDA3MjY2ZWIyMGQ5XkEyXkFqcGc@._V1_QL75_UY562_CR7,0,380,562_.jpg"
            },
            new Filme
            {
                Id = 3,
                Titulo = "Eyes Whitout a Face",
                Ano = 1960,
                DataAssistido = new DateTime(2023, 08, 11),
                Genero = Genero.Terror,
                Nota = 5,
                Review = "Diálogos fantásticos e estrutura narrativa inovadora.",
                PosterUrl = "https://s3.amazonaws.com/criterion-production/films/19431863841861d74f7712060bff99e9/vOHVeymeS3E2Iw9WNwxzVTlVswMV45_large.jpg"
            },
            new Filme
            {
                Id = 4,
                Titulo = "Superman",
                Ano = 2025,
                DataAssistido = new DateTime(2025, 07, 14),
                Genero = Genero.Acao,
                Nota = 4,
                Review = "Melhor super-herói de todos os tempos.",
                PosterUrl = "https://m.media-amazon.com/images/M/MV5BOTVlYWRjOTItNzg3ZC00ZDE5LWE4MmItZDA2OTQyOTAyZmZmXkEyXkFqcGc@._V1_FMjpg_UY4096_.jpg"
            }
        };

        private static int _nextId = 5;

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
                filmeExistente.PosterUrl = filmeAtualizado.PosterUrl;
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