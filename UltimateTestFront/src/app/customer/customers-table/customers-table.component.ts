import { Component, KeyValueDiffers, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers-service.service';
import { Customer } from '../customer';
declare var window: any;
@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.scss']
})
export class CustomersTableComponent implements OnInit {
  formModal: any;
  customers: Customer[] = [];
  selectedId = 0;
  pageNumber = 1;
  keys: (keyof Customer)[] = ['code', 'name', 'mobile', 'description'];
  totalNumberOfPages: number = 0;
  constructor(private customerServ: CustomersService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(res => {
      this.pageNumber = res["pageNumber"] ? +res["pageNumber"] : 1;
      this.retrieveCustomers(this.pageNumber);
    });
    this.retrieveCustomers(this.pageNumber);
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('myModal')
    );
  }
  Update(id: number) {
    this.router.navigate(["customers/" + id]);
  }
  Delete(id: number) {
    this.selectedId = id;
    this.formModal.show();
  }
  ConfirmDelete() {
    if (this.selectedId) {
      this.formModal.hide();
      this.customerServ.DeleteCustomer(this.selectedId).subscribe(() => {
        const index=this.customers.findIndex(x=> x.id=this.selectedId);
        this.customers.splice(index,1);
        this.closeModal();
      })
    }
  }
  closeModal() {
    this.selectedId = 0;
    this.formModal.hide();
  }
  navigate(page:number) {
    this.router.navigate([''], { queryParams: { pageNumer:page }, relativeTo: this.route });
  }

  retrieveCustomers(page: number) {
    this.customerServ.GetCustomers(page).subscribe(res => {
      this.customers = res.data;
      this.totalNumberOfPages = res.numbOfPages;
    });
  }
}


