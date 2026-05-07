namespace Odous.Services
{
    public class AuthService
    {
        private bool _isLoggedIn = true;
        
        public bool IsLoggedIn => _isLoggedIn;
        
        public void Login()
        {
            _isLoggedIn = true;
        }
        
        public void Logout()
        {
            _isLoggedIn = false;
        }
    }
}
