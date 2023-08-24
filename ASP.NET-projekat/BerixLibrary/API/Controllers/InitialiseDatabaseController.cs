using Domain;
using Implementation.Password;
using EFDataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialiseDatabaseController : ControllerBase
    {
        private readonly DBKnjizaraContext _dbContext;
        
        public InitialiseDatabaseController(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }
        // POST api/<InitialiseDatabaseController>
        [HttpPost]
        public IActionResult Post()
        {
            var shippingMethods = new List<ShippingMethod>
            {
                new ShippingMethod { Name = "Regular", Cost=30},
                new ShippingMethod { Name = "Express", Cost=45},
                new ShippingMethod { Name = "Urgent", Cost=72}
            };

            var useCases = new List<UseCase>
            {
                new UseCase { Name = "Create UseCase" },
                new UseCase { Name = "Delete UseCase" },
                new UseCase { Name = "Update UseCase" },
                new UseCase { Name = "Create ShippingMethod" },
                new UseCase { Name = "Delete ShippingMethod" },
                new UseCase { Name = "Update ShippingMethod" },
                new UseCase { Name = "Create Role" },
                new UseCase { Name = "Delete Role" },
                new UseCase { Name = "Update Role" },
                new UseCase { Name = "Create Author" },
                new UseCase { Name = "Delete Author" },
                new UseCase { Name = "Update Author" },
                new UseCase { Name = "Create Genre" },
                new UseCase { Name = "Delete Genre" },
                new UseCase { Name = "Update Genre" },
                new UseCase { Name = "Create Book" },
                new UseCase { Name = "Delete Book" },
                new UseCase { Name = "Update Book" },
                new UseCase { Name = "Create User" },
                new UseCase { Name = "Delete User" },
                new UseCase { Name = "Update User" },
                new UseCase { Name = "Create Log" },
                new UseCase { Name = "Delete Log" },
                new UseCase { Name = "Update Log" },
                new UseCase { Name = "Create Order" },
                new UseCase { Name = "Delete Order" },
                new UseCase { Name = "Update Order" },
                new UseCase { Name = "Get UseCases" },
                new UseCase { Name = "Get UseCase" },
                new UseCase { Name = "Get ShippingMethods" },
                new UseCase { Name = "Get ShippingMethod" },
                new UseCase { Name = "Get Roles" },
                new UseCase { Name = "Get Role" },
                new UseCase { Name = "Get Genres" },
                new UseCase { Name = "Get Genre" },
                new UseCase { Name = "Get Authors" },
                new UseCase { Name = "Get Author" },
                new UseCase { Name = "Get Books" },
                new UseCase { Name = "Get Book" },
                new UseCase { Name = "Get Users" },
                new UseCase { Name = "Get User" },
                new UseCase { Name = "Get Orders" },
                new UseCase { Name = "Get Order" },
                new UseCase { Name = "Get Logs" },
                new UseCase { Name = "Get Log" },
            };

            var roles = new List<Role>
            {
                new Role { Name = "admin"},
                new Role { Name = "user"},
                new Role { Name = "unauthenticated"},
            };

            var authors = new List<Author>
            {
                new Author {FirstName = "Aleksa", LastName = "Berisavac", BirthDate = new DateTime(1996, 1, 5)},
                new Author {FirstName = "Dusko", LastName = "Dugousko", BirthDate = new DateTime(1972, 5, 13)},
                new Author {FirstName = "Pera", LastName = "Detlic", BirthDate = new DateTime(1983, 10, 3)},
                new Author {FirstName = "Ptica", LastName = "Trkacica", BirthDate = new DateTime(2002, 7, 28)},
            };

            var genres = new List<Genre>
            {
                new Genre { Name = "Kriminalistika"},
                new Genre { Name = "Basna"},
                new Genre { Name = "Drama"},
                new Genre { Name = "Intriga"},
                new Genre { Name = "Istorija"},
                new Genre { Name = "Nauka"},
            };

            var books = new List<Book>
            {
                new Book { Title = "To Kill A Mockingbird", Language = "english", Description="Some vague description", ReleaseDate = new DateTime(1960, 5, 13) },
                new Book { Title = "Ulysses", Language = "spanish", Description="Quieres a saber la descripcion, no?", ReleaseDate = new DateTime(1930, 2, 24) }
            };

            var bookPrices = new List<BookPrice>
            {
                new BookPrice
                {
                    Price = 48,
                    Book = books.First()
                },

                new BookPrice
                {
                    Price = 27,
                    Book = books.ElementAt(1)
                }
            };

            var bookAuthors = new List<BookAuthor>
            {
                new BookAuthor
                {
                    Author = authors.First(),
                    Book = books.First()
                }, 
                
                new BookAuthor
                {
                    Author = authors.ElementAt(2),
                    Book = books.First()
                },
                
                new BookAuthor
                {
                    Author = authors.ElementAt(3),
                    Book = books.First()
                },
                
                new BookAuthor
                {
                    Author = authors.ElementAt(1),
                    Book = books.ElementAt(1)
                },
                
                new BookAuthor
                {
                    Author = authors.ElementAt(2),
                    Book = books.ElementAt(1)
                },
            };

            var bookGenres = new List<BookGenre>
            {
                new BookGenre
                {
                    Genre = genres.ElementAt(0),
                    Book = books.First()
                },

                new BookGenre
                {
                    Genre = genres.ElementAt(2),
                    Book = books.First()
                },

                new BookGenre
                {
                    Genre = genres.ElementAt(3),
                    Book = books.First()
                },

                new BookGenre
                {
                    Genre = genres.ElementAt(5),
                    Book = books.First()
                },

                new BookGenre
                {
                    Genre = genres.ElementAt(1),
                    Book = books.ElementAt(1)
                },

                new BookGenre
                {
                    Genre = genres.ElementAt(0),
                    Book = books.ElementAt(1)
                },

                new BookGenre
                {
                    Genre = genres.ElementAt(5),
                    Book = books.ElementAt(1)
                },
            };

            var users = new List<User>
            {
                new User
                {
                    Role = roles.First(),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                    Address = "Beograd 11000 Bulevar Kralja Aleksandra 187",
                    Password = PasswordHandler.ecrypt("admin123")
                }, 

                new User
                {
                    Role = roles.ElementAt(1),
                    FirstName = "User",
                    LastName = "User",
                    Email = "user@user.com",
                    Address = "Beograd 11000 Bulevar Kralja Aleksandra 189",
                    Password = PasswordHandler.ecrypt("user123")
                }, 

                new User
                {
                    Role = roles.ElementAt(2),
                    FirstName = "Unauthorized",
                    LastName = "User",
                    Email = "unknown",
                    Address = "unknown",
                    Password = PasswordHandler.ecrypt("user123")
                }, 
            };

            var roleUseCases = new List<RoleUseCase>();

            //dodavanje svih prava adminu
            foreach(var useCase in useCases)
            {
                roleUseCases.Add(
                    new RoleUseCase
                    {
                        UseCase = useCase,
                        Role = roles.First()
                    }
                );
            }

            //dodavanje nekih prava obicnom korisniku, za pocetak nista
            var allowedUsecaseIds = new List<int> { 21, 25, 26, 27, 30, 31, 34, 35, 36, 37, 38, 39, 41, 42, 43 }; //niz id-jeva usecase-ova koji su dozvoljeni za ovu rolu
            foreach (var useCaseId in allowedUsecaseIds)
            {
                roleUseCases.Add(
                    new RoleUseCase
                    {
                        UseCase = useCases.ElementAt(useCaseId-1),
                        Role = roles.ElementAt(1)
                    }
                );
            }

            _dbContext.ShippingMethods.AddRange(shippingMethods);
            _dbContext.UseCases.AddRange(useCases);
            _dbContext.Roles.AddRange(roles);
            _dbContext.Authors.AddRange(authors);
            _dbContext.Genres.AddRange(genres);
            _dbContext.Books.AddRange(books);
            _dbContext.BookPrices.AddRange(bookPrices);
            _dbContext.BookAuthors.AddRange(bookAuthors);
            _dbContext.BookGenres.AddRange(bookGenres);
            _dbContext.Users.AddRange(users);
            _dbContext.RoleUseCases.AddRange(roleUseCases);

            _dbContext.SaveChanges();

            return StatusCode(201);
        }
    }
}
