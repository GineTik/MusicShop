using FluentValidation.Results;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.Services.ProductServices
{
    public interface IMusicService
    {
        Music AddMusic(MusicDTO dto);
    }
}
