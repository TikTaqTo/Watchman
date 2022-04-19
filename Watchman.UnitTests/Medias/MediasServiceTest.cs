using System.Linq;
using Watchman.Domain.EntityModels.Media;
using Watchman.Infrastructure.Persistence;
using Watchman.Infrastructure.Services;
using Xunit;
using System.IO;

namespace Watchman.UnitTests.Medias {

  public class MediasServiceTest {
    private WatchmanServiceContext dbContext;
    private MediasService mediasService;
    private readonly string _imagePathDefault;
    private readonly string _imageNameDefault;

    public MediasServiceTest() {
      dbContext = new WatchmanServiceContext();
      mediasService = new MediasService(dbContext);
      _imagePathDefault = @"C:\Users\TikTaqTo\Downloads\tmb_219432_952884.jpg";
      _imageNameDefault = "Tokyo";
    }

    [Fact]
    public void CreateImage_AddingJapanImage_ReturnedJapanImageReply() {
      //Arrange
      byte[] imageData;
      using (FileStream fs = new FileStream(_imagePathDefault, FileMode.Open)) {
        imageData = new byte[fs.Length];
        fs.Read(imageData, 0, imageData.Length);
      }
      var tokyoImage = new Image() {
        Name = _imageNameDefault,
        Source = imageData
      };
      var imageRetrieveResult = new Image();

      //Act
      if (mediasService.RetrieveImages(1).Result.Images.ToList().Count == 0) {
        imageRetrieveResult = mediasService.CreateImage(tokyoImage).Result.Image;
      } else {
        Assert.True(true, "The image of Japan has already been created, for the tests to function correctly, it is necessary to remove Japan.");
        return;
      }

      //Assert
      Assert.Equal(tokyoImage, imageRetrieveResult);
    }

    [Fact]
    public void RetrieveImages_RetriveAllImage_ReturnedTokyoImageReply() {
      //Arrange
      var allGenres = mediasService.RetrieveImages(1);

      //Act
      var actualImage = allGenres.Result.Images.ToList()[0];
      string actualImageName = actualImage.Name;

      //Assert
      Assert.NotNull(actualImageName);
    }

    [Fact]
    public void UpdateImage_UpdateTokyoImage_ReturnedUpdatedTokyoImageReply() {
      //Arrange
      string newImageName = "UpdatedTokyo";
      var oldImage = mediasService.RetrieveImages(1).Result.Images.ToList()[0];

      //Act
      oldImage.Name = newImageName;
      var result = mediasService.UpdateImage(oldImage);

      //Assert
      Assert.Equal(newImageName, result.Result.Image.Name);
    }

    [Fact]
    public void DeleteImage_DeleteTokyoImage_ReturnedDeletedTokyoImageReply() {
      //Arrange
      var deletedImage = mediasService.RetrieveImages(1).Result.Images.ToList()[0];
      var oldImageDeletedAt = deletedImage.DeletedAt;

      //Act
      var result = mediasService.DeleteImage(deletedImage.Id);

      //Default
      deletedImage.Name = _imageNameDefault;
      deletedImage.DeletedAt = null;
      deletedImage.DeletedBy = null;
      deletedImage.DeletedReason = null;
      _ = mediasService.UpdateImage(deletedImage);

      //Assert
      Assert.NotEqual(oldImageDeletedAt, result.Result.Image.DeletedAt);
    }
  }
}