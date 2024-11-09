﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kantor_Bea_lab2.Data;
using Kantor_Bea_lab2.Models;

namespace Kantor_Bea_lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Kantor_Bea_lab2.Data.Kantor_Bea_lab2Context _context;

        public EditModel(Kantor_Bea_lab2.Data.Kantor_Bea_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing =  await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;

            var bookList = await _context.Book
                .Include(b => b.Author)
                .Select(x => new
                {
                    x.Id,
                    BookFullName = x.Title + " " + x.Author.FullName
                }
                ).ToListAsync();

            var memberList = await _context.Member
                .Select(m => new
                {
                    m.ID,
                    FullName = m.FirstName + " " + m.LastName
                }
                ).ToListAsync();

           ViewData["BookID"] = new SelectList(_context.Book, "Id", "Id");
           ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            
            
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
