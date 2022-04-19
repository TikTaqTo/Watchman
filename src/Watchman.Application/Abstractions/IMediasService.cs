using System;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Media;
using Watchman.Domain.Replies;

namespace Watchman.Application.Abstractions {

  public interface IMediasService {

    Task<ImagesReply> RetrieveImages(int top);

    Task<ImageReply> RetrieveByIdImages(Guid top);

    Task<ImageReply> RetrieveByMovieIdImages(Guid id);

    Task<ImageReply> CreateImage(Image image);

    Task<ImageReply> DeleteImage(Guid id);

    Task<ImageReply> UpdateImage(Image image);
  }
}