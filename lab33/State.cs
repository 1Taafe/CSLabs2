using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class State
    {
        public string? Location { get; set; }
        public string? Value { get; set; }

        public State(string location, string value)
        {
            Location = location;
            Value = value;
        }

        public State()
        {
            Location = null;
            Value = null;
        }
    }

    public static class StateControl
    {
        public static Stack<State> undoStack { get; set; } = new Stack<State>();
        public static Stack<State> redoStack { get; set; } = new Stack<State>();
    }
}
