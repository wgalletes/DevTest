import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerModel } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  public types: string[] = ['Large','Small'];

  public customers: CustomerModel[] = [];

  public newCustomer: CustomerModel = {
    customerId:0,
    name: null,
    type: null
  };

  constructor(
    private customerService: CustomerService) { }

  ngOnInit() {
    this.updateList();
  }

  public createCustomer(customerForm: NgForm): void {
    if (customerForm.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.newCustomer = {
          customerId: 0,
          name: null,
          type: null
        };
        this.updateList();
      });
    }
  }

  private updateList(): void {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

}
