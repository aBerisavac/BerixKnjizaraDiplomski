import { IAuthor } from "./IAuthor";
import { IGenre } from "./IGenre";
import { ILanguage } from "./ILanguage";
import { IBookPrice } from "./IBookPrice";

export interface IBook {
    "id": number,
    "Title": String,
    "Description": String,
    "ImageSrc": String,
    "ReleaseDate": Date,
    "Authors": Array<IAuthor>,
    "Genres": Array<IGenre>,
    "Languages": Array<ILanguage>,
    "Prices": Array<IBookPrice>,
    "ImageBase64"?: String | null,
}