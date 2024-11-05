﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kantor_Bea_lab2.Data;
using Kantor_Bea_lab2.Models;

namespace Kantor_Bea_lab2.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Kantor_Bea_lab2.Data.Kantor_Bea_lab2Context _context;

        public DetailsModel(Kantor_Bea_lab2.Data.Kantor_Bea_lab2Context context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}
