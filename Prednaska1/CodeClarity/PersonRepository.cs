namespace CodeClarity
{
    public class PersonRepository
    {
        public static Person GetPersonById(int id)
        {
            if (id == 1)
            {
                return new Person(){Id = 1,Name = "Albert Einstein"};
            }
            return null;
        }
    }
}