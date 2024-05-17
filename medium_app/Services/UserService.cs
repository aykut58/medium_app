using medium_app.Models;
using medium_app.Repositories;

namespace medium_app.Services
{
    public class UserService
    {
        private ApplicationContext _applicationContext;

        public UserService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public List<User> GetAllUsers() => _applicationContext.Users.ToList();
        public User FindById(int id) => _applicationContext.Users.SingleOrDefault(link => link.Id == id);

        public long Add(User user)
        {
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
            return user.Id;
        }

        public void DeleteById(int id)
        {
            var userDelete = _applicationContext.Users.SingleOrDefault(user => user.Id == id);

            if (userDelete != null)
            {
                _applicationContext.Users.Remove(userDelete);
                _applicationContext.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            var updateUser = _applicationContext.Users.FirstOrDefault(user => user.Id == user.Id);
            if (updateUser != null)
            {
                updateUser.Name = user.Name;
                updateUser.Surname = user.Surname;
                updateUser.Age = user.Age;


                _applicationContext.SaveChanges();
            }
        }
    }
}
