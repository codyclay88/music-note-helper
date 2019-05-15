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
    }
}
