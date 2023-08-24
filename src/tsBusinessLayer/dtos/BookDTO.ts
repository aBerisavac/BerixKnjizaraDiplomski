import {IBook} from "../interfaces/IBook"
import { AuthorDTO } from "./AuthorDTO";
import { BookPriceDTO } from "./BookPriceDTO";
import { GenreDTO } from "./GenreDTO";
import { LanguageDTO } from "./LanguageDTO";

export class BookDTO implements IBook{
    public id:number;
    public Title:String;
    public Description:String;
    public ReleaseDate:Date;
    public ImageSrc:String;
    public Authors:Array<AuthorDTO>;
    public Genres:Array<GenreDTO>;
    public Languages:Array<LanguageDTO>;
    public BookPrices:Array<BookPriceDTO>;

    constructor(id:number, title: String, description: String, imageSrc: String, releaseDate: Date, authors:Array<AuthorDTO>, genres:Array<GenreDTO>, languages:Array<LanguageDTO>, bookPrices:Array<BookPriceDTO>){
        this.id = id;
        this.Title = title;
        this.Description = description;
        this.ImageSrc = imageSrc;
        this.ReleaseDate = releaseDate;
        this.Authors = authors;
        this.Genres = genres;
        this.Languages = languages;
        this.BookPrices = bookPrices;
    }
}