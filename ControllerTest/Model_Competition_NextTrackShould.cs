using Model;
using NUnit.Framework.Internal;

namespace ControllerTest
{
    [TestFixture]
    public class Model_Competition_NextTrackShould
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
            Track result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        //[Test]
        //public void NextTrack_OneInQueue_ReturnTrack()
        //{
        //    Track baan = new Track("test");
        //    _competition.Tracks.Enqueue(baan);

        //    Track result = _competition.NextTrack();
        //    Assert.AreEqual(baan, result);
        //}

        //[Test]
        //public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        //{
        //    Track baan = new Track("test");
        //    _competition.Tracks.Enqueue(baan);

        //    Track result1 = _competition.NextTrack();
        //    Assert.IsNotNull(result1);

        //    Track result2 = _competition.NextTrack();
        //    Assert.IsNull(result2);
        //}

        //[Test]
        //public void NextTrack_TwoInQueue_ReturnNextTrack()
        //{
        //    Track baan1 = new Track("test1");
        //    _competition.Tracks.Enqueue(baan1);

        //    Track baan2 = new Track("test2");
        //    _competition.Tracks.Enqueue(baan2);

        //    Track result1Track = _competition.NextTrack();
        //    Assert.AreEqual(baan1, result1Track);

        //    Track result2Track = _competition.NextTrack();
        //    Assert.AreEqual(baan2.Name, result2Track.Name);
        //}
    }
}