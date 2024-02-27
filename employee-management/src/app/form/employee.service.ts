import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private apiUrl = 'http://localhost:32769/api/DDD'; // Adjust the URL

  constructor(private http: HttpClient) {}

  createEmployee(employeeInfo: any): Observable<any> {
    // Set Content-Type header to application/json
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // Add any other headers if needed
    });

    // Sending employeeInfo as the request body
    return this.http.post(this.apiUrl, employeeInfo, { headers });
  }

  getEmployees(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
  
  getByIdEmployees(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    console.log("hada" + url);

    return this.http.get(url).pipe(
      map((response: any) => {
        if (Array.isArray(response)) {
          return response.find(item => item.id === id);
        } else if (typeof response === 'object' && response !== null) {
          return response;
        } else {
          console.error('Unexpected response format:', response);
          return null;
        }
      })
    );
  }
  
  

  // Update (Edit) an existing employee
  updateEmployee(id: number, updatedEmployee: any): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    console.log("the id is "+id);
    console.log("hada ggg "+url);
    return this.http.put(url, updatedEmployee, { headers });
  }
  

  // Delete an employee by ID
  deleteEmployee(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
  // You can add more methods for other CRUD operations or additional functionality
}
