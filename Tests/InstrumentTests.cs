using MusicNoteHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class InstrumentTests
    {
        [Fact]
        public void CanCreateInstruments()
        {
            var instrumentName = "Some kind of Stringed Instrument";
            var instrument = new StringedInstrument(
                instrumentName,
                new List<InstrumentString> {
                    InstrumentString.For(Note.G, 12),
                    InstrumentString.For(Note.D, 12),
                    InstrumentString.For(Note.A, 12),
                    InstrumentString.For(Note.E, 12),
                });
            Assert.Equal(instrument.Name, instrumentName);
            Assert.Equal(4, instrument.NumberOfStrings);
            Assert.Equal("EADG", instrument.CurrentTuning.ToString());
        }

        [Fact]
        public void CanChangeTuningOfInstrument()
        {
            var guitar = StringedInstrument.Guitar;

            var dropDTuning = Tuning.FromNotes(Note.E, Note.B, Note.G, Note.D, Note.A, Note.D);
            guitar.UpdateTuning(dropDTuning);

            Assert.Equal("DADGBE", guitar.CurrentTuning.ToString());
        }

        [Fact]
        public void CanAddStringsToInstrument()
        {
            var guitar = StringedInstrument.Guitar;
            guitar.AddStringToTop(InstrumentString.For(Note.A, 20));
            Assert.Equal("EADGBEA", guitar.CurrentTuning.ToString());
        }

        [Fact]
        public void CanGetTuningOfInstrument()
        {
            var guitar = StringedInstrument.Guitar;
            Assert.Equal("EADGBE", guitar.CurrentTuning.ToString());
        }

        [Fact]
        public void CanRemoveStringsFromInstrument()
        {
            var guitar = StringedInstrument.Guitar;
            guitar.RemoveTopString();
            Assert.Equal("EADGB", guitar.CurrentTuning.ToString());
        }

        [Fact]
        public void InstrumentsHaveDefaultTuning()
        {
            var guitar = StringedInstrument.Guitar;

            Assert.Equal("EADGBE", guitar.DefaultTuning.ToString());

            var dropDTuning = Tuning.FromNotes(Note.E, Note.B, Note.G, Note.D, Note.A, Note.D);
            guitar.SetDefaultTuning(dropDTuning);

            Assert.Equal("EADGBE", guitar.CurrentTuning.ToString());
            Assert.Equal("DADGBE", guitar.DefaultTuning.ToString());
        }

        [Fact]
        public void GuitarWithStandardTuningProducesCorrectNotes()
        {
            var guitar = new StringedInstrument(
                new List<InstrumentString>()
                {
                    InstrumentString.For(Note.E, 20),
                    InstrumentString.For(Note.A, 20),
                    InstrumentString.For(Note.D, 20),
                    InstrumentString.For(Note.G, 20),
                    InstrumentString.For(Note.B, 20),
                    InstrumentString.For(Note.E, 20),
                });

            var bottomEStringNotes = String.Join<Note>(" ", guitar.Strings.ElementAt(0).PossibleNotes());
            Assert.Equal("E F F# G G# A A# B C C# D D# E F F# G G# A A# B", bottomEStringNotes);

            var aStringNotes = String.Join<Note>(" ", guitar.Strings.ElementAt(1).PossibleNotes());
            Assert.Equal("A A# B C C# D D# E F F# G G# A A# B C C# D D# E", aStringNotes);

            var dStringNotes = String.Join<Note>(" ", guitar.Strings.ElementAt(2).PossibleNotes());
            Assert.Equal("D D# E F F# G G# A A# B C C# D D# E F F# G G# A", dStringNotes);

            var gStringNotes = String.Join<Note>(" ", guitar.Strings.ElementAt(3).PossibleNotes());
            Assert.Equal("G G# A A# B C C# D D# E F F# G G# A A# B C C# D", gStringNotes);

            var bStringNotes = String.Join<Note>(" ", guitar.Strings.ElementAt(4).PossibleNotes());
            Assert.Equal("B C C# D D# E F F# G G# A A# B C C# D D# E F F#", bStringNotes);

            var topEStringNotes = String.Join<Note>(" ", guitar.Strings.ElementAt(5).PossibleNotes());
            Assert.Equal("E F F# G G# A A# B C C# D D# E F F# G G# A A# B", topEStringNotes);
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
