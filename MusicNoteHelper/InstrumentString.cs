using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class InstrumentString
    {
        private InstrumentString(Note tuning, int numberOfFrets)
        {
            NumberOfFrets = numberOfFrets;
            Tuning = tuning;
        }

        public static InstrumentString For(Note tuning, int numberOfFrets) => 
            new InstrumentString(tuning, numberOfFrets);

        public int NumberOfFrets { get; }

        public Note Tuning { get; }

        public Note[] PossibleNotes()
        {
            var currentNote = Tuning;
            var notes = new Note[NumberOfFrets];
            for(int currentFret = 0; currentFret < NumberOfFrets; currentFret++)
            {
                notes[currentFret] = currentNote;
                currentNote = currentNote.Sharpen();
            }
            return notes;
        }
    }
}
