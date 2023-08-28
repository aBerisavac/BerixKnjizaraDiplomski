using Domain;
using EFDataAccess;
using Implementation.Password;
using Microsoft.AspNetCore.Mvc;

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
                new UseCase { Name = "Create Language" },
                new UseCase { Name = "Delete Language" },
                new UseCase { Name = "Update Language" },
                new UseCase { Name = "Get Languages" },
                new UseCase { Name = "Get Language" },
            };

      var roles = new List<Role>
            {
                new Role { Name = "admin"},
                new Role { Name = "user"},
                new Role { Name = "unauthenticated"},
            };

      var authors = new List<Author>
            {
                new Author { FirstName = "Breckyn", LastName = "Weber", BirthDate = new DateTime(1975, 1, 23) },
                new Author { FirstName = "Rownan", LastName = "Rubio", BirthDate = new DateTime(1997, 1, 3) },
                new Author { FirstName = "Helo", LastName = "Taylor", BirthDate = new DateTime(2022, 9, 11) },
                new Author { FirstName = "Oluwadamilola", LastName = "Anderson", BirthDate = new DateTime(1942, 4, 7) },
                new Author { FirstName = "Esmie", LastName = "Pittman", BirthDate = new DateTime(1980, 9, 22) },
                new Author { FirstName = "Jeriah", LastName = "Chan", BirthDate = new DateTime(1977, 9, 28) },
                new Author { FirstName = "Maryann", LastName = "Jensen", BirthDate = new DateTime(2002, 2, 25) },
                new Author { FirstName = "Lisanna", LastName = "Acevedo", BirthDate = new DateTime(2005, 1, 9) },
                new Author { FirstName = "Vanessa", LastName = "Moran", BirthDate = new DateTime(1996, 1, 2) },
                new Author { FirstName = "Shulem", LastName = "Burke", BirthDate = new DateTime(1986, 1, 24) },
                new Author { FirstName = "Martavion", LastName = "Anthony", BirthDate = new DateTime(2013, 11, 26) },
                new Author { FirstName = "Indi", LastName = "Marsh", BirthDate = new DateTime(1948, 12, 31) },
                new Author { FirstName = "Koralynn", LastName = "Hahn", BirthDate = new DateTime(2010, 9, 11) },
                new Author { FirstName = "Zoee", LastName = "Blackburn", BirthDate = new DateTime(2020, 5, 1) },
                new Author { FirstName = "Wiliam", LastName = "Park", BirthDate = new DateTime(2020, 11, 4) },
                new Author { FirstName = "Marli", LastName = "Nelson", BirthDate = new DateTime(1983, 9, 26) },
                new Author { FirstName = "Kashlynn", LastName = "Day", BirthDate = new DateTime(2005, 9, 25) },
                new Author { FirstName = "Yabsera", LastName = "Stokes", BirthDate = new DateTime(2008, 9, 21) },
                new Author { FirstName = "Jamiel", LastName = "Owen", BirthDate = new DateTime(2010, 6, 12) },
                new Author { FirstName = "Zayan", LastName = "Noble", BirthDate = new DateTime(2009, 6, 13) },
                new Author { FirstName = "Saarya", LastName = "Roberts", BirthDate = new DateTime(1953, 6, 27) },
                new Author { FirstName = "Kourtlyn", LastName = "Perkins", BirthDate = new DateTime(2015, 1, 13) },
                new Author { FirstName = "Kanav", LastName = "Navarro", BirthDate = new DateTime(1981, 2, 23) },
                new Author { FirstName = "Taelyn", LastName = "Reyes", BirthDate = new DateTime(1962, 4, 24) },
                new Author { FirstName = "Daniele", LastName = "Sexton", BirthDate = new DateTime(1971, 8, 7) },
                new Author { FirstName = "Norrin", LastName = "Boyle", BirthDate = new DateTime(1983, 10, 2) },
                new Author { FirstName = "Shaddai", LastName = "Espinoza", BirthDate = new DateTime(2013, 12, 1) },
                new Author { FirstName = "Gracyn", LastName = "Page", BirthDate = new DateTime(2004, 4, 15) },
                new Author { FirstName = "Montgomery", LastName = "Thornton", BirthDate = new DateTime(1953, 7, 18) },
                new Author { FirstName = "Maxfield", LastName = "Logan", BirthDate = new DateTime(1954, 12, 17) },
                new Author { FirstName = "Breindy", LastName = "Singleton", BirthDate = new DateTime(1955, 10, 26) },
                new Author { FirstName = "Joniyah", LastName = "Wilkerson", BirthDate = new DateTime(1988, 11, 10) },
                new Author { FirstName = "Khyrie", LastName = "Hartman", BirthDate = new DateTime(2008, 10, 21) },
                new Author { FirstName = "Naliah", LastName = "Woodard", BirthDate = new DateTime(1977, 2, 14) },
                new Author { FirstName = "Kendyll", LastName = "Peterson", BirthDate = new DateTime(1989, 2, 27) },
                new Author { FirstName = "Veralynn", LastName = "Foley", BirthDate = new DateTime(2020, 9, 30) },
                new Author { FirstName = "Hagan", LastName = "Dunlap", BirthDate = new DateTime(2013, 5, 3) },
                new Author { FirstName = "Daelen", LastName = "Vance", BirthDate = new DateTime(1982, 1, 29) },
                new Author { FirstName = "Dakota", LastName = "Luna", BirthDate = new DateTime(1975, 7, 1) },
                new Author { FirstName = "Duvid", LastName = "Watts", BirthDate = new DateTime(1998, 9, 12) },
                new Author { FirstName = "Jedson", LastName = "Vargas", BirthDate = new DateTime(1993, 12, 7) },
                new Author { FirstName = "Xxavier", LastName = "Garner", BirthDate = new DateTime(2001, 5, 7) },
                new Author { FirstName = "Jaydn", LastName = "Gillespie", BirthDate = new DateTime(2020, 4, 18) },
                new Author { FirstName = "Esthela", LastName = "Preston", BirthDate = new DateTime(1956, 11, 15) },
                new Author { FirstName = "Nassim", LastName = "Payne", BirthDate = new DateTime(1944, 6, 9) },
                new Author { FirstName = "Choice", LastName = "Mccann", BirthDate = new DateTime(1950, 12, 11) },
                new Author { FirstName = "Juri", LastName = "Barron", BirthDate = new DateTime(1943, 6, 21) },
                new Author { FirstName = "Mckinzley", LastName = "Schultz", BirthDate = new DateTime(1957, 3, 29) },
                new Author { FirstName = "Zahvia", LastName = "Harrison", BirthDate = new DateTime(2004, 1, 25) },
                new Author { FirstName = "Bayan", LastName = "Booth", BirthDate = new DateTime(1995, 9, 23) }
            };

      var genres = new List<Genre>
{
    new Genre { Name = "Science Fiction" },
    new Genre { Name = "Fantasy" },
    new Genre { Name = "Mystery" },
    new Genre { Name = "Thriller" },
    new Genre { Name = "Romance" },
    new Genre { Name = "Historical Fiction" },
    new Genre { Name = "Horror" },
    new Genre { Name = "Crime" },
    new Genre { Name = "Adventure" },
    new Genre { Name = "Young Adult" },
    new Genre { Name = "Dystopian" },
    new Genre { Name = "Paranormal" },
    new Genre { Name = "Contemporary" },
    new Genre { Name = "Literary Fiction" },
    new Genre { Name = "Humor" },
    new Genre { Name = "Suspense" },
    new Genre { Name = "Western" },
    new Genre { Name = "Chick Lit" },
    new Genre { Name = "Urban Fantasy" },
    new Genre { Name = "Women's Fiction" },
    new Genre { Name = "Action and Adventure" },
    new Genre { Name = "Memoir" },
    new Genre { Name = "Biography" },
    new Genre { Name = "Self-Help" },
    new Genre { Name = "True Crime" },
    new Genre { Name = "Business and Finance" },
    new Genre { Name = "Science and Technology" },
    new Genre { Name = "Travel and Exploration" },
    new Genre { Name = "Art and Photography" },
    new Genre { Name = "Children's" }
};

      var books = new List<Book>
            {
                new Book { Title = "To Kill A Mockingbird",  Description="Some vague description", ReleaseDate = new DateTime(1960, 5, 13) },
                new Book { Title = "Ulysses", Description="Quieres a saber la descripcion, no?", ReleaseDate = new DateTime(1930, 2, 24) }
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
      foreach (var useCase in useCases)
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
              UseCase = useCases.ElementAt(useCaseId - 1),
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
