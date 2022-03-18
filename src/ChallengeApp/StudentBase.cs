namespace ChallengeApp
{
    public abstract class StudentBase : UniversityFrequenter 
    {
        protected StudentBase(string name) : base(name)
        {
        }

        protected StudentBase(string name, string sex) : base(name, sex)
        {
        }

    }
}