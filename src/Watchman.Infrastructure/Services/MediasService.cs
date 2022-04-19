using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.EntityModels.Media;
using Watchman.Domain.Replies;
using Watchman.Infrastructure.Persistence;

namespace Watchman.Infrastructure.Services {

  public class MediasService : IMediasService {
    private readonly WatchmanServiceContext _context;

    public MediasService(WatchmanServiceContext context) {
      _context = context;
    }

    #region Images

    public Task<ImagesReply> RetrieveImages(int top) {
      var images = _context.Images.Take(top);
      var imagesReply = new ImagesReply {
        Images = images
      };
      return Task.FromResult(imagesReply);
    }

    public Task<ImageReply> RetrieveByMovieIdImages(Guid id) {
      var image = _context.Images.FirstOrDefault(x => x.MovieId == id);
      var imagesReply = new ImageReply {
        Image = image
      };
      return Task.FromResult(imagesReply);
    }

    public Task<ImageReply> RetrieveByIdImages(Guid id) {
      var image = _context.Images.FirstOrDefault(x => x.Id == id);
      var imagesReply = new ImageReply {
        Image = image
      };
      return Task.FromResult(imagesReply);
    }

    public async Task<ImageReply> CreateImage(Image image) {
      await _context.Images.AddAsync(image);
      await _context.SaveChangesAsync();
      return new ImageReply {
        Image = image
      };
    }

    public async Task<ImageReply> DeleteImage(Guid id) {
      var image = _context.Images.Find(id);
      image.DeletedAt = DateTimeOffset.Now;
      image.DeletedBy = "admin";
      image.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new ImageReply {
        Image = image
      };
    }

    public async Task<ImageReply> UpdateImage(Image image) {
      var newImage = _context.Images.Find(image);
      newImage.Name = image.Name;
      newImage.MovieId = image.MovieId;
      newImage.ModifiedAt = DateTimeOffset.Now;
      newImage.ModifiedBy = "admin";
      await _context.SaveChangesAsync();
      return new ImageReply {
        Image = image
      };
    }

    #endregion Images
  }
}