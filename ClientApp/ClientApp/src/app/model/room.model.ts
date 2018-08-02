import {RoomReservations} from './room-reservations.model';
import {Accommodation} from './accommodation.model';

export class Room{
    constructor(
    public Id: number,
    public RoomNumber: number,
    public BedCount: number,
    public Description: string,
    public PricePerNight: number,
    public RoomReservations = new Array<RoomReservations>(),
    public Accomodation: Accommodation
    ){}
}