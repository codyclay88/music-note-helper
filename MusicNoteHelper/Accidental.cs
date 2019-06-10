using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class Accidental
    {
        private Accidental(string notation)
        {
            Notation = notation;
        }

        public string Notation { get; }

        public static Accidental Sharp => new Accidental("#");
        public static Accidental Flat => new Accidental("b");

    }
}
