import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public customers: ICustomer[];
  public page: number = 1;
  public pageSize: number = 10;
  public collectionSize: number;
  public httpObj: HttpClient;
  public baseUrlAddress:string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpObj = http;
    this.baseUrlAddress = baseUrl;
    this.getData();
  }

  public getData(): void {
    this.httpObj.post<ICustomer[]>(this.baseUrlAddress + 'api/fpt/' + 'getCustomers', {
      "page": this.page,
      "itemsPerPage": this.pageSize
    }).subscribe(result => {
      this.customers = result;
      this.collectionSize = this.customers[0].totalCount;

    }, error => console.error(error));

  }

  public onPageChange(pageNum: number): void {
    this.page = pageNum;
    this.getData();
  }

  public changePagesize(num: number): void {
    this.pageSize = this.pageSize + num;
    this.getData();
    
  }
  
}

interface IPager {
  page: number;
  itemsPerPage: number;
}

interface ICustomer {
  id: number;
  name: string;
  phone: string;
  email: string;
  notes: string;
  totalCount : number;
}
