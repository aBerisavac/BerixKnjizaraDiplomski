import { OrderInvoiceDTO } from '../dtos/OrderInvoiceDTO';
import { IEntityGetAll } from '../interfaces/common/IEntityGetAll';

export class OrderInvoiceModel implements IEntityGetAll {
  public orderInvoices: Array<OrderInvoiceDTO> = [];

  constructor() {
    if (localStorage.getItem('OrderInvoices') == undefined) {
      localStorage.setItem('OrderInvoices', JSON.stringify([]));
    }

    this.orderInvoices = JSON.parse(
      localStorage.getItem('OrderInvoices')!
    ) as Array<OrderInvoiceDTO>;
  }

  getAll<OrderInvoiceDTO>(): OrderInvoiceDTO[] {
    return this.orderInvoices as Array<OrderInvoiceDTO>;
  }

  private getMaxId(): number {
    return this.orderInvoices.sort((x, y) => y.id - x.id)[0].id;
  }

  private insert(orderInvoice: OrderInvoiceDTO) {
    if (this.orderInvoices.length == 0) {
      orderInvoice.id = 1;
    } else {
      orderInvoice.id = this.getMaxId() + 1;
    }

    this.orderInvoices.push(orderInvoice);
    localStorage.setItem('OrderInvoices', JSON.stringify(this.orderInvoices));
    return orderInvoice;
  }

  addInvoiceToOrder(orderInvoice: OrderInvoiceDTO): OrderInvoiceDTO {
    return this.insert(orderInvoice);
  }
}
