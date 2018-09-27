using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenge24.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Challenge24.Data;
using Challenge24.Models.ChallengeModels;

namespace Challenge24.Controllers
{
    [Authorize]
    public class ChallengeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ChallengeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Challenges.ToList());
        }

        [HttpGet]
        public IActionResult AddChallenge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddChallenge(Challenge challenge)
        {
            _context.Challenges.Add(challenge);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditChallenge(int? id)
        {
            if (id != null)
            {
                Challenge challenge = await _context.Challenges.FirstOrDefaultAsync(p => p.ChallengeId == id);
                if (challenge != null)
                    return View(challenge);
            }
            return NotFound();
        }

        public async Task<IActionResult> Remove(int? id)
        {
            Challenge challenge = await _context.Challenges.FirstOrDefaultAsync(p => p.ChallengeId == id);
            if (challenge != null)
            {
                _context.Challenges.Remove(challenge);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}