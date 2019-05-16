using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class StringedInstrument
    {
        public StringedInstrument (ICollection<InstrumentString> strings)
        {
            Strings = strings;
        }

        public ICollection<InstrumentString> Strings { get; }

        public static StringedInstrument Ukelele =>
            new StringedInstrument(
                new InstrumentString[]
                {
                    InstrumentString.For(Note.G, 12),
                    InstrumentString.For(Note.C, 12),
                    InstrumentString.For(Note.E, 12),
                    InstrumentString.For(Note.A, 12),
                }
            );

        public static StringedInstrument Guitar =>
            new StringedInstrument(
                new InstrumentString[]
                {
                    InstrumentString.For(Note.E, 20),
                    InstrumentString.For(Note.B, 20),
                    InstrumentString.For(Note.G, 20),
                    InstrumentString.For(Note.D, 20),
                    InstrumentString.For(Note.A, 20),
                    InstrumentString.For(Note.E, 20),
                }
            );
    }
}
