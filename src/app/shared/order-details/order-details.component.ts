import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IOrderAdmin } from 'src/app/Interfaces/IOrderAdmin';
import { OrderDTO } from 'src/tsBusinessLayer/dtos/OrderDTO';
import { OrderInvoiceDTO } from 'src/tsBusinessLayer/dtos/OrderInvoiceDTO';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss'],
})
export class OrderDetailsComponent {
  @Input() order: OrderDTO | undefined = undefined;
  @Output() close = new EventEmitter<any>();
}
