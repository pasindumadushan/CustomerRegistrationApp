import { Component, Input, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.scss']
})
export class CustomerDetailsComponent implements OnInit {

  @Input() viewMode = false;
  @Input() currentCustomer: Customer = {
    customerName: '',
    customerPNum: '',
    customerAddress: '',
    customerEmail: ''    
  };
  registerForm: FormGroup;
  submitted = false;
  message = '';

  constructor( private customerService: CustomerService,private route: ActivatedRoute,private router: Router,private toastr: ToastrService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getCustomer(this.route.snapshot.params["id"]);
    }
    this.registerForm = this.formBuilder.group({
      customerName: ['', Validators.required],
      customerPNum:['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      customerAddress: ['', Validators.required],
      customerEmail: ['', [Validators.required, Validators.email]],
    });
  }

  get f() { return this.registerForm.controls; }

  getCustomer(id: string): void {
    this.customerService.get(id)
      .subscribe({
        next: (data) => {
          this.currentCustomer = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

  updateCustomer(): void {
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }
    else{
      this.message = '';
      this.customerService.update(this.currentCustomer.customerId, this.currentCustomer)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.message = res.outputInfo;
            this.showSuccess(this.message);
            this.router.navigate(['/Customers']);
          },
          error: (e) => console.error(e)
        });
    }
  }

  deleteCustomer(): void {
    this.message = '';
    this.customerService.delete(this.currentCustomer.customerId)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.outputInfo;
          this.showSuccess(this.message);
          this.router.navigate(['/Customers']);
        },
        error: (e) => console.error(e)
      });
  }

  showSuccess(successMessage : any){
    this.toastr.success(successMessage);
  }

}
