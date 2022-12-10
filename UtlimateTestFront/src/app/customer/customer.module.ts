import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersTableComponent } from './customers-table/customers-table.component';
import { CustomerModifyComponent } from './customer-modify/customer-modify.component';
import { RouterModule, Routes } from '@angular/router';
import {ReactiveFormsModule,FormsModule} from '@angular/forms';
const routes:Routes=[

  {
    path:"",redirectTo:"list",pathMatch:"full",
  },
  {
    path:"list",component:CustomersTableComponent
  },
  {
    path:"add",component:CustomerModifyComponent
  },
  {
    path:":id",component:CustomerModifyComponent
  },

]

@NgModule({
  declarations: [
    CustomersTableComponent,
    CustomerModifyComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
  ]
})
export class CustomerModule { }
