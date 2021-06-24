import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';
import { JobService } from '../services/job.service';
import { JobModel } from '../models/job.model';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  public engineers: string[] = [];
  public customers: CustomerModel[] = [];

  public jobs: JobModel[] = [];

  public newJob: JobModel = {
    jobId: null,
    engineer: null,
    when: null,
    customerId: null
  };

  constructor(
    private engineerService: EngineerService,
    private jobService: JobService,
    private customerService: CustomerService  ) { }

  ngOnInit() {
    this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
    this.updateList();
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createJob(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.jobService.CreateJob(this.newJob).then(() => {
        this.updateList();
        this.newJob= {
          jobId: null,
          engineer: null,
          when: null,
          customerId: null
        };
      });
    }
  }

  private updateList(): void {
    this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
  }

}
