import { AuthenticationserviceService } from './authenticationservice.service';
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthguardService implements CanActivate {
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authService.currentUser;
    if (currentUser == null){
        alert("You don't have a permission to access this page.");
        return false;
    }
    else{
        if(route.data.roles && route.data.roles.indexOf(currentUser.role)===-1){
            alert("You don't have a permission to access this page.");
            this.router.navigate(['/home']);
            return false;
        }
        return true;
    }
  }
  constructor(private router: Router, private authService: AuthenticationserviceService) { }
}
