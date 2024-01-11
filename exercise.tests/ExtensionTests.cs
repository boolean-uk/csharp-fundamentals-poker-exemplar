using exercise.main.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestCardsInGame()
        {
            Game game = new Game();

            int result = game.Deck.Count;

            Assert.That(result, Is.EqualTo(52));
        }
    }
}
