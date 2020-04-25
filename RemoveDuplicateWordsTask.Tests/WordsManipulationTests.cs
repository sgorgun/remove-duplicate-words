using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RemoveDuplicateWordsTask.Tests
{
    [TestFixture]
    public class WordsManipulationTests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(
                    "alpha beta  beta gamma   gamma gamma delta alpha beta beta gamma gamma gamma delta  ",
                    "alpha beta   gamma     delta         ");
                yield return new TestCaseData(
                    " Broadcasting  by television and  radio in Britain is regulated  by the Minister of Posts and   Telecommunications.  101",
                    " Broadcasting  by television and  radio in Britain is regulated   the Minister of Posts    Telecommunications.  101");
                yield return new TestCaseData(
                    "123   Both the BBC and the ITV services provide programmes   of music, and drama, and light entertainment, and films.",
                    "123   Both the BBC and  ITV services provide programmes   of music,  drama,  light entertainment,  films.");
                yield return new TestCaseData(
                    "  In  the evening, I often watch TV with my family and discuss my plans  for the next  day.",
                    "  In  the evening, I often watch TV with my family and discuss  plans  for  next  day.");
                yield return new TestCaseData(
                    "Test1   We are very  much alike: open-hearted, smart and merry.  That is why we have a lot of  friends. Test1 - Test1",
                    "Test1   We are very  much alike: open-hearted, smart and merry.  That is why  have a lot of  friends. Test1 - Test1");
            }
        }

        [TestCaseSource(nameof(DataCases))]
        [Property("Mark", 2)]
        public void RemoveDuplicateWordsTests(string actual, string expected)
        {
            WordsManipulation.RemoveDuplicateWords(ref actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Property("Mark", 1)]
        public void RemoveDuplicateWords_String_Is_Null_Throw_ArgumentNullException()
        {
            string source = null;
            Assert.Throws<ArgumentNullException>(() => WordsManipulation.RemoveDuplicateWords(ref source),
                message: "Source string cannot be null.");
        }

        [Test]
        [Property("Mark", 1)]
        public void RemoveDuplicateWords_String_Is_Empty_Throw_ArgumentException()
        {
            string source = string.Empty;
            Assert.Throws<ArgumentException>(() => WordsManipulation.RemoveDuplicateWords(ref source),
                message: "Source string cannot be empty.");
        }
    }
}