import{BAIdentityUser} from './baidentityuser.model';
import{Room} from './room.model';
export class RoomReservations{
   constructor(
    public Id: number,
    public StartTime: string,
    public EndDate: string,
    public TimeStamp: string,
    public User: BAIdentityUser,
    public Room: Room
   ){}
}