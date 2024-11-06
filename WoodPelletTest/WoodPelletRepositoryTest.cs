using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestWoodPellets.Models;
using RestWoodPellets.Repository;

namespace WoodPelletLibTest
{
    [TestClass]
    public class WoodPelletRepositoryTest
    {
        private readonly new WoodPelletRepository _repo = new WoodPelletRepository();

        private readonly new WoodPellet _woodPellet = new WoodPellet("Valid Brand", 50, 2);
        private readonly new WoodPellet _updatewoodPellet = new WoodPellet("Sasa", 50, 5);

        [TestMethod]
        public void GetAllWoodPelletsTest()
        {
            var result = _repo.GetAllWoodPellets();
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
            Assert.AreEqual(4, result[3].Id);
            Assert.AreEqual(5, result[4].Id);

        }

        [TestMethod]
        public void AddWoodPelletTest()
        {
            var result = _repo.AddWoodPellet(_woodPellet);
            Assert.AreEqual(6, result.Id);
            Assert.AreEqual(6, _repo.GetAllWoodPellets().Count);
            var result2 = _repo.AddWoodPellet(_woodPellet);
            Assert.AreEqual(7, result.Id);
            Assert.AreEqual(7, _repo.GetAllWoodPellets().Count);


        }

        [TestMethod]
        public void GetWoodPelletByIdTest()
        {
            var result = _repo.GetWoodPelletById(1);
            Assert.AreEqual(1, result.Id);

            var result2 = _repo.GetWoodPelletById(6);
            Assert.IsNull(result2);

        }

        [TestMethod]
        public void UpdateWoodPelletTest()
        {
            _repo.AddWoodPellet(_updatewoodPellet);
            _updatewoodPellet.Brand = "UpdatedSasa";
            WoodPellet result = _repo.UpdateWoodPellet(_updatewoodPellet);
            Assert.AreEqual("UpdatedSasa", result.Brand);

        }



    }
}
