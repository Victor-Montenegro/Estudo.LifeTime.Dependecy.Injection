namespace Estudo.LifeTime.Dependecy.Injection.TesteReferenciaCircular
{
    public class ClassB
    {
        public ClassB(ClassC classC)
        {
            ClassC = classC;
        }

        public ClassC ClassC { get; }
    }
}
