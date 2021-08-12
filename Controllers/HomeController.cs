using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Leagues"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomenLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Women"))
                .ToList();
            
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(league => league.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(league => !league.Sport.Contains("Football"))
                .ToList();

            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Conference"))
                .ToList();

            ViewBag.AtlanticRegionLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasTeams = _context.Teams
                .Where(team => team.Location.Contains("Dallas"))
                .ToList();

            ViewBag.RaptorsTeams = _context.Teams
                .Where(team => team.TeamName.Contains("Raptors"))
                .ToList();

            ViewBag.CityTeams = _context.Teams
                .Where(team => team.Location.Contains("City"))
                .ToList();

            ViewBag.TnameTeams = _context.Teams
                .Where(team => team.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.OrderByLocation = _context.Teams
                .OrderBy(team => team.Location)
                .ToList();
            
            ViewBag.OrderByTeamReverse = _context.Teams
                .OrderByDescending(team => team.TeamName)
                .ToList();
            
            ViewBag.PlayerLastNameCooper = _context.Players
                .Where(player => player.LastName.Contains("Cooper"))
                .ToList();

            ViewBag.PlayerFirstNameJoshua = _context.Players
                .Where(player => player.FirstName.Contains("Joshua"))
                .OrderBy(player => player.LastName)
                .ToList();

            ViewBag.PlayerCooperNotJoshua = _context.Players
                .Where(player => !player.FirstName.Contains("Joshua") && player.LastName.Contains("Cooper"))
                .OrderBy(player => player.FirstName)
                .ToList();

            ViewBag.PlayerAlexanderOrWyatt = _context.Players
                .Where(player => player.FirstName.Contains("Alexander") || player.FirstName.Contains("Wyatt"))
                .OrderBy(player => player.FirstName)
                .ThenBy(player => player.LastName)
                .ToList();
            
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}