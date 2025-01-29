using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekursionTest
{
    internal class PersonService
    {
        public Person getPerson(String name, Person person)
        {
            if(person.Name.Equals(name))
            {
                return person;
            }

            if (person.leftChild != null)
            {
                return checkLeftThenRight(name, person);
            }
            else if (person.rightChild != null)
            {
                return checkRightThenLeft(name, person);
            }

            return null;
        }

        private Person checkLeftThenRight(String name, Person person)
        {
            Person left = getPerson(name, person.leftChild);
            if (left != null && left.Name.Equals(name))
            {
                return left;
            }
            else
            {
                Person right = getPerson(name, person.rightChild);
                if (right != null && right.Name.Equals(name))
                {
                    return right;
                }
            }

            return null;
        }

        private Person checkRightThenLeft(String name, Person person)
        {
            Person right = getPerson(name, person.rightChild);
            if (right != null && right.Name.Equals(name))
            {
                return right;
            }
            else
            {
                Person left = getPerson(name, person.leftChild);
                if (left != null && left.Name.Equals(name))
                {
                    return left;
                }
            }
            return null;
        }
    }
}
