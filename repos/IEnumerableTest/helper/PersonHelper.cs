using IEnumerableTest.data;

namespace IEnumerableTest.helper
{
    internal class PersonHelper
    {
        public IEnumerable<string> getChildsFirstName(List<Person> persons)
        {
            return persons
                    .Where(person => person is Child)
                    //.Select(person => (Child)person)
                    .OrderBy(person => person.Firstname)
                    .Select(child => child.Firstname);
                    
                    
        }

    }
}
