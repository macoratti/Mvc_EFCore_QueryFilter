using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_EFCoreQueryFilter.Context;
using Mvc_EFCoreQueryFilter.Models;

namespace Mvc_EFCoreQueryFilter.Controllers;

public class CursosController : Controller
{
    private readonly AppDbContext _context;

    public CursosController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(bool filtroAtivo = true)
    {
        var alunos = filtroAtivo ?
                       _context.Cursos.Include(c => c.Alunos).ToList() :
                       _context.Cursos.IgnoreQueryFilters().Include(c => c.Alunos).ToList(); 

        ViewBag.FiltroAtivo = filtroAtivo;

        return View(alunos);
    }

    [HttpPost]
    public IActionResult ToggleFiltro(string filtroOpcao)
    {
        bool filtroAtivo;

        if (filtroOpcao == "habilitar")
        {
            filtroAtivo = true;
        }
        else if (filtroOpcao == "desabilitar")
        {
            filtroAtivo = false;
        }
        else
        {
            // Se nenhum radiobutton foi selecionado, mantenha o filtroAtivo como estava
            filtroAtivo = (bool)(ViewBag.FiltroAtivo ?? true);
        }

        return RedirectToAction("Index", new { filtroAtivo });
    }

}
