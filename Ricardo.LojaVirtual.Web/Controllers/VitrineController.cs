﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ricardo.LojaVirtual.Dominio;
using Ricardo.LojaVirtual.Dominio.Repositorio;
using Ricardo.LojaVirtual.Web.Models;

namespace Ricardo.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        private const int ProdutosPorPagina = 3;
        //
        // GET: /Vitrine/
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel()
            {

                Produtos = _repositorio.Produtos
                .Where(p => p.Categoria == null || p.Categoria == categoria)
                .OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),


                Paginacao = new Paginacao()
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria
            };



            return View(model);

        }
    }
}