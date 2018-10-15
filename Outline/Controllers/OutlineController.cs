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
    public class OutlineController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public OutlineController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Outlines.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Outline outline)
        {
            outline.CreaterId = _userManager.GetUserId(User);
            _context.Outlines.Add(outline);
            outline.OutlineUsers.Add(new OutlineUser { OutlineId = outline.OutlineId, UserId = outline.CreaterId, Day = 1 });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Outline outline = await _context.Outlines.FirstOrDefaultAsync(p => p.OutlineId == id);
                if (outline != null)
                    return View(outline);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Outline outline)
        {
            if (outline != null)
            {
                _context.Outlines.Update(outline);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Remove(int? id)
        {
            Outline outline = await _context.Outlines.FirstOrDefaultAsync(p => p.OutlineId == id);
            if (outline != null)
            {
                _context.Outlines.Remove(outline);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Show(int? id)
        {
            if (id != null)
            {
                var outlines =await _context.Outlines.Include(c => c.OutlineUsers).ThenInclude(sc => sc.ApplicationUser).ToListAsync();
                Outline outline = outlines.FirstOrDefault(p => p.OutlineId == id);
                var usersOfoutline = outline.OutlineUsers.Select(user => user.ApplicationUser).ToList();
                ViewData["Users"] = usersOfoutline;
                if (outline != null)
                    return View(outline);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Show(int OutlineId, String comment)
        {
            if ( comment!= null)
            {
                Commen comm = new Commen();
                comm.CommentText = comment;
                comm.ApplicationUser = await _userManager.GetUserAsync(User);
                comm.OutlineId = OutlineId;
                _context.Comments.Add(comm);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Show", OutlineId);
        }

        public async Task<IActionResult> Join(int? id)
        {
            if (id != null)
            {
                Outline outline = await _context.Outlines.FirstOrDefaultAsync(p => p.OutlineId == id);
                outline.OutlineUsers.Add(new OutlineUser { OutlineId = outline.OutlineId, UserId = _userManager.GetUserId(User) });
                _context.Outlines.Update(outline);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Comments(int? id)
        {
            if (id != null)
            {
                Outline outline = await _context.Outlines.FirstOrDefaultAsync(p => p.OutlineId == id);
                outline.OutlineUsers.Add(new OutlineUser { OutlineId = outline.OutlineId, UserId = _userManager.GetUserId(User) });
                _context.Outlines.Update(outline);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}