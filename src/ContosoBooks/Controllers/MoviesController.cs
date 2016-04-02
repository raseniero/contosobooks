using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ContosoBooks.Models;

namespace ContosoBooks.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(_context.Movie.ToList());
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.MovieID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        //GET: Books/Create
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "Movie");
            return View();
        }

       //POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["MovieID"] = new SelectList(_context.Set<Author>(), "MovieID", "Movie", movie.MovieID);

            return View(movie);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.MovieID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "Movie", movie.MovieID);

            return View(movie);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "Movie", movie.MovieID);

            return View(movie);
        }

        // GET: Books/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.MovieID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Movie movie = _context.Movie.Single(m => m.MovieID == id);
            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
