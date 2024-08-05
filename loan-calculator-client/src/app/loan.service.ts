import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  private apiUrl = 'http://localhost:5264/api/Loan'; // Update this URL to match your backend API endpoint

  constructor(private http: HttpClient) { }

  getLoanDetails(data: { clientId: string, amount: number, periodInMonths: number }): Observable<any> {
    return this.http.post<any>(this.apiUrl, data);
  }
}