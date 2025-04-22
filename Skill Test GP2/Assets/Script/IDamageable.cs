public interface IDamageable{

        int Hp { get; }

        void TakeDamage(int amount);

        void IsDead();

        void Heal(int amount);

    }