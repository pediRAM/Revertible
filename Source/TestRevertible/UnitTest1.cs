namespace TestRevertible
{
    public class Tests
    {
        private TestClass _testee = new TestClass
        {
            NormalBool = false,
            NormalChar = '1',
            NormalDatetime = new DateTime(1, 2, 3, 4, 5, 6),
            NormalDouble = 0.123d,
            NormalInt = 123,
            NormalObject = new string("defaultObject"),
            NormalString = "defaultString",

            RevertibleBool = false,
            RevertibleChar = '1',
            RevertibleDatetime = new DateTime(1, 2, 3, 4, 5, 6),
            RevertibleDouble = 0.123d,
            RevertibleInt = 123,
            RevertibleObject = new string("defaultObject"),
            RevertibleString = "defaultString",
        };


        [SetUp]
        public void Setup()
        { 
        }


        [Test(Description = "No modifications after instanciation or saving revertible properties")]
        public void Test00()
        {
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
            _testee.SaveRevertibleProperties();
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False );
        }

        [Test(Description = "No modifications after change of normal bool property")]
        public void Test01()
        {
            _testee.NormalBool = true;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "No modifications after change of normal int property")]
        public void Test02()
        {
            _testee.NormalInt = 789;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "No modifications after change of normal char property")]
        public void Test03()
        {
            _testee.NormalChar = '@';
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "No modifications after change of normal double property")]
        public void Test04()
        {
            _testee.NormalDouble = -3.14;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "No modifications after change of normal DateTime property")]
        public void Test05()
        {
            _testee.NormalDatetime = DateTime.Now;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "No modifications after change of normal string property")]
        public void Test06()
        {
            _testee.NormalString = "Hello world!";
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "No modifications after change of normal object property")]
        public void Test07()
        {
            _testee.NormalObject = new string("New string!");
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 1 items and RevertibleBool PropertyInfo")]
        public void Test11()
        {
            _testee.RevertibleBool = true;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(1));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleBool)));
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 2 items and RevertibleInt PropertyInfo")]
        public void Test12()
        {
            _testee.RevertibleInt = -789;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(2));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleInt)));
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 3 items and RevertibleChar PropertyInfo")]
        public void Test13()
        {
            _testee.RevertibleChar = 'A';
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(3));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleChar)));
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 4 items and RevertibleDouble PropertyInfo")]
        public void Test14()
        {
            _testee.RevertibleDouble = -56.789;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(4));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleDouble)));
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 5 items and RevertibleDatetime PropertyInfo")]
        public void Test15()
        {
            _testee.RevertibleDatetime = DateTime.Now;
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(5));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleDatetime)));
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 6 items and RevertibleString PropertyInfo")]
        public void Test16()
        {
            _testee.RevertibleString = "Welcome to the real world Neo!";
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(6));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleString)));
        }

        [Test(Description = "GetModifiedRevertibleProperties() must contain 7 items and RevertibleObject PropertyInfo")]
        public void Test17()
        {
            _testee.RevertibleObject = new string("Hello World!");
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.True);

            var modifiedProperties = _testee.GetModifiedRevertibleProperties();
            Assert.That(modifiedProperties.Count, Is.EqualTo(7));
            Assert.That(modifiedProperties.Any(x => x.Name == nameof(TestClass.RevertibleObject)));
        }

        [Test(Description = "Compare property values after revert")]
        public void Test20_CompareValuesAfterRevert()
        {
            _testee.RevertRevertibleProperties();
            Assert.That(_testee.HasModifiedRevertibleProperties, Is.False);
            Assert.That(_testee.RevertibleBool,   Is.False);
            Assert.That(_testee.RevertibleChar,   Is.EqualTo('1'));
            Assert.That(_testee.RevertibleDatetime, Is.EqualTo(new DateTime(1,2, 3, 4, 5, 6)));
            Assert.That(_testee.RevertibleDouble, Is.EqualTo(0.123d));
            Assert.That(_testee.RevertibleInt,    Is.EqualTo(123));
            Assert.That(_testee.RevertibleObject, Is.EqualTo("defaultObject"));
            Assert.That(_testee.RevertibleString, Is.EqualTo("defaultString"));
        }
    }
}
