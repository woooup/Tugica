import {Place} from './place.model';
import{Country} from './country.model';


export class Region {
    
    constructor(
        public Id: number,
        public Name: string,
        public Places: Array<Place>,
        public Country: Country
    ) {

    }
}