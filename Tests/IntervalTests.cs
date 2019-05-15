using System;
using Xunit;
using MusicNoteHelper;
using System.Linq;

namespace Tests
{
    public class IntervalTests
    {
        [Fact]
        public void MajorScaleConsistsOf7Notes()
        {
            var aMajorScale = MajorScale.For(Note.A);
            Assert.Equal(7, aMajorScale.Count());
        }

        [Fact]
        public void AMajorScaleConsistsOfCorrectNotes()
        {
            var aMajorScale = MajorScale.For(Note.A).ToList();
            Assert.Equal(aMajorScale[0], Note.A);
            Assert.Equal(aMajorScale[1], Note.B);
            Assert.Equal(aMajorScale[2], Note.CSharp);
            Assert.Equal(aMajorScale[3], Note.D);
            Assert.Equal(aMajorScale[4], Note.E);
            Assert.Equal(aMajorScale[5], Note.FSharp);
            Assert.Equal(aMajorScale[6], Note.GSharp);
        }

        [Fact]
        public void CMajorScaleConsistsOfCorrectNotes()
        {
            var cMajorScale = MajorScale.For(Note.C).ToList();
            Assert.Equal(cMajorScale[0], Note.C);
            Assert.Equal(cMajorScale[1], Note.D);
            Assert.Equal(cMajorScale[2], Note.E);
            Assert.Equal(cMajorScale[3], Note.F);
            Assert.Equal(cMajorScale[4], Note.G);
            Assert.Equal(cMajorScale[5], Note.A);
            Assert.Equal(cMajorScale[6], Note.B);
        }

        [Fact]
        public void EMajorScaleConsistsOfCorrectNotes()
        {
            var eMajorScale = MajorScale.For(Note.E).ToList();
            Assert.Equal(eMajorScale[0], Note.E);
            Assert.Equal(eMajorScale[1], Note.FSharp);
            Assert.Equal(eMajorScale[2], Note.GSharp);
            Assert.Equal(eMajorScale[3], Note.A);
            Assert.Equal(eMajorScale[4], Note.B);
            Assert.Equal(eMajorScale[5], Note.CSharp);
            Assert.Equal(eMajorScale[6], Note.DSharp);
        }

        [Fact]
        public void EMajorChordConsistOfCorrectNotes()
        {
            var eMajorChord = MajorChord.For(Note.E).ToList();
            Assert.Equal(eMajorChord[0], Note.E);
            Assert.Equal(eMajorChord[1], Note.GSharp);
            Assert.Equal(eMajorChord[2], Note.B);
        }

        [Fact]
        public void StringsCanProduceCorrectNotes()
        {
            var aString = InstrumentString.For(Note.A, 12);
            var possibleNotes = aString.PossibleNotes();
            var notesAsString = String.Join<Note>(' ', possibleNotes);
            Assert.Equal("A A# B C C# D D# E F F# G G#", notesAsString);
        }
    }
}
