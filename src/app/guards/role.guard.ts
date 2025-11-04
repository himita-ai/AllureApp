import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(private auth: AuthService,private router:Router) {}
  canActivate(
    route: ActivatedRouteSnapshot): boolean {
      const allowedRoles= route.data['roles'] as string[];
      const userRole=this.auth.getUserRole();
      if(userRole && allowedRoles.includes(userRole)){
        return true;
      }
      this.router.navigate(['/admin/login']);
      return false;

    }
   
  }
  

