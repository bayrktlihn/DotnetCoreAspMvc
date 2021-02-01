using System.Collections.Generic;
using MyProject.Entity;
using System.Linq;

namespace MyProject.Data
{
    public class PersonRepository : IPersonRepository
    {

        private MyContext _myContext;

        public PersonRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public void Delete(Person entity)
        {
            _myContext.People.Remove(entity);
            _myContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            _myContext.People.Remove(new Person{Id = id});
            _myContext.SaveChanges();
        }

        public List<Person> FindAll()
        {
            return _myContext.People.ToList();
        }

        public Person FindById(int id)
        {
            return _myContext.People.FirstOrDefault(p => p.Id == id);
        }

        public Person Save(Person entity)
        {
            if(entity.Id == 0){
                _myContext.People.Add(entity);
            }
            else{
                _myContext.Update(entity);
            }

            _myContext.SaveChanges();

            return entity;
        }
    }
}