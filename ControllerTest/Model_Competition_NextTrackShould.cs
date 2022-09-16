using Model;
using NUnit.Framework.Internal;

namespace ControllerTest
{

    [TestFixture]
    internal class Model_Competition_NextTrackShould
    {

        private Competition _competition;

        [SetUp]
        public void Setup()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
            var result = _competition.NextTrack();
            Assert.IsNull(result);
        }
    }
}
