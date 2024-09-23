namespace Hospital
{
    public class Administrativo : Personal
    {
        public override string ToString()
        {
            return $"{base.ToString()}: Personal administrativo";
        }
    }
}