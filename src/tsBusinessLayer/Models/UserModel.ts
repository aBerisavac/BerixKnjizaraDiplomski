import { UserDTO } from '../dtos/UserDTO';
import { IEntityGet } from '../interfaces/common/IEntityGet';

export class UserModel implements IEntityGet {
  private users: Array<UserDTO>;

  constructor() {
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

  checkIfUserExists(newUser: UserDTO): boolean {
    try {
      let userToInsert: UserDTO;
      if (this.users.length == 0) {
        userToInsert = new UserDTO(
          1,
          newUser.FirstName,
          newUser.LastName,
          newUser.Email,
          newUser.Address
        );

        this.users.push(userToInsert);
        localStorage.setItem('Users', JSON.stringify(this.users));
      } else {
        userToInsert = this.getByEmail(newUser.Email as string);

        if (userToInsert == undefined) {
          let newId = this.users.sort((x, y) => x.id - y.id)[0].id + 1;
          userToInsert = new UserDTO(
            newId,
            newUser.FirstName,
            newUser.LastName,
            newUser.Email,
            newUser.Address
          );

          this.users.push(userToInsert);
          localStorage.setItem('Users', JSON.stringify(this.users));
        }
      }
      return true;
    } catch (ex) {
      return false;
    }
  }
}
