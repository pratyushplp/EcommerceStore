import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router : Router, private toastr : ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
          if(error)
          {
            if(error.status === 400 || (error.statusCode === 400))
            {
              if(error.error.errors) // for validation error, error.errors contains the list of validation errors present
              {
                throw error.error; 
              }
              else
              {
                this.toastr.error(error.error.message, error.error.statusCode)
              }
            }
            if(error.status === 401)
            {
              this.toastr.error(error.error.message, error.error.statusCode)
            }


            if(error.status === 404) this.router.navigateByUrl('/not-found')

            if(error.status === 500)
            {
              //pass  states via the router to the route we are redirecting (navigatng) to.
              //from test-error we intercept sever error and redirect to server-error page. In this process we pass  states to server-error page using a router
              const navigationExtras : NavigationExtras = {state : {error: error.error}};
            
              this.router.navigateByUrl('/server-error', navigationExtras)

            } 

          }
          return throwError(error)
        }
        )


    );
  }
}
