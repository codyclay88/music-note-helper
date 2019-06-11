using System;
using Xunit;
using MusicNoteHelper;
using System.Linq;
using System.Collections.Generic;
using MusicNoteHelper.Exceptions;

namespace Tests
{
    public class MusicNoteTests
    {
        [Fact]
        public void CanParseStringsIntoNotes()
        {
            var a = Note.Parse("A");
            Assert.Equal(Note.A, a);

            var aSharp = Note.Parse("A#");
            Assert.Equal(Note.ASharp, aSharp);

            var aFlat = Note.Parse("Ab");
            Assert.Equal(Note.AFlat, aFlat);

            Assert.Equal(Note.A, Note.Parse("     A"));
            Assert.Equal(Note.A, Note.Parse("A     "));
            Assert.Equal(Note.A, Note.Parse("  A  "));
        }

        [Fact]
        public void ThrowsExceptionWhenParsingBadNote()
        {
            Assert.Throws<InvalidNoteException>(() => Note.Parse(String.Empty));
            Assert.Throws<InvalidNoteException>(() => Note.Parse("Ax"));
            Assert.Throws<InvalidNoteException>(() => Note.Parse("  "));
            Assert.Throws<InvalidNoteException>(() => Note.Parse("#A"));
            Assert.Throws<InvalidNoteException>(() => Note.Parse("AB"));
        }

        [Fact]
        public void NotesCanBeSharpened()
        {
            var note = Note.A;
            Assert.Equal(Note.ASharp, note.Sharpen());
            Assert.Equal(Note.B, note.Sharpen(2));
            Assert.Equal(Note.C, note.Sharpen(3));
            Assert.Equal(Note.CSharp, note.Sharpen(4));
            Assert.Equal(Note.D, note.Sharpen(5));
            Assert.Equal(Note.DSharp, note.Sharpen(6));
            Assert.Equal(Note.E, note.Sharpen(7));
            Assert.Equal(Note.F, note.Sharpen(8));
            Assert.Equal(Note.FSharp, note.Sharpen(9));
            Assert.Equal(Note.G, note.Sharpen(10));
            Assert.Equal(Note.GSharp, note.Sharpen(11));
            Assert.Equal(Note.A, note.Sharpen(12));
        }

        [Fact]
        public void NotesCanBeFlattened()
        {
            var note = Note.G;
            Assert.Equal(Note.GFlat, note.Flatten());
            Assert.Equal(Note.F, note.Flatten(2));
            Assert.Equal(Note.E, note.Flatten(3));
            Assert.Equal(Note.EFlat, note.Flatten(4));
            Assert.Equal(Note.D, note.Flatten(5));
            Assert.Equal(Note.DFlat, note.Flatten(6));
            Assert.Equal(Note.C, note.Flatten(7));
            Assert.Equal(Note.B, note.Flatten(8));
            Assert.Equal(Note.BFlat, note.Flatten(9));
            Assert.Equal(Note.A, note.Flatten(10));
            Assert.Equal(Note.AFlat, note.Flatten(11));
            Assert.Equal(Note.G, note.Flatten(12));
        }

        [Fact]
        public void IntervalsForAShouldBeCorrect()
        {
            var aInterval = Interval.For(Note.A);
            Assert.Equal(Note.A, aInterval.Unison);
            Assert.Equal(Note.ASharp, aInterval.MinorSecond);
            //Assert.Equal(Note.BFlat, aInterval.MinorSecond);
            Assert.Equal(Note.B, aInterval.MajorSecond);
            Assert.Equal(Note.C, aInterval.MinorThird);
            Assert.Equal(Note.CSharp, aInterval.MajorThird);
            //Assert.Equal(Note.DFlat, aInterval.MajorThird);
            Assert.Equal(Note.D, aInterval.PerfectFourth);
            Assert.Equal(Note.DSharp, aInterval.AugmentedFourth);
            Assert.Equal(Note.DSharp, aInterval.DiminishedFifth);
            //Assert.Equal(Note.EFlat, aInterval.AugmentedFourth);
            //Assert.Equal(Note.EFlat, aInterval.DiminishedFifth);
            Assert.Equal(Note.E, aInterval.PerfectFifth);
            Assert.Equal(Note.F, aInterval.MinorSixth);
            Assert.Equal(Note.FSharp, aInterval.MajorSixth);
            //Assert.Equal(Note.GFlat, aInterval.MajorSixth);
            Assert.Equal(Note.G, aInterval.MinorSeventh);
            Assert.Equal(Note.GSharp, aInterval.MajorSeventh);
            //Assert.Equal(Note.AFlat, aInterval.MajorSeventh);
            Assert.Equal(Note.A, aInterval.PerfectOctave);
        }

        [Fact]
        public void AccidentalsOfSameNoteShouldBeEqual()
        {
            Assert.True(Note.ASharp == Note.BFlat);
            Assert.True(Note.CSharp == Note.DFlat);
            Assert.True(Note.DSharp == Note.EFlat);
            Assert.True(Note.FSharp == Note.GFlat);
            Assert.True(Note.GSharp == Note.AFlat);
        }

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
            Assert.Equal(Note.A, aMajorScale[0]);
            Assert.Equal(Note.B, aMajorScale[1]);
            Assert.Equal(Note.CSharp, aMajorScale[2]);
            Assert.Equal(Note.D, aMajorScale[3]);
            Assert.Equal(Note.E, aMajorScale[4]);
            Assert.Equal(Note.FSharp, aMajorScale[5]);
            Assert.Equal(Note.GSharp, aMajorScale[6]);
        }

        [Fact]
        public void CMajorScaleConsistsOfCorrectNotes()
        {
            var cMajorScale = MajorScale.For(Note.C).ToList();
            Assert.Equal(Note.C, cMajorScale[0]);
            Assert.Equal(Note.D, cMajorScale[1]);
            Assert.Equal(Note.E, cMajorScale[2]);
            Assert.Equal(Note.F, cMajorScale[3]);
            Assert.Equal(Note.G, cMajorScale[4]);
            Assert.Equal(Note.A, cMajorScale[5]);
            Assert.Equal(Note.B, cMajorScale[6]);
        }

        [Fact]
        public void EMajorScaleConsistsOfCorrectNotes()
        {
            var eMajorScale = MajorScale.For(Note.E).ToList();
            Assert.Equal(Note.E, eMajorScale[0]);
            Assert.Equal(Note.FSharp, eMajorScale[1]);
            Assert.Equal(Note.GSharp, eMajorScale[2]);
            Assert.Equal(Note.A, eMajorScale[3]);
            Assert.Equal(Note.B, eMajorScale[4]);
            Assert.Equal(Note.CSharp, eMajorScale[5]);
            Assert.Equal(Note.DSharp, eMajorScale[6]);
        }

        [Fact]
        public void EMajorChordConsistOfCorrectNotes()
        {
            var eMajorChord = MajorChord.For(Note.E).ToList();
            Assert.Equal(Note.E, eMajorChord[0]);
            Assert.Equal(Note.GSharp, eMajorChord[1]);
            Assert.Equal(Note.B, eMajorChord[2]);
        }
    }
}
