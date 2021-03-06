import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'booleanPipe',
    pure: true
})

export class BooleanPipe implements PipeTransform{

    transform(value: string, args?: any): any {
        return this.transformBoolean(value);
    }

    transformBoolean(b : string) : string{
        if(b == 'True'){
            return 'True';
        }
        else{
            return 'False';
        }
    }

}