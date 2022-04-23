using Domain.Entities.Identity;
using Mapster;

namespace WebApi.Areas.Manage.Models
{
    public class CreateUserMVM
    {
        public CreateUserMVM(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }

    public class UserThumbailMVM
    {
        public UserThumbailMVM(string id, string username, string phoneNumber,
            string? email, string? name, string? surname)
        {
            Id = id;
            Username = username;
            PhoneNumber = phoneNumber;
            Email = email;
            Name = name;
            Surname = surname;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        //public static TypeAdapterConfig MapConfig()
        //{
        //    return TypeAdapterConfig<User, UserThumbailMVM>.NewConfig()
        //        .Map(dest => dest.Scores, src => src.ClubTransactions.OrderBy(x => x.DateTime).Select(ct => ct.CurrentScore).LastOrDefault()).Config;
        //}
    }

    public class UserInfoMVM
    {
        public UserInfoMVM(string id, string username, string phoneNumber,
            DateTime? joinedDateTime, string? email, string? name, string? surname)
        {
            Id = id;
            Username = username;
            PhoneNumber = phoneNumber;
            Email = email;
            Name = name;
            Surname = surname;
            if (joinedDateTime.HasValue)
                JoinedDateTime = new PersianDateTime(joinedDateTime.Value).ToString("dddd, dd MMMM yyyy - HH:mm");
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string JoinedDateTime { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
