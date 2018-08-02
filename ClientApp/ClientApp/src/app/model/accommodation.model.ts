import{BAIdentityUser} from './baidentityuser.model';
import{Room} from './room.model';
import{Comment} from './comment.model';
import{AccommodationType} from './accommodation-type.model';
import {Place} from './place.model';

export class Accommodation{
    constructor(
    public Id: number,
    public Name: string,
    public Description: string,
    public Address: string,
    public AvrageGrade: number,
    public Latitude: number,
    public Longitude: number,
    public ImageURL: string,
    public Approved: boolean,
    public User: BAIdentityUser,
    public Rooms = new Array<Room>(),
    public Comments = new Array<Comment>(),
    public AccomodationType: AccommodationType,
    public Place: Place
    
    ){}
}