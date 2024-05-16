using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCBilet1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var teams = _teamService.GetAll();

            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _teamService.Add(team);
            }
            catch(TeamNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(ContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropName, ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            var existTeam = _teamService.GetTeam(x => x.Id == id);
            if (existTeam == null) return NotFound();
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id,Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _teamService.Update(team.Id,team);
            return RedirectToAction(nameof(Index));

        }
    }
}
