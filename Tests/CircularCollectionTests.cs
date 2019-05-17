using MusicNoteHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class CircularCollectionTests
    {
        [Fact]
        public void CanCreateCircularCollection()
        {
            var enumerable = new List<int> { 1, 2, 3, 4 };
            var collection = CircularCollection<int>.FromCollection(enumerable);
            Assert.Equal(4, collection.Count);
        }

        public void PrevOfFirstElementShouldBeLastElement()
        {
            var enumerable = new List<int> { 1, 2, 3, 4 };
            var collection = CircularCollection<int>.FromCollection(enumerable);
            //Assert.Equal(4, );
        }
    }
}
