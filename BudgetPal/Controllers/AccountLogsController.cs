﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetPal.Data;
using BudgetPal.Models;
using BudgetPal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BudgetPal.Controllers
{
    [Authorize]
    public class AccountLogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountLogsController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _userManager = usermanager;
            _context = context;
        }
        // GET: AccountLogs
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var logs = _context.AccountLogs.Where(l => l.ApplicationUserId == user.Id);
            return View(logs);
        }

        // GET: AccountLogs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountLogs/Create
        public async Task<ActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            var logTypes = await _context.LogTypes.Where(lT => lT.ApplicationUserId == user.Id)
                .Select(lT => new SelectListItem() { Text = lT.Name, Value = lT.Id.ToString() } ).ToListAsync();

            var logModel = new AccountLogViewModel();
            logModel.LogTypeOptions = logTypes;
            return View(logModel);
        }

        // POST: AccountLogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AccountLogViewModel viewModel)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var newLog = new AccountLog()
                {
                    ApplicationUserId = user.Id,
                    Amount = viewModel.Amount,
                    LogTypeId = viewModel.LogTypeId,
                    Deposit = viewModel.Deposit,
                    AccountId = viewModel.AccountId,
                    Date = viewModel.Date,
                    Name = viewModel.Name
                };
                _context.AccountLogs.Add(newLog);
                await _context.SaveChangesAsync();
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: AccountLogs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountLogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountLogs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountLogs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}