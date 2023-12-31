using Revertible;

namespace TestRevertible
{

    internal class TestClass : BaseRevertible
    {
        public bool NormalBool { get; set; }
        public int NormalInt { get; set; }
        public char NormalChar { get; set; }
        public double NormalDouble { get; set; }
        public DateTime NormalDatetime { get; set; }
        public string NormalString { get; set; }
        public object NormalObject { get; set; }



        [Revertible]
        public bool RevertibleBool { get; set; }

        [Revertible]
        public int RevertibleInt { get; set; }

        [Revertible]
        public char RevertibleChar { get; set; }

        [Revertible]
        public double RevertibleDouble { get; set; }

        [Revertible]
        public DateTime RevertibleDatetime { get; set; }

        [Revertible]
        public string RevertibleString { get; set; }

        [Revertible]
        public object RevertibleObject { get; set; }


    }
}
