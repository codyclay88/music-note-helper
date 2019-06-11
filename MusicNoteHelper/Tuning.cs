using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicNoteHelper
{
    public class Tuning
    {
        private Tuning(IEnumerable<Note> tuningNotes)
        {
            TuningNotes = tuningNotes.ToArray();
        }

        public static Tuning FromNotes(IEnumerable<Note> tuningNotes) => new Tuning(tuningNotes);

        public static Tuning FromNotes(params Note[] tuningNotes) => new Tuning(tuningNotes);

        public override string ToString()
        {
            return String.Join<Note>(String.Empty, TuningNotes.Reverse());
        }

        public Note[] TuningNotes { get; }


    }
}
