import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.scss']
})
export class AddCustomerComponent implements OnInit {
  registerForm: FormGroup;
  customer: Customer = {
    customerName: '',
    customerPNum: '',
    customerAddress: '',
    customerEmail: ''
  };

  submitted = false;
  message = '';

  constructor(private customerService: CustomerService, private formBuilder: FormBuilder,private router: Router,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.message = '';
    this.registerForm = this.formBuilder.group({
      customerName: ['', Validators.required],
      customerPNum:['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      customerAddress: ['', Validators.required],
      customerEmail: ['', [Validators.required, Validators.email]],
    });
  }

  get f() { return this.registerForm.controls; }

  saveCustomer(): void {
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }
    else{
      const data = {
        customerName: this.customer.customerName,
        customerPNum: this.customer.customerPNum,
        customerAddress: this.customer.customerAddress,
        customerEmail: this.customer.customerEmail
      };
      this.customerService.create(data)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.message = res.outputInfo;
            this.submitted = true;
            this.showSuccess(this.message);
            this.router.navigate(['/Customers']);
          },
          error: (e) => console.error(e)
        });
    }
  }

  newCustomer(): void {
    this.submitted = false;
    this.customer = {
      customerName: '',
      customerPNum: '',
      customerAddress: '',
      customerEmail: ''
    };
  }

  showSuccess(successMessage : any){
    this.toastr.success(successMessage);
  }

}
