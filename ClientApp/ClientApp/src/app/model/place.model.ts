import{Region} from './region.model';
import{Accommodation} from './accommodation.model';


export class Place{
    constructor(
    public Id: number,
    public Name: string,
    public Region: Region,
  //  public Accommodations: Array<Accommodation>
    ){}

    
    public toString():string {
        return this.Name;
    }
}