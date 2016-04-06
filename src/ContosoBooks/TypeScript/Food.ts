/**
 *  Food   
 */
class  Food {
    constructor(name: string, calories: number) {   
        this._name = name;
        this._calories = calories;
    }
    
    private _name: string;
    get Name() {
        return this._name;
    }
    
    private _calories: number;
    get Calories() {
        return this._calories;
    }
    
    private _taste: Tastes;
    get Tastes(): Tastes { 
        return this._taste 
    }
    set Tastes(value: Tastes) {
        this._taste = value;
    }
}