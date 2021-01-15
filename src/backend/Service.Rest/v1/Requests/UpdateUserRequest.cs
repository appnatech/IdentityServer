namespace Service.Rest.v1.Requests
{
    public class UpdateUserRequest
    {
        public string SubjectId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}