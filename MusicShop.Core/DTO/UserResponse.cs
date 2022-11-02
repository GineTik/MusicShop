using MusicShop.Core.DTO.Enums;

namespace MusicShop.Core.WebHost.DTO
{
    public class UserResponse
    {

        public string Email { get; set; }
        public string Username { get; set; }

        public StatusCodes Code { get; set; }
        public string Token { get; set; }



        public UserResponse(StatusCodes code, string token) =>
            (Code, Token) = (code, token);

        public static UserResponse Success(string token) => new UserResponse(StatusCodes.Success, token);
        public static UserResponse NotAcceptable => new UserResponse(StatusCodes.NotAcceptable, null);
    }
}
