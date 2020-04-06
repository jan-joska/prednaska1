namespace CodeClarityCorrect
{
    public class PersonRepository
    {
        public static MaybeObject<Person> GetPersonById(int id)
        {
            if (id == 1)
            {
                return new MaybeObject<Person>(new Person
                {
                    Id = 1,
                    Name = "Albert Einstein"
                });
            }
            return MaybeObject<Person>.NoValue;
        }
    }
}