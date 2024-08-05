import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoanService } from '../loan.service';

@Component({
  selector: 'app-loan-form',
  templateUrl: './loan-form.component.html',
  styleUrls: ['./loan-form.component.css']
})
export class LoanFormComponent {
  loanForm: FormGroup;
  loanDetails: any;
  formattedLoanDetails: string | null = null;

  constructor(private fb: FormBuilder, private loanService: LoanService) {
    this.loanForm = this.fb.group({
      clientId: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(1)]],
      periodInMonths: ['', [Validators.required, Validators.min(12)]]
    });
  }

  get f() { return this.loanForm.controls; }

  onSubmit() {
    if (this.loanForm.valid) {
      this.loanService.getLoanDetails(this.loanForm.value).subscribe(data => {
        this.loanDetails = data;
        this.formattedLoanDetails = this.formatLoanDetails(data);
      });
    }
  }

  formatLoanDetails(data: any): string {
    debugger;
    const baseInterestPercentage = (data.baseInterestPrecentage * 100).toFixed(2);
    const extraPeriodInterestPercentage = (data.extraPeriodInterestPrecentage * 100).toFixed(2);
    const baseTotalAmount = data.baseTotalAmount.toFixed(2);
    const extraPeriodTotalAmount = data.extraPeriodTotalAmount.toFixed(2);
    const extraPeriod: number = data.extraPeriod;
    const totalAmount = data.totalAmount.toFixed(2);

    var result= `The Client basic loan interest by his age and loan amount is ${baseInterestPercentage}% = ${baseTotalAmount} nis ` ;
    if(extraPeriod>0){
      result+=`and for the extra ${extraPeriod} months is ${extraPeriodInterestPercentage}% = ${extraPeriodTotalAmount} nis, `;
    }
    result+=`so the total amount is ${totalAmount} nis.`;
    return result;
  }
}