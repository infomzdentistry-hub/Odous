using Odous.Models;

namespace Odous.Services
{
    public class AuthService
    {
        private bool _isLoggedIn = false;
        private Patient? _currentUser = null;
        
        private readonly Dictionary<string, string> _users = new()
        {
            { "admin", "admin123" },
            { "doctor", "doctor123" },
            { "receptionist", "reception123" }
        };

        // Property - NO parentheses when using
        public bool IsLoggedIn => _isLoggedIn;
        
        public Patient? CurrentUser => _currentUser;
        
        // Method that takes 2 arguments
        public bool Login(string username, string password)
        {
            if (_users.ContainsKey(username) && _users[username] == password)
            {
                _isLoggedIn = true;
                _currentUser = new Patient 
                { 
                    Name = username,
                    Email = $"{username}@odous.com",
                    ContactNo = "1234567890"
                };
                return true;
            }
            return false;
        }
        
        public void Logout()
        {
            _isLoggedIn = false;
            _currentUser = null;
        }
        
        // Method that returns the current user
        public Patient? GetCurrentUser()
        {
            return _currentUser;
        }
        
        public bool IsInRole(string role)
        {
            if (_currentUser?.Name == "admin") return true;
            if (role == "User") return _isLoggedIn;
            return false;
        }
    }
}
