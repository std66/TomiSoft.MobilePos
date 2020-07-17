using NUnit.Framework;
using System.Collections.Generic;
using TomiSoft.Printing.Thermal.StringHandling;

namespace TomiSoft.Printing.Thermal.Tests.StringHandling {
    [TestFixture]
    public class StringHelperTests {
        [TestCase("abcdef", "31", "            abcdef")]
        public void AlignCenterTest(string input, int width, string expected) {
            //arrange

            //act
            string actual = StringHelper.AlignCenter(input, width);

            //assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("V�s�roljon n�lunk m�g 2 alkalommal, �s 10% kedvezm�nyt adunk �nnek!", 31, ' ', new[] { "V�s�roljon n�lunk m�g 2", "alkalommal, �s 10% kedvezm�nyt", "adunk �nnek!" })]
        public void DivideToMultipleLinesTest(string input, int width, char separator, string[] expected) {
            //arrange

            //act
            IReadOnlyList<string> actual = StringHelper.DivideToMultipleLines(input, width, separator);

            //assert
            Assert.That(actual.Count, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}