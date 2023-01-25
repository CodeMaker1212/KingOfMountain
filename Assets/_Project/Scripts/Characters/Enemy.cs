namespace KingOfMountain.Characters
{
    public class Enemy : Character
    {
        private const float _lifeTimeInSeconds = 12.0f;

        private void Start()
        {
            Invoke(nameof(Die), _lifeTimeInSeconds);
        }

        protected override void Die()
        {
            Deactivate();
        }

        public override void Deactivate()
        {
            Destroy(gameObject);
        }
    }
}