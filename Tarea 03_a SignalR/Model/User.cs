namespace Tarea_03_a_SignalR.Model
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public User(String email, String password) {
            this.Email = email;
            this.Password = password;   
        }
        }
}
