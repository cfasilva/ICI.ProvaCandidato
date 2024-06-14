using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var news = _context.News
                .Include(n => n.User)
                .Include(n => n.TagNews)
                    .ThenInclude(tn => tn.Tag);

            return View(await news.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.User)
                .Include(n => n.TagNews)
                    .ThenInclude(tn => tn.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            ViewBag.Tags = new SelectList(_context.Tags, "Id", "Description");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,SelectedTagIds")] NewsDto news)
        {
            if (ModelState.IsValid)
            {
                //Define the user logged in
                news.UserId = 1;

                _context.Add(news);
                await _context.SaveChangesAsync();

                if (news.SelectedTagIds != null && news.SelectedTagIds.Count > 0)
                {
                    foreach (var tagId in news.SelectedTagIds)
                    {
                        _context.TagNews.Add(new TagNews { NewsId = news.Id, TagId = tagId });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Tags = new SelectList(_context.Tags, "Id", "Description");
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            //TODO: news.SelectedTagIds = _context.TagNews.Where(tn => tn.NewsId == news.Id).Select(tn => tn.TagId).ToList();

            ViewBag.Tags = new SelectList(_context.Tags, "Id", "Description");
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,SelectedTagIds")] NewsDto news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Define the user logged in
                    news.UserId = 1;

                    _context.Update(news);
                    await _context.SaveChangesAsync();

                    var existingTags = _context.TagNews.Where(tn => tn.NewsId == news.Id);
                    _context.TagNews.RemoveRange(existingTags);

                    if (news.SelectedTagIds != null && news.SelectedTagIds.Count > 0)
                    {
                        foreach (var tagId in news.SelectedTagIds)
                        {
                            _context.TagNews.Add(new TagNews { NewsId = news.Id, TagId = tagId });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Tags = new SelectList(_context.Tags, "Id", "Description");
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.User)
                .Include(n => n.TagNews)
                    .ThenInclude(tn => tn.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
