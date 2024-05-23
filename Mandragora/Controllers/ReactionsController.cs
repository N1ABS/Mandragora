using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mandragora.Models;

namespace Mandragora.Controllers
{
    public class ReactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reactions
        public async Task<ActionResult> Index()
        {
            var reactions = db.Reactions.Include(r => r.Account).Include(r => r.Post);
            return View(await reactions.ToListAsync());
        }

        // GET: Reactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reaction reaction = await db.Reactions.FindAsync(id);
            if (reaction == null)
            {
                return HttpNotFound();
            }
            return View(reaction);
        }

        // GET: Reactions/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content");
            return View();
        }

        // POST: Reactions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PostId,AccountId,ReactionType")] Reaction reaction)
        {
            if (ModelState.IsValid)
            {
                db.Reactions.Add(reaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", reaction.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", reaction.PostId);
            return View(reaction);
        }

        // GET: Reactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reaction reaction = await db.Reactions.FindAsync(id);
            if (reaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", reaction.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", reaction.PostId);
            return View(reaction);
        }

        // POST: Reactions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PostId,AccountId,ReactionType")] Reaction reaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", reaction.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", reaction.PostId);
            return View(reaction);
        }

        // GET: Reactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reaction reaction = await db.Reactions.FindAsync(id);
            if (reaction == null)
            {
                return HttpNotFound();
            }
            return View(reaction);
        }

        // POST: Reactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reaction reaction = await db.Reactions.FindAsync(id);
            db.Reactions.Remove(reaction);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
