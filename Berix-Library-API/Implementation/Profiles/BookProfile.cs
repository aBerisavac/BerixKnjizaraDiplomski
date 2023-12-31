using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.DTOs.Genres;
using Application.DTOs.IntersectEntities;
using Application.DTOs.Languages;
using Application.DTOs.UseCases;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
  public class BookProfile : Profile
  {
    public BookProfile()
    {
      CreateMap<BookDTO, Book>()
         .ForMember(dto => dto.Authors, opt => opt.MapFrom(dto => dto.Authors.Select(x => new BookAuthor
         {
           AuthorId = x.Id,
           BookId = dto.Id
         })))
         .ForMember(dto => dto.Languages, opt => opt.MapFrom(dto => dto.Languages.Select(x => new BookLanguage
         {
           LanguageId = x.Id,
           BookId = dto.Id
         })))
         .ForMember(dto => dto.Prices, opt => opt.MapFrom(dto => dto.Prices.Select(x => new BookPrice
         {
           BookId = dto.Id,
           Price = x.Price
         })))
         .ForMember(dto => dto.Genres, opt => opt.MapFrom(dto => dto.Genres.Select(x => new BookGenre
         {
           GenreId = x.Id,
           BookId = dto.Id
         })));

      CreateMap<Book, BookDTO>()
         .ForMember(bookDto => bookDto.Authors, opt => opt.MapFrom(book => book.Authors.Select(x => new AuthorDTO
         {
           BirthDate = x.Author.BirthDate,
           FirstName = x.Author.FirstName,
           LastName = x.Author.LastName,
           Id = x.Author.Id
         })))
         .ForMember(bookDto => bookDto.Languages, opt => opt.MapFrom(book => book.Languages.Select(x => new LanguageDTO
         {
           Name = x.Language.Name,
           Id = x.Language.Id
         })))
         .ForMember(dto => dto.Prices, opt => opt.MapFrom(dto => dto.Prices.Select(x => new BookPriceDTO
         {
           BookId = x.Id,
           Price = x.Price
         })))
          .ForMember(dto => dto.Genres, opt => opt.MapFrom(dto => dto.Genres.Select(x => new GenreDTO
          {
            Id = x.Genre.Id,
            Name = x.Genre.Name
          })))
           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => GetImageBytes(src.ImageSrc)));
    }

    private static byte[] GetImageBytes(string imageSrc)
    {
      if (string.IsNullOrWhiteSpace(imageSrc))
        return null;

      try
      {
        string basePath = Directory.GetCurrentDirectory() + "\\Images\\books";
        string imagePath = Path.Combine(basePath, imageSrc) + ".jpg";
        byte[] imageBytes;
        using (FileStream fs = new FileStream(imagePath, FileMode.Open))
        {
          using (MemoryStream ms = new MemoryStream())
          {
            fs.CopyTo(ms);
            imageBytes = ms.ToArray();
          }
        }
        return imageBytes;
      }
      catch (Exception ex)
      {
        // Handle error or log exception
        return null;
      }
    }
  }
}
