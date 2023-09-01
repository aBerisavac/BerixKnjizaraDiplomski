import { OnInit } from "@angular/core";
import { UsersService } from "src/app/Services/users.service";

function getRandomDate(startDate: Date, endDate: Date) {
  /*
        const startDate = new Date('1940-01-01');
        const endDate = new Date('2022-12-31');
    */

  const timeDiff = endDate.getTime() - startDate.getTime();
  const randomTime = Math.random() * timeDiff;
  const randomDate = new Date(startDate.getTime() + randomTime);
  return randomDate.toISOString().slice(0, 10);
}



function getRandomNumber(min: number, max: number, decimals: number) {
  const scaledRandom = (Math.random() * (max - min) + min).toFixed(decimals);
  return parseFloat(scaledRandom);
}

function capitalizeFirstLetter(string: string) {
  return string.charAt(0).toUpperCase() + string.slice(1);
}

const CONSTANTS = {
}

const VALIDATORS = {
  email: (email: String): boolean => {
    const emailRegex =
    /^[a-z0-9!#$%&'*+\/=?^_‘{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_‘{|}~-]+)*@[a-z0-9](?:[a-z0-9-]*[a-z0-9])?(\.[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)*$/;
    return emailRegex.test(email as string)
  },
  stringNotNull: (string: String): boolean => {
    return string.trim().length>0;
  },
  variableNotUndefined: (variable: any): boolean => {
    return variable!=undefined;
  },
  min(number: string | number, minValue: number){
    number=parseFloat(number as string);

    if(number>minValue){
      return true;
    } else{
      return false;
    }
  },
  isNumber(number:string | number){
    number = parseFloat(number as string);
    return !Number.isNaN(number);
  }
};

 function capitalizePropertyNamesWithoutIdCapitalization(obj: any) {
  const newObj: { [key: string]: any } = {};

  for (let key in obj) {
    if (key != 'id') {
      const capitalizedKey = key.charAt(0).toUpperCase() + key.slice(1);
      newObj[capitalizedKey] = obj[key];
    } else {
      const capitalizedKey = 'id';
      newObj[capitalizedKey] = obj[key];
    }
  }

  return newObj;
}

export { getRandomDate, getRandomNumber, capitalizeFirstLetter, capitalizePropertyNamesWithoutIdCapitalization, VALIDATORS };
