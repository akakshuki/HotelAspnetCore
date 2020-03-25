import { GuestMv } from './guestmv.model';

export class BookingMv {
    id: number;
    guestId: number;
    bookingDate: Date;
    checkIn: Date;
    checkOut: Date
    durationStay: number
    secretCode: string;
    status: string;
    amount: number;
    guestMv : GuestMv;
}