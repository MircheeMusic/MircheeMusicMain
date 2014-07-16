using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MircheeMusic.Contracts;
using MircheeMusic.Controllers;
using System.Data.Entity;
using MircheeMusic.Repository;

namespace MircheeMusic.Controllers
{
    public class TrackController : Controller
    {
        //
        // GET: /Track/
        public ActionResult Index(int AlbumId)
        {
            var tracks = GetTrackList(AlbumId);
            return View(tracks);
        }

        private List<Contracts.Track> GetTrackList(int AlbumId)
        {
            //set data for Selected album
           var tracks = new List<Contracts.Track>();
            using (var TrackContext = new AlbumContext())
            {
                var t = TrackContext.Tracks.Where(tr => tr.AlbumID == AlbumId);
                foreach (var track in t)
                {
                    tracks.Add(new Contracts.Track { Id = track.Id, Name = track.Name, AlbumID = track.AlbumID, Artist = track.Artist });
                }
                return (tracks);
            }
        }














        //
        // GET: /Track/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Track/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Track/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Track/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
