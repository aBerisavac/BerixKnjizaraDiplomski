using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.DTOs.Genres;
using Application.DTOs.IntersectEntities;
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
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, Book>()
               .ForMember(dto => dto.Authors, opt => opt.MapFrom(dto => dto.Authors.Select(x => new BookAuthor
               {
                   AuthorId = x.Id,
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
               .ForMember(dto => dto.Prices, opt => opt.MapFrom(dto => dto.Prices.Select(x => new BookPriceDTO
               {
                   BookId= x.Id,
                   Price= x.Price
               })))
                .ForMember(dto => dto.Genres, opt => opt.MapFrom(dto => dto.Genres.Select(x => new GenreDTO
                {
                    Id = x.Genre.Id,
                    Name = x.Genre.Name
                })));
        }
    }
}
