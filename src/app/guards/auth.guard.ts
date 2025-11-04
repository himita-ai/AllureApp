import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import{ AuthService } from 'src/app/services/auth.service';
import {  ToastrService } from 'ngx-toastr';
import { jwtDecode } from 'jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor( private auth: AuthService, private router: Router, private toastr:ToastrService) {}

  canActivate() { 
    console.log('Auth Guard is calling');
    
    if(this.auth.isLoggedIn() && this.auth.isTokenExpired()){
       const token = this.auth.getToken();
       return true;
    }
    else{
       this.toastr.error('Login First!', 'Error!');
       this.router.navigate(['/admin/login']);
       return false;
    }
  }
  
}

interface JwtPayload{
    aud: string;
    role: string;
    name: string;
}

