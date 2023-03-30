namespace Unify.Example.UsedInExampleTests
{
    public class Foo : IFoo
    {
        private int Health { get; set; }

        public Foo(int health)
        {
            Health = health;
        }

        public int TakeDamage(int damage)
        {
            return Health -= damage;
        }
    }
}