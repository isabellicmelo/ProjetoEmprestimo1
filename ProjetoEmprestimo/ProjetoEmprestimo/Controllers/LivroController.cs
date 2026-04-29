using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimo.GerenciaArquivos;
using ProjetoEmprestimo.repository.contract;
using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livrorepository;

        public LivroController(ILivroRepository livrorepository)
        {
            _livrorepository = livrorepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livrorepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro Realizado";
            return View();
        }
    }
}
