import {IHomeParagraph} from "../interfaces/IHomeParagraph"

export class HomeParagraphDTO implements IHomeParagraph{
    public id:number;
    public Paragraph:String;

    constructor(id:number, paragraph: String){
        this.id = id;
        this.Paragraph = paragraph;
    }
}