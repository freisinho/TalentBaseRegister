using TesteEasy.Models.Entities;

namespace Test.Builders.States
{
    public partial class StateBuilder
    {
        public State State { get; set; }

        public StateBuilder()
        {
            State = new State();
        }

        public StateBuilder DataBuilder(string name = null)
        {

            State.Name = name ?? Name;

            return this;
        }

        public State Build()
        {
            return State;
        }
    }
}
