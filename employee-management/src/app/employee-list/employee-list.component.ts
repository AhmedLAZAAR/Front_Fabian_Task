import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../form/employee.service';
import { UpdateFormComponent } from '../update-form/update-form.component';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private employeeService: EmployeeService, private router: Router) { }

  employees: any;
  private updateEmployee: UpdateFormComponent;
  ngOnInit() {
    this.getEmployees();
    
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe(
      (data: any) => {
        this.employees = data;
        console.log("Employees from backend:", this.employees);
      },
      (error) => {
        console.error("Error fetching employees:", error);
      }
    );
  }

  editEmployeeDetails(id: number) {
    console.log(id);
    this.router.navigate(['update-form-details/', id]);
    this.updateEmployee.updateEmployeeDetails(id);
  }

  deleteEmployeeDetails(id: number) {
    this.employeeService.deleteEmployee(id).subscribe(
      () => {
        console.log("Employee deleted successfully");
        this.getEmployees(); // Refresh the list after deletion
      },
      (error) => {
        console.error("Error deleting employee:", error);
      }
    );
  }
}
