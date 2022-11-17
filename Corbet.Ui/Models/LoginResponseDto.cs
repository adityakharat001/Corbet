namespace Corbet.Ui.Models
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }

        public string Token { get; set; }

        public string UserName { get; set; }
    }
}
