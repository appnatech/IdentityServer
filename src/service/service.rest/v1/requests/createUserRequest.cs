namespace service.rest.v1.requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}