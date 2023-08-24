import { BookDTO } from '../dtos/BookDTO';
import { OrderDTO } from '../dtos/OrderDTO';
import { OrderInvoiceDTO } from '../dtos/OrderInvoiceDTO';
import { UserDTO } from '../dtos/UserDTO';
import { IAddOrder } from '../interfaces/IAddOrder';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';
import { BookModel } from './BookModel';
import { OrderInvoiceModel } from './OrderInvoiceModel';
import { UserModel } from './UserModel';

export class OrderModel implements IEntityGetAll {
  private orders: Array<OrderDTO>;
  private userModel: UserModel;
  private bookModel: BookModel;
  private orderInvoiceModel: OrderInvoiceModel;

  constructor() {
    if (localStorage.getItem('Orders') == undefined) {
      localStorage.setItem('Orders', JSON.stringify([]));
    }

    this.orders = JSON.parse(
      localStorage.getItem('Orders')!
    ) as Array<OrderDTO>;
    this.userModel = new UserModel();
    this.bookModel = new BookModel();
    this.orderInvoiceModel = new OrderInvoiceModel();
  }
  getAll<OrderModelDTO>(): OrderModelDTO[] {
    return this.orders as Array<OrderModelDTO>;
  }

  private getMaxId(): number {
    return this.orders.sort((x, y) => y.id - x.id)[0].id;
  }

  public addOrder = (data: IAddOrder) => {
    //user logic
    let user = this.userModel.getByEmail(data.Email as string);
    if (user == undefined) {
      let newUser = new UserDTO(
        -1,
        data.FirstName,
        data.LastName,
        data.Email,
        data.Address
      );
      this.userModel.checkIfUserExists(newUser);

      user = this.userModel.getByEmail(data.Email as string);
    }

    //orderInvoice logic
    let orderInvoices: Array<OrderInvoiceDTO> = [];
    for (let item of data.items) {
      orderInvoices.push(
        this.orderInvoiceModel.addInvoiceToOrder(
          new OrderInvoiceDTO(
            -1,
            this.bookModel.get(item.id) as BookDTO,
            item.Quantity
          )
        )
      );
    }

    let order = new OrderDTO(-1, user, data.ShippingMethod, orderInvoices);
    if (this.orders.length == 0) {
      order.id = 1;
    } else {
      order.id = this.getMaxId() + 1;
    }

    this.orders.push(order);
    localStorage.setItem('Orders', JSON.stringify(this.orders));
  };
}
