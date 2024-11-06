using RestWoodPellets.Models;

namespace WoodPelletLibTest
{
    [TestClass]
    public class WoodPelletTest
    {
        new WoodPellet _woodPellet = new WoodPellet(1, "Valid Brand", 50, 2);
        new WoodPellet _shortname = new WoodPellet(2, "S", 50, 5);
        new WoodPellet _0price = new WoodPellet(3, "Valid Brand", 0, 5);
        new WoodPellet _6quality = new WoodPellet(4, "Valid Brand", 50, 6);
        [TestMethod]
        public void ValidateBrandTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _shortname.ValidateBrand()); //throws exception on shortname
            _woodPellet.ValidateBrand(); //no exception on valid name
        }

        [TestMethod]
        public void ValidatePriceTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _0price.ValidatePrice()); //throws exception on 0 price
            _woodPellet.ValidatePrice(); //no exception on valid price
        }
        [TestMethod]
        public void ValidateQualityTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _6quality.ValidateQuality()); //throws exception on 6 quality
            _woodPellet.ValidateQuality(); //no exception on valid quality
        }

        [TestMethod]
        public void ValidateTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _shortname.Validate()); //throws exception on shortname
            Assert.ThrowsException<ArgumentException>(() => _0price.Validate()); //throws exception on 0 price
            Assert.ThrowsException<ArgumentException>(() => _6quality.Validate()); //throws exception on 6 quality
            _woodPellet.Validate(); //no exception on valid values
        }
    }
}