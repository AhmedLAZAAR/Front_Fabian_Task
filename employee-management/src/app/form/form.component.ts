import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeService } from './employee.service'; // Adjust the path based on your directory structure
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent implements OnInit {
  employeeInfo: any = {};

  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {}

  userInfo(form: NgForm) {
    this.employeeService.createEmployee(this.employeeInfo).subscribe(
      (response) => {
        console.log('Employee created successfully:', response);
        // Handle success, if needed
      },
      (error: HttpErrorResponse) => {
        console.error('Error creating employee:', error);

        // Log additional error details
        console.error('Status:', error.status);
        console.error('Status Text:', error.statusText);
        console.error('Headers:', error.headers);

        // Handle error, if needed
      }
    );

    form.reset();
  }
}
