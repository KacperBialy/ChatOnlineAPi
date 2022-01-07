using ChatOnline.Application.Common.Mappings;


namespace ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails
{
    public class UserDetailsViewModel : IMapFrom<Domain.Entities.User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
