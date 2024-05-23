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
    public class PostCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostComments
        public async Task<ActionResult> Index()
        {
            var postComments = db.PostComments.Include(p => p.Account).Include(p => p.Post);
            return View(await postComments.ToListAsync());
        }

        // GET: PostComments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = await db.PostComments.FindAsync(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

        // GET: PostComments/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content");
            return View();
        }

        // POST: PostComments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PostId,AccountId,Comment")] PostComment postComment)
        {
            if (ModelState.IsValid)
            {
                db.PostComments.Add(postComment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", postComment.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", postComment.PostId);
            return View(postComment);
        }

        // GET: PostComments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = await db.PostComments.FindAsync(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", postComment.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", postComment.PostId);
            return View(postComment);
        }

        // POST: PostComments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PostId,AccountId,Comment")] PostComment postComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postComment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", postComment.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", postComment.PostId);
            return View(postComment);
        }

        // GET: PostComments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = await db.PostComments.FindAsync(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

        // POST: PostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PostComment postComment = await db.PostComments.FindAsync(id);
            db.PostComments.Remove(postComment);
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
