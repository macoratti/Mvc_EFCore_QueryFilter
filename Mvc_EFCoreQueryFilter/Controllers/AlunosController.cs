using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_EFCoreQueryFilter.Context;

namespace Mvc_EFCoreQueryFilter.Controllers;

public class AlunosController : Controller
{
    private readonly AppDbContext _context;

    public AlunosController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(bool filtroAtivo = true)
    {
        var alunos = filtroAtivo ?
                        _context.Alunos.ToList() :
                        _context.Alunos.IgnoreQueryFilters().ToList();

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
