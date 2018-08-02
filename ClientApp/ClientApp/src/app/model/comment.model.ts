import {BAIdentityUser} from './baidentityuser.model';
import {Accommodation} from './accommodation.model';

export class Comment{
    constructor(
    public Id: number,
    public Grade: number,
    public Text: string,
    public User: BAIdentityUser,
    public Accomodation: Accommodation
    ){}
}