using Odous.Models;

namespace Odous.Services
{
    public class AuthService
    {
        // In-memory user store (you can add more users)
        private static List<UserCredentials> _users = new List<UserCredentials>
        {
            new UserCredentials { Username = "admin", Password = "admin123", Role = "Admin" },
            new UserCredentials { Username = "doctor", Password = "doctor123", Role = "Doctor" },
            new UserCredentials { Username = "receptionist", Password = "reception123", Role = "Receptionist" }
        };

        private static string? _currentUser = null;

        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                _currentUser = username;
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        public string? GetCurrentUser()
        {
            return _currentUser;
        }

        public bool RegisterUser(string username, string password, string role)
        {
            if (_users.Any(u => u.Username == username))
                return false;

            _users.Add(new UserCredentials { Username = username, Password = password, Role = role });
            return true;
        }
    }
}