using System;
using System.Collections.Generic;
using System.Linq;

namespace NecroTower.States
{
    internal class StateStack
    {
        private readonly Stack<State> states;

        public StateStack()
        {
            states = new Stack<State>();
        }

        public State Pop()
        {
            var state = states.Pop();
            state.Leave();
            return state;
        }

        public void Push(State state)
        {
            states.Push(state);
            state.Enter();
        }
        
        public void Update(object sender, EventArgs e)
        {
            var state = states.First();
            state.Update(sender, e);
        }

        public void Render(object sender, EventArgs e)
        {
            var state = states.First();
            state.Render(sender, e);
        }
    }
}
