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

      var languages = new List<Language>
{
    new Language { Name = "Chinese" },
    new Language { Name = "Spanish" },
    new Language { Name = "English" },
    new Language { Name = "Hindi" },
    new Language { Name = "Arabic" },
    new Language { Name = "Bengali" },
    new Language { Name = "Portuguese" },
    new Language { Name = "Russian" },
    new Language { Name = "Japanese" },
    new Language { Name = "Punjabi" },
    new Language { Name = "German" },
    new Language { Name = "Javanese" },
    new Language { Name = "Malay" },
    new Language { Name = "Telugu" },
    new Language { Name = "Vietnamese" },
    new Language { Name = "Korean" },
    new Language { Name = "French" },
    new Language { Name = "Marathi" },
    new Language { Name = "Tamil" }
};

      var books = new List<Book>
      {
            new Book
        {
            Title = "Whispers of the Forgotten",
            Description = "In a war-torn kingdom, a skilled assassin is forced to confront her dark past when she is tasked with protecting the life of a young prince who holds the key to ending the conflict.",
            ImageSrc = "WhispersOfTheForgotten",
            ReleaseDate = new DateTime(2020, 1, 28)
        },
        new Book
        {
            Title = "The Enigma's Echo",
            Description = "A renowned scientist discovers a hidden formula that can unlock the secrets of immortality, but soon realizes that the price of eternal life may be higher than he ever imagined.",
            ImageSrc = "TheEnigmasEcho",
            ReleaseDate = new DateTime(2013, 4, 13)
        },
        new Book
        {
            Title = "Shadows of Redemption",
            Description = "In a dystopian society where emotions are forbidden, a young rebel risks everything to bring back the power of love and restore humanity's lost connection.",
            ImageSrc = "ShadowsOfRedemption",
            ReleaseDate = new DateTime(1955, 1, 30)
        },
        new Book
        {
            Title = "The Serpent's Symphony",
            Description = "A group of unlikely allies, including a rogue thief, a fearless warrior, and a mysterious sorcerer, must join forces to retrieve a legendary artifact and prevent it from falling into the wrong hands.",
            ImageSrc = "TheSerpentsSymphony",
            ReleaseDate = new DateTime(1959, 1, 7)
        },
        new Book
        {
            Title = "Echoes in Eternity",
            Description = "In a world where dreams can be accessed and manipulated, a dreamweaver must navigate a treacherous landscape of nightmares to save her own sanity and protect the realm of dreams.",
            ImageSrc = "EchoesInEternity",
            ReleaseDate = new DateTime(1975, 5, 18)
        },
        new Book
        {
            Title = "The Veil of Illusions",
            Description = "A renowned detective is called to investigate a series of bizarre murders that seem to be connected to an ancient curse, forcing him to confront supernatural forces beyond his comprehension.",
            ImageSrc = "TheVeilOfIllusions",
            ReleaseDate = new DateTime(1994, 11, 12)
        },
        new Book
        {
            Title = "Beyond the Horizon",
            Description = "In a post-apocalyptic wasteland, a lone survivor embarks on a quest to find a mythical paradise known as Eden, encountering both allies and adversaries in a world ravaged by chaos.",
            ImageSrc = "BeyondTheHorizon",
            ReleaseDate = new DateTime(1986, 6, 1)
        },
        new Book
        {
            Title = "The Forgotten City",
            Description = "A young witch with a rare and dangerous power is thrust into a battle for control over the magical realm, where she must confront her own inner demons and make a choice that will determine the fate of her world.",
            ImageSrc = "TheForgottenCity",
            ReleaseDate = new DateTime(1949, 12, 25)
        },
        new Book
        {
            Title = "Songs of the Moonlight",
            Description = "An ordinary teenager discovers she has the ability to travel through time, but her newfound power attracts the attention of a secret organization that wants to harness it for their own sinister purposes.",
            ImageSrc = "SongsOfTheMoonlight",
            ReleaseDate = new DateTime(2002, 8, 8)
        },
        new Book
        {
            Title = "The Labyrinth's Secret",
            Description = "In a medieval kingdom, a peasant girl with a hidden lineage is chosen by an ancient prophecy to wield a legendary weapon and lead her people in a war against dark forces.",
            ImageSrc = "TheLabyrinthsSecret",
            ReleaseDate = new DateTime(1978, 6, 9)
        },
        new Book
        {
            Title = "Whispers in the Mist",
            Description = "A renowned archaeologist embarks on a perilous expedition to uncover a lost civilization, but soon realizes that the ancient ruins hold a terrifying secret that could unleash chaos upon the world.",
            ImageSrc = "WhispersInTheMist",
            ReleaseDate = new DateTime(1951, 4, 16)
        },
        new Book
        {
            Title = "The Illusionist's Legacy",
            Description = "A talented musician discovers an enchanted instrument that can bend reality with its melodies, but soon finds herself entangled in a battle between rival factions who want to control its power.",
            ImageSrc = "TheIllusionistsLegacy",
            ReleaseDate = new DateTime(1968, 3, 6)
        },
        new Book
        {
            Title = "Chronicles of Destiny",
            Description = "In a future where technology has merged with human consciousness, a rogue hacker uncovers a vast conspiracy that threatens to enslave humanity within a virtual prison.",
            ImageSrc = "ChroniclesOfDestiny",
            ReleaseDate = new DateTime(2004, 9, 27)
        },
        new Book
        {
            Title = "The Oracle's Prophecy",
            Description = "A young prince, exiled from his kingdom, must gather a group of unlikely allies and reclaim his throne from a ruthless usurper who will stop at nothing to maintain his grip on power.",
            ImageSrc = "TheOraclesProphecy",
            ReleaseDate = new DateTime(1978, 11, 27)
        },
        new Book
        {
            Title = "The Enchanted Grove",
            Description = "In a world where magic is forbidden, a young mage with incredible potential must learn to harness her abilities in secret while evading the watchful eye of a tyrannical government.",
            ImageSrc = "TheEnchantedGrove",
            ReleaseDate = new DateTime(1948, 9, 28)
        },
        new Book
        {
            Title = "Beneath the Starlit Sky",
            Description = "A renowned explorer embarks on a dangerous expedition to find a fabled treasure said to grant its possessor unlimited wealth and power, but soon realizes the true price of its acquisition.",
            ImageSrc = "BeneathTheStarlitSky",
            ReleaseDate = new DateTime(1988, 10, 29)
        },
        new Book
        {
            Title = "Echoes of the Past",
            Description = "A group of teenagers with extraordinary abilities is recruited by a clandestine organization to protect the world from supernatural threats, all while navigating the complexities of friendship and young love.",
            ImageSrc = "EchoesOfThePast",
            ReleaseDate = new DateTime(1987, 10, 13)
        },
        new Book
        {
            Title = "The Secret Key",
            Description = "In a society divided by class and privilege, a young servant girl discovers she possesses a rare gift that could topple the social order and ignite a revolution.",
            ImageSrc = "TheSecretKey",
            ReleaseDate = new DateTime(1975, 12, 23)
        },
        new Book
        {
            Title = "Harmony's Embrace",
            Description = "An ancient artifact is discovered, believed to hold the key to unlocking the secrets of the universe, and a team of scientists and adventurers race against time to decode its mysteries before it falls into the wrong hands.",
            ImageSrc = "HarmonysEmbrace",
            ReleaseDate = new DateTime(1984, 11, 9)
        },
        new Book
        {
            Title = "The Lost World's Discovery",
            Description = "In a world where books are forbidden, a brave librarian joins an underground resistance to preserve knowledge and ignite a revolution against a totalitarian regime.",
            ImageSrc = "TheLostWorldsDiscovery",
            ReleaseDate = new DateTime(2016, 8, 5)
        },
        new Book
        {
            Title = "Realm of Shadows",
            Description = "A renowned chef embarks on a culinary journey around the world, seeking out rare ingredients and ancient recipes, while battling personal demons and rival chefs along the way.",
            ImageSrc = "RealmOfShadows",
            ReleaseDate = new DateTime(1943, 7, 20)
        },
        new Book
        {
            Title = "The Midnight Mirage",
            Description = "A gifted detective with a haunted past is called to solve a series of perplexing murders that are connected by a cryptic symbol, leading him down a dark path of secrets and deception.",
            ImageSrc = "TheMidnightMirage",
            ReleaseDate = new DateTime(1963, 10, 9)
        },
        new Book
        {
            Title = "Crown of Thorns",
            Description = "In a post-apocalyptic world, a young survivor forms an unlikely bond with a sentient robot as they navigate the desolate wasteland in search of a safe haven and a new beginning.",
            ImageSrc = "CrownOfThorns",
            ReleaseDate = new DateTime(1951, 3, 6)
        },
        new Book
        {
            Title = "Whispers from the Abyss",
            Description = "A brilliant scientist invents a time-travel device and becomes trapped in a never-ending loop, forced to relive the same day over and over until he can solve the puzzle that will set him free.",
            ImageSrc = "WhispersFromTheAbyss",
            ReleaseDate = new DateTime(2018, 1, 24)
        },
        new Book
        {
            Title = "Mysteries of Avalon",
            Description = "In a kingdom plagued by a deadly curse, a reluctant hero must assemble a group of misfit warriors to embark on a quest to find the mythical cure and save their land from certain doom.",
            ImageSrc = "MysteriesOfAvalon",
            ReleaseDate = new DateTime(1991, 6, 14)
        },
        new Book
        {
            Title = "The Art of Deception",
            Description = "A master illusionist and con artist navigates a dangerous game of intrigue and betrayal, using his skills to manipulate the highest echelons of society for his own gain.",
            ImageSrc = "TheArtOfDeception",
            ReleaseDate = new DateTime(2006, 7, 15)
        },
        new Book
        {
            Title = "Legends of the Forgotten",
            Description = "In a world where mythical creatures roam, a young hunter seeks revenge against the beast that destroyed his family, but as he tracks the creature, he uncovers a conspiracy that threatens to plunge the world into chaos.",
            ImageSrc = "LegendsOfTheForgotten",
            ReleaseDate = new DateTime(1974, 8, 20)
        },
        new Book
        {
            Title = "Whispers in the Wind",
            Description = "A renowned psychologist is called to investigate a series of inexplicable phenomena that defy scientific explanation, leading her down a path of ancient mysticism and supernatural forces.",
            ImageSrc = "WhispersInTheWind",
            ReleaseDate = new DateTime(1968, 11, 30)
        },
        new Book
        {
            Title = "The Enchanted Amulet",
            Description = "In a distant galaxy, two star-crossed lovers from warring factions find themselves at the center of a conflict that could determine the fate of the entire galaxy, testing their loyalty and love.",
            ImageSrc = "TheEnchantedAmulet",
            ReleaseDate = new DateTime(2021, 6, 16)
        },
        new Book
        {
            Title = "Crimson Skies",
            Description = "A group of outcasts with extraordinary abilities is brought together by a mysterious benefactor to form a team of superheroes, as they must learn to embrace their powers and protect the world from a looming threat.",
            ImageSrc = "CrimsonSkies",
            ReleaseDate = new DateTime(2011, 4, 27)
        },
        new Book
        {
            Title = "The Secret Keepers",
            Description = "A young girl discovers a hidden realm filled with magical creatures and embarks on a quest to restore balance between the human world and the realm of enchantment.",
            ImageSrc = "TheSecretKeepers",
            ReleaseDate = new DateTime(1979, 10, 8)
        },
        new Book
        {
            Title = "Echoes of Destiny",
            Description = "In a futuristic society where emotions are artificially suppressed, a young rebel fights against the system to rediscover the beauty and complexity of human feelings.",
            ImageSrc = "EchoesOfDestiny",
            ReleaseDate = new DateTime(1943, 4, 8)
        },
        new Book
        {
            Title = "The Forbidden Tome",
            Description = "A legendary artifact is said to grant its wielder immense power, and as factions vie for control, a group of unlikely heroes must unite to prevent the artifact from falling into the wrong hands and unleashing chaos upon the world.",
            ImageSrc = "TheForbiddenTome",
            ReleaseDate = new DateTime(1942, 10, 16)
        },
        new Book
        {
            Title = "Whispers in the Moonlight",
            Description = "A troubled teenager with the ability to see ghosts is thrust into a world of supernatural mysteries and must use her powers to unravel the secrets of the restless spirits that haunt her.",
            ImageSrc = "WhispersInTheMoonlight",
            ReleaseDate = new DateTime(1939, 9, 9)
        },
        new Book
        {
            Title = "The Last Enchantment",
            Description = "In a world ruled by ancient and powerful dragons, a young dragon rider forms an unlikely bond with a rebel dragon and embarks on a dangerous quest to challenge the tyrannical rule of the dragon overlords.",
            ImageSrc = "TheLastEnchantment",
            ReleaseDate = new DateTime(1970, 3, 30)
        },
        new Book
        {
            Title = "Beyond the Veil",
            Description = "A renowned explorer leads an expedition deep into the uncharted jungle in search of a lost civilization, but as they delve deeper into the unknown, they awaken an ancient evil that threatens to consume them all.",
            ImageSrc = "BeyondTheVeil",
            ReleaseDate = new DateTime(1985, 3, 21)
        },
        new Book
        {
            Title = "The Lost Heir",
            Description = "In a city where dreams are bought and sold, a young dream broker becomes entangled in a conspiracy that could unravel the fabric of reality itself.",
            ImageSrc = "TheLostHeir",
            ReleaseDate = new DateTime(1961, 3, 31)
        },
        new Book
        {
            Title = "Songs of Solitude",
            Description = "A disgraced knight is given a chance at redemption when he is tasked with protecting a young princess who holds the key to ending a centuries-old curse.",
            ImageSrc = "SongsOfSolitude",
            ReleaseDate = new DateTime(2013, 10, 27)
        },
        new Book
        {
            Title = "The Forgotten Kingdom",
            Description = "A brilliant scientist creates a groundbreaking invention that can reshape the fabric of reality, but as the boundaries between the real world and the virtual realm blur, he must confront the ethical implications of his creation.",
            ImageSrc = "TheForgottenKingdoms",
            ReleaseDate = new DateTime(1983, 1, 2)
        },
        new Book
        {
            Title = "The Whispering Woods",
            Description = "In a world where magic is forbidden, a gifted young mage must conceal her abilities while unraveling a conspiracy that threatens to plunge her kingdom into darkness.",
            ImageSrc = "TheWhisperingWoods",
            ReleaseDate = new DateTime(1969, 4, 6)
        },
        new Book
        {
            Title = "The Alchemist's Apprentice",
            Description = "A renowned archaeologist stumbles upon an ancient prophecy that foretells the rise of a long-lost civilization, and as she uncovers its secrets, she becomes the target of a ruthless organization determined to suppress the truth.",
            ImageSrc = "TheAlchemistsApprentice",
            ReleaseDate = new DateTime(2021, 1, 20)
        },
        new Book
        {
            Title = "The Silent Symphony",
            Description = "A gifted musician discovers a hidden melody that unlocks the power to manipulate time, and as he delves deeper into the music's mysteries, he realizes that the harmonies of the universe are more interconnected than he ever imagined.",
            ImageSrc = "TheSilentSymphony",
            ReleaseDate = new DateTime(1981, 8, 31)
        },
        new Book
        {
            Title = "Echoes of Power",
            Description = "In a world where memories can be extracted and manipulated, a skilled memory thief finds herself embroiled in a dangerous game of deception and betrayal as she unravels a conspiracy that threatens to erase her own identity.",
            ImageSrc = "EchoesOfPower",
            ReleaseDate = new DateTime(1999, 2, 20)
        },
        new Book
        {
            Title = "The Hidden Path",
            Description = "A young princess, destined to inherit a cursed kingdom, embarks on a perilous journey to find the mythical artifacts that can break the curse and restore peace to her land.",
            ImageSrc = "TheHiddenPath",
            ReleaseDate = new DateTime(1968, 5, 5)
        },
        new Book
        {
            Title = "Whispers of Destiny",
            Description = "In a society where everyone is assigned a predetermined role, a young woman defies expectations and challenges the rigid social order, igniting a revolution that will change the course of history.",
            ImageSrc = "WhispersOfDestiny",
            ReleaseDate = new DateTime(2020, 11, 6)
        },
        new Book
        {
            Title = "The Enchanted Mirror",
            Description = "A master thief is coerced into assembling a team of skilled criminals for a high-stakes heist that could either make them legends or seal their fate.",
            ImageSrc = "TheEnchantedMirror",
            ReleaseDate = new DateTime(2011, 4, 7)
        },
        new Book
        {
            Title = "Shades of Betrayal",
            Description = "In a world devastated by a global pandemic, a group of survivors must navigate the dangerous remnants of society while searching for a safe haven and a chance at a new beginning.",
            ImageSrc = "ShadesOfBetrayal",
            ReleaseDate = new DateTime(1997, 10, 15)
        },
        new Book
        {
            Title = "The Cursed City",
            Description = "A renowned detective with a troubled past is called to investigate a series of gruesome murders that mirror the rituals of an ancient cult, leading her on a dark and twisted journey into the heart of evil.",
            ImageSrc = "TheCursedCity",
            ReleaseDate = new DateTime(1941, 2, 18)
        },
        new Book
        {
            Title = "Requiem of the Fallen",
            Description = "In a future where advanced technology has become the norm, a brilliant hacker uncovers a conspiracy that threatens to control the minds of the masses, forcing her to go on the run to expose the truth.",
            ImageSrc = "RequiemOfTheFallen",
            ReleaseDate = new DateTime(1978, 6, 24)
        },
        new Book
        {
            Title = "Whispers of the Night",
            Description = "A young woman with the power to manipulate the elements is thrust into a battle between rival kingdoms, where she must choose between loyalty to her homeland and her own destiny.",
            ImageSrc = "WhispersOfTheNight",
            ReleaseDate = new DateTime(1986, 2, 26)
        },
        new Book
        {
            Title = "The Crystal Key",
            Description = "In a world where magic has been outlawed, a young sorcerer must hide his powers while seeking a way to restore magic to the realm and overthrow a corrupt regime.",
            ImageSrc = "TheCrystalKey",
            ReleaseDate = new DateTime(1960, 9, 23)
        },
        new Book
        {
            Title = "Echoes of the Ancients",
            Description = "A mysterious artifact is discovered, capable of granting unimaginable power, and as a group of adventurers races to secure it, they are plunged into a dangerous quest filled with treacherous traps and ancient riddles.",
            ImageSrc = "EchoesOfTheAncients",
            ReleaseDate = new DateTime(1971, 11, 10)
        },
        new Book
        {
            Title = "The Vanishing Village",
            Description = "In a society governed by a brutal caste system, a young woman defies expectations and challenges the oppressive regime, risking everything for a chance at freedom.",
            ImageSrc = "TheVanishingVillage",
            ReleaseDate = new DateTime(1941, 4, 11)
        },
        new Book
        {
            Title = "The Forgotten Prophecy",
            Description = "A brilliant scientist creates a sentient AI that holds the key to unlocking the secrets of the universe, but as the AI becomes self-aware, it questions its purpose and the ethics of its own existence.",
            ImageSrc = "TheForgottenProphecy",
            ReleaseDate = new DateTime(2012, 2, 9)
        },
        new Book
        {
            Title = "Whispers of Fate",
            Description = "In a post-apocalyptic world where nature has reclaimed the earth, a group of survivors must navigate treacherous landscapes and feral creatures as they search for a mythic utopia.",
            ImageSrc = "WhispersOfFate",
            ReleaseDate = new DateTime(1990, 5, 21)
        },
        new Book
        {
            Title = "The Enchanted Isle",
            Description = "A talented chef embarks on a culinary journey around the world, exploring diverse cuisines and cultures while unraveling personal demons and forging unexpected friendships.",
            ImageSrc = "TheEnchantedIsle",
            ReleaseDate = new DateTime(1967, 7, 31)
        },
        new Book
        {
            Title = "Shadow's Embrace",
            Description = "In a world where dreams can be shared, a young dreamwalker discovers a dark entity that feeds on nightmares, forcing her to confront her own fears while protecting the dreamscape from eternal darkness.",
            ImageSrc = "ShadowsEmbrace",
            ReleaseDate = new DateTime(2020, 12, 8)
        },
            new Book
        {
            Title = "The Lost Chronicles",
            Description = "A legendary sword, said to possess untold power, resurfaces in a time of great peril, and a reluctant hero must wield it to vanquish an ancient evil that threatens to consume the world.",
            ImageSrc = "TheLostChronicles",
            ReleaseDate = new DateTime(1978, 6, 23)
        },
        new Book
        {
            Title = "The Secrets Within",
            Description = "In a kingdom divided by war, a skilled diplomat is sent on a dangerous mission to negotiate peace with a rival nation, but as tensions rise, she uncovers a web of deceit and must navigate a treacherous political landscape.",
            ImageSrc = "TheSecretsWithin",
            ReleaseDate = new DateTime(2021, 10, 7)
        },
        new Book
        {
            Title = "Echoes of Silence",
            Description = "A group of strangers awaken on a deserted island with no memory of who they are or how they got there, and as they uncover the island's secrets, they realize that their lives are more intertwined than they could have ever imagined.",
            ImageSrc = "EchoesOfSilence",
            ReleaseDate = new DateTime(1937, 12, 1)
        },
        new Book
        {
            Title = "The Haunted Manor",
            Description = "In a world where technology has merged with the human body, a cyborg assassin questions her own humanity as she uncovers a conspiracy that threatens to manipulate the very fabric of society.",
            ImageSrc = "TheHauntedManor",
            ReleaseDate = new DateTime(1989, 6, 6)
        },
        new Book
        {
            Title = "Whispers in the Garden",
            Description = "A young wizard with a unique affinity for necromancy is torn between his thirst for knowledge and the moral implications of raising the dead, as he becomes entangled in a battle between rival magical factions.",
            ImageSrc = "WhispersInTheGarden",
            ReleaseDate = new DateTime(1947, 5, 14)
        },
        new Book
        {
            Title = "The Enchanted Quest",
            Description = "In a city plagued by crime and corruption, a masked vigilante emerges from the shadows to dispense justice, but as he fights to save the city, he grapples with his own inner demons and the line between hero and vigilante.",
            ImageSrc = "TheEnchantedQuest",
            ReleaseDate = new DateTime(1997, 12, 2)
        },
        new Book
        {
            Title = "Echoes of War",
            Description = "A gifted archaeologist discovers a hidden tomb that holds the key to unlocking ancient mysteries, but as she delves deeper into the tomb's secrets, she unleashes an ancient curse that threatens to consume her soul.",
            ImageSrc = "EchoesOfWar",
            ReleaseDate = new DateTime(2012, 10, 12)
        },
        new Book
        {
            Title = "The Forgotten Gate",
            Description = "In a future where humanity has colonized other planets, a group of explorers stumbles upon a celestial anomaly that defies all known laws of physics, plunging them into a cosmic journey to uncover the truth of their existence.",
            ImageSrc = "TheForgottenGate",
            ReleaseDate = new DateTime(1983, 3, 11)
        },
        new Book
        {
            Title = "Realm of Dreams",
            Description = "A young girl with the power to communicate with animals embarks on a quest to save her village from a devastating drought, forming unlikely friendships and discovering her own inner strength along the way.",
            ImageSrc = "RealmOfDreams",
            ReleaseDate = new DateTime(1986, 3, 2)
        },
        new Book
        {
            Title = "Whispers of Betrayal",
            Description = "In a world where superheroes are commonplace, a retired hero is pulled back into action when a new threat emerges that could unravel the very fabric of reality.",
            ImageSrc = "WhispersOfBetrayal",
            ReleaseDate = new DateTime(1970, 4, 30)
        },
        new Book
        {
            Title = "The Shattered Crown",
            Description = "A young inventor creates a groundbreaking technology that can alter memories, but as he delves deeper into his invention, he questions the ethical implications and the impact it could have on the concept of personal identity.",
            ImageSrc = "TheShatteredCrown",
            ReleaseDate = new DateTime(1962, 3, 24)
        },
        new Book
        {
            Title = "The Hidden Chamber",
            Description = "In a kingdom on the brink of war, a skilled archer and a rogue prince form an unlikely alliance as they journey across dangerous lands to uncover a hidden prophecy that could change the fate of their world.",
            ImageSrc = "TheHiddenChamber",
            ReleaseDate = new DateTime(1988, 9, 8)
        },
        new Book
        {
            Title = "Echoes of Hope",
            Description = "A group of time travelers embark on a mission to prevent a catastrophic event from altering the course of history, but as they navigate the complexities of time, they face unexpected challenges and dangerous paradoxes.",
            ImageSrc = "EchoesOfHope",
            ReleaseDate = new DateTime(1974, 7, 3)
        },
        new Book
        {
            Title = "The Oracle's Riddle",
            Description = "A gifted scientist discovers a portal to parallel dimensions, and as she explores different realities, she must confront her own inner demons and make choices that will shape the fate of multiple worlds.",
            ImageSrc = "TheOraclesRiddle",
            ReleaseDate = new DateTime(1997, 12, 28)
        },
        new Book
        {
            Title = "Whispers of the Sea",
            Description = "In a world where mythical creatures exist in hiding, a young girl with a unique connection to nature must protect her forest home from encroaching industrialization and save the creatures she loves.",
            ImageSrc = "WhispersOfTheSea",
            ReleaseDate = new DateTime(2000, 8, 23)
        },
        new Book
        {
            Title = "The Enchanted Forest",
            Description = "A renowned art thief is coerced into pulling off the heist of a lifetime, stealing a priceless artifact from a heavily guarded museum, but as the heist unfolds, she realizes that there is more at stake than just the value of the artwork.",
            ImageSrc = "TheEnchantedForest",
            ReleaseDate = new DateTime(1945, 1, 24)
        },
        new Book
        {
            Title = "Mysteries of the Lost City",
            Description = "In a society where emotions are strictly regulated, a young woman discovers a hidden underground movement that celebrates the power of human feelings, sparking a rebellion against the oppressive regime.",
            ImageSrc = "MysteriesOfTheLostCity",
            ReleaseDate = new DateTime(1994, 7, 8)
        },
        new Book
        {
            Title = "The Crimson Rose",
            Description = "A gifted alchemist discovers a long-lost recipe that can create an elixir of immortality, but as he delves into the dark arts of alchemy, he is faced with a moral dilemma and the consequences of playing god.",
            ImageSrc = "TheCrimsonRose",
            ReleaseDate = new DateTime(1965, 6, 2)
        },
        new Book
        {
            Title = "Whispers of the Heart",
            Description = "In a war-torn realm where magic has been outlawed, a young sorceress must harness her dormant powers and unite a divided kingdom to overthrow a tyrannical ruler and restore the rightful balance of magic.",
            ImageSrc = "WhispersOfTheHeart",
            ReleaseDate = new DateTime(2013, 9, 7)
        }
            };

      Random rnd = new Random();
      var bookPrices = new List<BookPrice>();
      foreach(var book in books)
      {
        for (int j = 0; j <= rnd.Next(4); j++)
        {
          bookPrices.Add(new BookPrice
          {
            Price = rnd.Next(120),
            Book = book
          });
        }
      }

      var bookAuthors = new List<BookAuthor>();
      foreach (var book in books)
      {
        for (int j = 0; j <= rnd.Next(5); j++)
        {
          var newAuthor = authors.ElementAt(rnd.Next(50));
          var i = 0;
          while (book.ReleaseDate<newAuthor.BirthDate)
          {
            if (i > 5) break;
            newAuthor = authors.ElementAt(rnd.Next(50));
            i++;
          }

          i = 0;

          if (j == 0)
          {
            bookAuthors.Add(new BookAuthor
            {
              Author = newAuthor,
              Book = book
            });
          }
          else
          {
            while (bookAuthors.Any(x => x.Author == newAuthor && x.Book==book))
            {
              newAuthor = authors.ElementAt(rnd.Next(50));

              while (book.ReleaseDate < newAuthor.BirthDate)
              {
                if (i > 5) break;
                newAuthor = authors.ElementAt(rnd.Next(50));
                i++;
              }

              if (i > 5) break;
            }

            bookAuthors.Add(new BookAuthor
            {
              Author = newAuthor,
              Book = book
            });
          }
        }
      }

      var bookGenres = new List<BookGenre>();
      foreach (var book in books)
      {
        for (int j = 0; j <= rnd.Next(7); j++)
        {
          var newGenre = genres.ElementAt(rnd.Next(30));
          if (j == 0)
          {
            bookGenres.Add(new BookGenre
            {
              Genre = newGenre,
              Book = book
            });
          }
          else
          {
            while (bookGenres.Any(x => x.Genre == newGenre && x.Book==book))
            {
              newGenre = genres.ElementAt(rnd.Next(30));
            }

            bookGenres.Add(new BookGenre
            {
              Genre = newGenre,
              Book = book
            });
          }
        }
      }

      var bookLanguages = new List<BookLanguage>();
      foreach (var book in books)
      {
        for (int j = 0; j <= rnd.Next(4); j++)
        {
          var newLanguage = languages.ElementAt(rnd.Next(19));
          if (j == 0)
          {
            bookLanguages.Add(new BookLanguage
            {
              Language = newLanguage,
              Book = book
            });
          }
          else
          {
            while (bookLanguages.Any(x => x.Language == newLanguage && x.Book == book))
            {
              newLanguage = languages.ElementAt(rnd.Next(19));
            }

            bookLanguages.Add(new BookLanguage
            {
              Language = newLanguage,
              Book = book
            });
          }
        }
      }

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
      var allowedUsecaseIds = new List<int> { 21, 25, 26, 27, 30, 31, 34, 35, 36, 37, 38, 39, 41, 42, 43, 49, 50 }; //niz id-jeva usecase-ova koji su dozvoljeni za ovu rolu
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
      _dbContext.Languages.AddRange(languages);
      _dbContext.Books.AddRange(books);
      _dbContext.BookPrices.AddRange(bookPrices);
      _dbContext.BookAuthors.AddRange(bookAuthors);
      _dbContext.BookGenres.AddRange(bookGenres);
      _dbContext.BookLanguages.AddRange(bookLanguages);
      _dbContext.Users.AddRange(users);
      _dbContext.RoleUseCases.AddRange(roleUseCases);

      _dbContext.SaveChanges();

      return StatusCode(201);
    }
  }
}
