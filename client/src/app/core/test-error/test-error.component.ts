import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {

  validationErrors : any;

  constructor(private httpClient : HttpClient) { }

  ngOnInit(): void {
  }


  get404Error()
  {
    return this.httpClient.get(environment.apiUrl + 'Buggy/NotFound').subscribe(response => console.log(response), error => console.log(error));
  }

  get500Error()
  {
    return this.httpClient.get(environment.apiUrl + 'Buggy/ServerError').subscribe(response => console.log(response), error => console.log(error));
  }

  get400Error()
  {
    return this.httpClient.get(environment.apiUrl + 'Buggy/BadRequest').subscribe(response => console.log(response), error => console.log(error));
  }

  getValidationError()
  {
      return this.httpClient.get(environment.apiUrl + 'product/fortytwo').subscribe(response => console.log(response), error => 
      {
        console.log(error)
        this.validationErrors = error.errors;
      }
      );
  }

}
