namespace Estudo.LifeTime.Dependecy.Injection.TesteReferenciaCircular
{
    public class ClassA
    {
        public ClassA(ClassB classB)
        {
            ClassB = classB;
        }

        public ClassB ClassB { get; }
    }
}
