using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using AutoMapper;

namespace mvc.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        private readonly UserManager<WebAppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TodoItemController(
            UserManager<WebAppUser> userManager,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        // GET: TodoItem
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TodoItems.Include(t => t.WebAppUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TodoItem/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItems
                .Include(t => t.WebAppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // GET: TodoItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsComplete,WebAppUserId")] TodoViewModel todoItemVM)
        {
            if (ModelState.IsValid)
            {
                var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);
                
                TodoItem todoItem = _mapper.Map<TodoItem>(todoItemVM);

                CurrentUser.TodoItems.Add(todoItem);
                await _userManager.UpdateAsync(CurrentUser);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItemVM);
        }

        // GET: TodoItem/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            ViewData["WebAppUserId"] = new SelectList(_context.Set<WebAppUser>(), "Id", "Id", todoItem.WebAppUserId);
            return View(todoItem);
        }

        // POST: TodoItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsComplete,WebAppUserId")] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.Id))
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
            ViewData["WebAppUserId"] = new SelectList(_context.Set<WebAppUser>(), "Id", "Id", todoItem.WebAppUserId);
            return View(todoItem);
        }

        // GET: TodoItem/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItems
                .Include(t => t.WebAppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: TodoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
