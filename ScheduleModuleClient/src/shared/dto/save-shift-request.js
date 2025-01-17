import { Shift } from "../models/shift.js";

export class SaveShiftRequest {
    constructor() {
       this.shift = new Shift();       
    }
}