using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenge24.Data;
using Microsoft.EntityFrameworkCore;

namespace Challenge24.Component
{
    public class CommentViewComponent: ViewComponent
    {

        private readonly ApplicationDbContext _context;
        public CommentViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int OutlineId)
        {
            //var comments = _context.Outlines.Where(o => o.OutlineId == OutlineId).Include(c => c.Comments).AsNoTracking();
            var comments = _context.Comments.Where(c => c.OutlineId == OutlineId).Include(co => co.ApplicationUser);
            return View("Comment", comments);
        }
    }
}
