namespace Service.Rest.v1.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}