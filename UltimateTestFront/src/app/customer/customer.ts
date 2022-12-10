export interface Customer {
    id: number;
    code: string;
    name: string;
    mobile: string;
    description: string;
    addresses?: Address[];
}
export interface Address {
    id: number;
    city: string;
    zone: string;
    street: string;
    building: number;
    floor: number;
}
