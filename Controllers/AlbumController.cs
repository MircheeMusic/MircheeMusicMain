using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MircheeMusic.Contracts;
using MircheeMusic.Controllers;
using System.Data.Entity;
using MircheeMusic.Repository;
using MircheeMusic.Models;



//using MMDomainClasses;



//using 

namespace MircheeMusic.Controllers
{
    public class AlbumController : Controller
    {
        AlbumRepository _AlbumRepository = new AlbumRepository();

        public ActionResult Index()
        {
            // Get the list of Albums from Contract
            var albums = _AlbumRepository.FindAll();
            List<AlbumModel> albums1 = new List<AlbumModel>();
            //Convert the list of Albums from Contract to Album model
            foreach (var a in albums)
            {
                albums1.Add(new AlbumModel { Id = a.Id, Name = a.Name, Genre = a.Genre });
            }

            return View(albums1);
        }

        public ActionResult Details(int Id)
        {
            //Send album info to view page

            var album = GetAlbumInfo(Id);
            return View(album);
        }

        public ActionResult Edit(int Id)
        {
            //Send album info to view page

            var album = GetAlbumInfo(Id);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(AlbumModel album)
        {
            //Send album info to view page
            Album a = new Album();
            a.Id = album.Id;
            a.Name = album.Name;
            a.Genre = album.Genre;
            _AlbumRepository.Save(a);
            return RedirectToAction("Index");
            //return View(album);  on error it should return here

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            _AlbumRepository.Save(album);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            DeleteAlbum(Id);
            return RedirectToAction("Index");
        }


        //private List<Album> GetAlbums()
        //{
        //    List<Album> albums = new List<Album>();
        //    var a = _AlbumRepository.FindAll();
        //    foreach (var album in a)
        //        {
        //            albums.Add(new Album { Name = album.Name, Id = album.Id, Genre = album.Genre });
        //        }
        //    return albums;
        //}

        private AlbumModel GetAlbumInfo(int Id)
        {
            //set data for Selected album
            AlbumModel album = new AlbumModel();
            var a = _AlbumRepository.Find(Id);
            if (a.Id > 0)
                {
                    album.Id = a.Id;
                    album.Name = a.Name;
                    album.Genre = a.Genre;
                }
            return album;
        }

        private void DeleteAlbum(int Id)
        {
            _AlbumRepository.Delete(Id);
        }


        //private Boolean DeleteAlbum(int Id)
        //{
        //   var album = AlbumContext.Albums.First(i => i.Id == Id);
        //        AlbumContext.Albums.Remove(album);
        //        AlbumContext.SaveChanges();
        //        return true;

        //}

        //private List<Album> GetAlbums()
        //{
        //    List<Album> albums = new List<Album>();
        //    using (var AlbumContext = new CFDAL.AlbumContext())  
        //    {
        //        var a = GetAlbums();
        //        foreach (var album in a)
        //        {
        //            albums.Add(new Album { Name = album.Name, Id = album.Id, Genre = album.Genre });
        //        }
        //    }

        //    return albums;
        //}

        //private Album GetAlbumInfo(int Id)
        //{
        //    //set data for Selected album
        //    Album album = new Album();
        //    using (var AlbumContext = new CFDAL.AlbumContext())
        //    {
        //        var a = AlbumContext.Albums.Find(Id);
        //        {
        //            album.Id = a.Id;
        //            album.Name = a.Name;
        //            album.Genre = a.Genre;
        //        }
        //    }
        //    return album;
        //}
    }
}
