using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicNoteHelper
{
    public class StringedInstrument
    {
        public StringedInstrument(ICollection<InstrumentString> strings) : this("Standard", strings) {   }

        public StringedInstrument (string name, ICollection<InstrumentString> strings, Handedness handedness = Handedness.Right)
        {
            Name = name;
            Strings = strings;
            Handedness = handedness;
            NumberOfStrings = strings.Count;
            DefaultTuning = Tuning.FromNotes(strings.Select(str => str.Tuning));
        }

        public string Name { get; private set; }

        public Handedness Handedness { get; private set; }

        public ICollection<InstrumentString> Strings { get; private set; }

        public int NumberOfStrings { get; private set; }

        public Tuning DefaultTuning { get; private set; }

        public Tuning CurrentTuning => Tuning.FromNotes(Strings.Select(str => str.Tuning));

        public void UpdateTuning(Tuning tuning)
        {
            if(tuning.TuningNotes.Count() != NumberOfStrings)
                throw new Exception("The number of tuning notes must match the number of strings for the instrument!");

            var updatedStrings = new List<InstrumentString>();
            for(var i = 0; i < tuning.TuningNotes.Length; i++)
            {
                updatedStrings.Add(InstrumentString.For(tuning.TuningNotes[i], Strings.ElementAt(i).NumberOfFrets));
            }
            this.Strings = updatedStrings;
        }

        public void AddStringToTop(InstrumentString instrumentString)
        {
            var strings = new List<InstrumentString>();
            strings.Add(instrumentString);
            strings.AddRange(Strings);
            Strings = strings;
        }

        public void SetDefaultTuning(Tuning defaultTuning)
        {
            DefaultTuning = defaultTuning;
        }

        public void RemoveTopString()
        {
            Strings = Strings.Skip(1).ToList();
        }

        public void ResetTuningToDefault(Tuning defaultTuning)
        {
            UpdateTuning(DefaultTuning);
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public static StringedInstrument Ukelele =>
            new StringedInstrument(
                "Standard Ukelele",
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
                "Standard Guitar",
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
