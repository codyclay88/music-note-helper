using System.Collections.Generic;
using System.Linq;

namespace MusicNoteHelper
{
    internal class NoteNode
    {
        private NoteNode(Note note, Note next)
        {
            Note = note;
            Next = next;
        }

        public Note Note { get; }
        public Note Next { get; }

        private static IEnumerable<NoteNode> NoteNodes =>
            new NoteNode[]
            {
                NoteNode.A,
                NoteNode.ASharp,
                NoteNode.B,
                NoteNode.C,
                NoteNode.CSharp,
                NoteNode.D,
                NoteNode.DSharp,
                NoteNode.E,
                NoteNode.F,
                NoteNode.FSharp,
                NoteNode.G,
                NoteNode.GSharp,
            };

        public static NoteNode For(Note note)
        {
            return NoteNodes.First(n => n.Note == note);
        }

        private static NoteNode A => new NoteNode(Note.A, Note.ASharp);
        private static NoteNode ASharp => new NoteNode(Note.ASharp, Note.B);
        private static NoteNode B => new NoteNode(Note.B, Note.C);
        private static NoteNode C => new NoteNode(Note.C, Note.CSharp);
        private static NoteNode CSharp => new NoteNode(Note.CSharp, Note.D);
        private static NoteNode D => new NoteNode(Note.D, Note.DSharp);
        private static NoteNode DSharp => new NoteNode(Note.DSharp, Note.E);
        private static NoteNode E => new NoteNode(Note.E, Note.F);
        private static NoteNode F => new NoteNode(Note.F, Note.FSharp);
        private static NoteNode FSharp => new NoteNode(Note.FSharp, Note.G);
        private static NoteNode G => new NoteNode(Note.G, Note.GSharp);
        private static NoteNode GSharp => new NoteNode(Note.GSharp, Note.A);
    }
    
}
