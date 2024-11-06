using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestWoodPellets.Models;

namespace RestWoodPellets.Repository
{
    public class WoodPelletRepository
    {
        private int _nextId = 6; //starter på 6 da der allerede findes id 5 i listen

        private List<WoodPellet> _woodPellets = new List<WoodPellet>()
        {
         new WoodPellet(1, "Valid Brand", 50, 2),
         new WoodPellet(2, "Valid Brand", 200, 3),
         new WoodPellet(3, "Valid Brand", 355, 4),
         new WoodPellet(4, "Valid Brand", 359, 4),
        new WoodPellet(5, "Valid Brand", 500, 5)
         };



        public WoodPellet AddWoodPellet(WoodPellet woodPellet)
        {
            woodPellet.Id = _nextId++;
            woodPellet.Validate();
            _woodPellets.Add(woodPellet);
            return woodPellet;
        }

        public List<WoodPellet> GetAllWoodPellets()
        {
            return _woodPellets;
        }

        public WoodPellet? GetWoodPelletById(int id)
        {
            return _woodPellets.FirstOrDefault(w => w.Id == id);
        }

        public WoodPellet? UpdateWoodPellet(WoodPellet woodPellet)
        {
            woodPellet.Validate();
            var existingWoodPellet = _woodPellets.FirstOrDefault(w => w.Id == woodPellet.Id);
            if (existingWoodPellet == null)
            {
                throw new ArgumentException("Wood pellet not found");
            }
            existingWoodPellet.Brand = woodPellet.Brand;
            existingWoodPellet.Price = woodPellet.Price;
            existingWoodPellet.Quality = woodPellet.Quality;
            return existingWoodPellet;
        }






    }
}
