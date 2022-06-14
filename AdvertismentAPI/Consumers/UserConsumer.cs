using Advertisment.BLL.IServices;
using MassTransit;

namespace AdvertismentAPI.Consumers;

public class UserConsumer : IConsumer<UAHause.CommonWork.Models.User>
{
    private readonly IUserService userService;

    public UserConsumer(IUserService userService) => this.userService = userService;

    public async Task Consume(ConsumeContext<UAHause.CommonWork.Models.User> context)
    {
        var commonUser = context.Message;

        var user = new Advertisment.DAL.Enteties.User
        {
            Id = commonUser.Id,
            Name = commonUser.Name,
            Surname = commonUser.Surname,
            Email = commonUser.Email,
            Phone = commonUser.Phone,
        };

        await userService.InsertAsync(user);
    }
}
