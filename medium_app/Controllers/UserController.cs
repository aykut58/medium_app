using medium_app.DTO;
using medium_app.Models;
using medium_app.Response;
using medium_app.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Cache;

namespace medium_app.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetByUser(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kullanıcı Yok" });
            return Ok(user);
        }
        [HttpPost]
        public IActionResult AddUser(UserDTO userDTO)
        {
            long id = _userService.Add
                (
                new User
                {
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Age = userDTO.Age

                });
            return Ok(new AddUserResponse { SavedId = id });
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kayıt Bulunamadı." });
            _userService.DeleteById(id);
            return Ok(new ResponseMessage { Message = "İşlem Başarılı" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDTO userDTO)
        {
            var updateUser = _userService.FindById(id);
            if (updateUser == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kayıt Bulunamadı." });

            updateUser.Name = userDTO.Name;
            updateUser.Surname = userDTO.Surname;
            updateUser.Age = userDTO.Age;

            _userService.UpdateUser(updateUser);

            return Ok(new ResponseMessage { Message = "Kitap Başarıyla Güncellendi" });
        }

    }
}
