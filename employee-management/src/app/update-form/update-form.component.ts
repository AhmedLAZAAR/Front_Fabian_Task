// update-form.component.ts
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../form/employee.service';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-update-form',
  templateUrl: './update-form.component.html',
  styleUrls: ['./update-form.component.css']
})
export class UpdateFormComponent implements OnInit {

  public id: number;
  details: any = {};

  constructor(private route: ActivatedRoute, private router: Router, private employeeService: EmployeeService) { }
  
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = +params['id']; // convert to number
    
      this.updateEmployeeDetails(this.id);
      console.log("hahowa"+this.id);
    });
    
  }
  
  
  updateEmployeeDetails(id: number) {
    console.log("this.id: " + this.id);
  
    this.employeeService.getByIdEmployees(this.id).subscribe(
      (data: any) => {
        if (Array.isArray(data)) {
          const employee = data.find(e => e.serial === this.id);
          if (employee !== undefined) {
            console.log("Details to be updated:", employee);
            this.details = employee;
          } else {
            console.error(`Employee details not found for id ${this.id}`);
            // Handle this situation as per your application's requirements
            // For example, you might want to redirect to an error page or show a message to the user.
          }
        } else if (typeof data === 'object' && data !== null) {
          console.log("Details to be updated:", data);
          this.details = data;
        } else {
          console.error('Unexpected response format:', data);
          // Handle this situation as per your application's requirements
          // For example, you might want to redirect to an error page or show a message to the user.
        }
      },
      error => {
        console.error('Error fetching employee details:', error);
        // Handle the error situation as needed
      }
    );
  }
  
  



  userUpdateInfo(form: NgForm) {
    const updatedInfo = {
      name: form.value.Name,
      gender: form.value.Gender,
      phone: form.value.Phone,
      birthday: form.value.Birthday,
      jobTitle: form.value.JobTitle,
      jobRank: form.value.JobRank,
    };

    this.employeeService.updateEmployee(this.id, updatedInfo)
    .subscribe(
      () => {
        console.log(`Employee details updated for id ${this.id}`);
        this.router.navigateByUrl('/employee-list');
      },
      (error) => {
        console.error('Error updating employee details:', error);
        // Handle the error appropriately (e.g., show an error message to the user).
      }
    );
  }
}
