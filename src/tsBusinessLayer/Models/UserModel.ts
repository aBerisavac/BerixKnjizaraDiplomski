import { Observable, catchError, of } from 'rxjs';
import { UserDTO } from '../dtos/UserDTO';
import { UserInsertDTO } from '../dtos/UserInsertDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';
import { HttpClient } from '@angular/common/http';

export class UserModel implements IEntityGet {
  private users: Array<UserDTO>;

  constructor(private _http: HttpClient) {
    if (localStorage.getItem('Users') == undefined) {
      localStorage.setItem('Users', JSON.stringify([]));
    }

    this.users = JSON.parse(localStorage.getItem('Users')!) as Array<UserDTO>;
  }

  get<UserDTO>(id: number): UserDTO {
    return this.users.filter((x) => x.id == id)[0] as UserDTO;
  }

  getByEmail(email: string): UserDTO {
    return this.users.filter((x) => x.Email == email)[0] as UserDTO;
  }


  insert(newUser: UserInsertDTO){
    
    return this._http
      .post<any>('http://localhost:5111/api/user', newUser)
      .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
        // this.errorMessage = error.message;
        console.error('There was an error!', error);

        // after handling error, return a new observable 
        // that doesn't emit any values and completes
        return of();
    }))
      // .subscribe({
      //   next: (data) => {
      //     console.log("valja baki")
      //   }
      // });
  }

}