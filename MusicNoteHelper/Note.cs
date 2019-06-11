using MusicNoteHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicNoteHelper
{
    /// <summary>
    /// Describes an individual sound that can be created by a music instrument. 
    /// </summary>
    public class Note : IEquatable<Note>
    {
        private Note(string name)
        {
            Name = name;
            Accidental = Accidental.None;
        }

        private Note(string name, Accidental accidental)
        {
            Name = name;
            Accidental = accidental;
        }

        public string Name { get; }

        public Accidental Accidental { get; }

        public bool HasAccidental => this.Accidental != Accidental.None;

        public static Note Parse(string noteName)
        {
            var trimmedNote = noteName.Trim();
            var note = trimmedNote.ElementAtOrDefault(0).ToString();
            var accidental = String.Empty;
            if (trimmedNote.Length > 1)
            {
                accidental = trimmedNote.ElementAtOrDefault(1).ToString();
            }
            return PossibleNotes.FirstOrDefault(n => n.Name == note && n.Accidental.Notation == accidental) 
                ?? throw new InvalidNoteException();
        }

        public static bool operator ==(Note left, Note right)
        {
            return EqualityComparer<Note>.Default.Equals(left, right);
        }

        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Note);
        }

        public bool Equals(Note other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Accidental == other.Accidental)
                return true;

            if (this.Name == "A" && this.Accidental == Accidental.Sharp 
                && other.Name == "B" && other.Accidental == Accidental.Flat)
                return true;

            if (this.Name == "C" && this.Accidental == Accidental.Sharp
                && other.Name == "D" && other.Accidental == Accidental.Flat)
                return true;

            if (this.Name == "D" && this.Accidental == Accidental.Sharp
                && other.Name == "E" && other.Accidental == Accidental.Flat)
                return true;

            if (this.Name == "F" && this.Accidental == Accidental.Sharp
                && other.Name == "G" && other.Accidental == Accidental.Flat)
                return true;

            if (this.Name == "G" && this.Accidental == Accidental.Sharp
                && other.Name == "A" && other.Accidental == Accidental.Flat)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override string ToString()
        {
            return Name + Accidental.Notation;
        }

        private static Note[] PossibleNotes = new Note[]
        {
            Note.AFlat, Note.A, Note.ASharp, Note.BFlat, Note.B, Note.C, Note.CSharp, Note.DFlat, Note.D,
            Note.DSharp, Note.EFlat, Note.E, Note.F, Note.FSharp, Note.GFlat, Note.G, Note.GSharp
        };

        public Note Sharpen(int numberSemitones)
        {
            if(numberSemitones < 0)
                return Flatten(-1 * numberSemitones);
            
            if (numberSemitones == 0)
                return this;

            var newNote = this.Sharpen();

            return newNote.Sharpen(--numberSemitones);
        }

        public Note Sharpen()
        {
            var newNote = Note.Rest;
            if (this == Note.A)
                newNote = Note.ASharp;
            else if (this == Note.ASharp || this == Note.BFlat)
                newNote = Note.B;
            else if (this == Note.B)
                newNote = Note.C;
            else if (this == Note.C)
                newNote = Note.CSharp;
            else if (this == Note.CSharp || this == Note.DFlat)
                newNote = Note.D;
            else if (this == Note.D)
                newNote = Note.DSharp;
            else if (this == Note.DSharp || this == Note.EFlat)
                newNote = Note.E;
            else if (this == Note.E)
                newNote = Note.F;
            else if (this == Note.F)
                newNote = Note.FSharp;
            else if (this == Note.FSharp || this == Note.GFlat)
                newNote = Note.G;
            else if (this == Note.G)
                newNote = Note.GSharp;
            else if (this == Note.GSharp || this == Note.AFlat)
                newNote = Note.A;
            return newNote;
        }

        public Note Flatten(int numberSemitones)
        {
            if (numberSemitones < 0)
                return Sharpen(-1 * numberSemitones);

            if (numberSemitones == 0)
                return this;

            var newNote = this.Flatten();

            return newNote.Flatten(--numberSemitones);
        }

        public Note Flatten()
        {
            var newNote = Note.Rest;
            if (this == Note.G)
                newNote = Note.GFlat;
            else if (this == Note.GFlat || this == Note.FSharp)
                newNote = Note.F;
            else if (this == Note.F)
                newNote = Note.E;
            else if (this == Note.E)
                newNote = Note.EFlat;
            else if (this == Note.EFlat || this == Note.DSharp)
                newNote = Note.D;
            else if (this == Note.D)
                newNote = Note.DFlat;
            else if (this == Note.DFlat || this == Note.CSharp)
                newNote = Note.C;
            else if (this == Note.C)
                newNote = Note.B;
            else if (this == Note.B)
                newNote = Note.BFlat;
            else if (this == Note.BFlat || this == Note.ASharp)
                newNote = Note.A;
            else if (this == Note.A)
                newNote = Note.AFlat;
            else if (this == Note.AFlat || this == Note.GSharp)
                newNote = Note.G;
            return newNote;
        }

        public static Note AFlat => new Note("A", Accidental.Flat);
        public static Note A => new Note("A");
        public static Note ASharp => new Note("A", Accidental.Sharp);
        public static Note BFlat => new Note("B", Accidental.Flat);
        public static Note B => new Note("B");
        public static Note C => new Note("C");
        public static Note CSharp => new Note("C", Accidental.Sharp);
        public static Note DFlat => new Note("D", Accidental.Flat);
        public static Note D => new Note("D");
        public static Note DSharp => new Note("D", Accidental.Sharp);
        public static Note EFlat => new Note("E", Accidental.Flat);
        public static Note E => new Note("E");
        public static Note F => new Note("F");
        public static Note FSharp => new Note("F", Accidental.Sharp);
        public static Note GFlat => new Note("G", Accidental.Flat);
        public static Note G => new Note("G");
        public static Note GSharp => new Note("G", Accidental.Sharp);

        // This is the equivalent of a Null Object
        public static Note Rest => new Note(" ");
    }
}
