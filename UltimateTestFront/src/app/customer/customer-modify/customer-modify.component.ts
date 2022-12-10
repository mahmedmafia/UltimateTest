import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers-service.service';
import { Address } from '../customer';

@Component({
  selector: 'app-customer-modify',
  templateUrl: './customer-modify.component.html',
  styleUrls: ['./customer-modify.component.scss'],
})
export class CustomerModifyComponent implements OnInit {
  isUpdate = false;
  customerForm!: FormGroup;
  constructor(
    private router: Router,
    private customerServ: CustomersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((res) => {
      this.isUpdate = res['id'] && !isNaN(res["id"]) ? true : false;
      if (this.isUpdate) {
        this.customerServ.GetCustomer(res['id']).subscribe((res) => {
          if(!res) this.navigateBack();
          let addresses = res.addresses;
          res.addresses = [];
          if (addresses?.length == 0 || !addresses) {
            this.addAddress();
          } else {
            this.customerForm.setValue(res);
            for (let address of addresses) {
              this.addAddress(address);
            }
          }
        });
      }
    });
    this.customerForm = new FormGroup({
      id: new FormControl(0),
      code: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      mobile: new FormControl('', Validators.required),
      description: new FormControl(''),
      addresses: new FormArray(
        [],
        [Validators.minLength(1), Validators.required]
      ),
    });
    if(!this.isUpdate)this.addAddress();
  }
  get AddressesArray() {
    return this.customerForm.controls['addresses'] as FormArray;
  }
  addAddress(address?: Address) {
    this.AddressesArray.push(this.newAddress(address));
  }
  removeAddress(index: number) {
    this.AddressesArray.removeAt(index);
  }
  newAddress(address?: Address) {
    let addressForm=new FormGroup({
      id: new FormControl( 0),
      city: new FormControl(  ' ', Validators.required),
      zone: new FormControl( '', Validators.required),
      street: new FormControl('', Validators.required),
      building: new FormControl( 0, Validators.required),
      floor: new FormControl(0, Validators.required),
    });
    if(address) addressForm.setValue(address);
    return addressForm;
  }
  ModifyCustomer() {
    if (this.customerForm.valid) {
      if (!this.isUpdate)
        this.customerServ.AddCustomer(this.customerForm.value).subscribe(() => {
          this.navigateBack();
        });
      if (this.isUpdate)
        this.customerServ
          .UpdateCustomer(this.customerForm.value)
          .subscribe(() => {
            this.navigateBack();
          });
    }
  }
  navigateBack() {
    this.router.navigate(['/customers/list']);
  }
}
