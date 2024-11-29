import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanMatch, Route, UrlSegment, GuardResult, MaybeAsync, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable, tap } from 'rxjs';
import { isJSDocAuthorTag } from 'typescript';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanMatch, CanActivate {

  constructor( private authService: AuthService,
    private router: Router
  ) { }

  private checkAuthStatus(): boolean | Observable<boolean> {

    return this.authService.checkAuthentication()
    .pipe(
      // tap( isAuthenticated => console.log('Authenticated:', isAuthenticated) ),
      tap( isAuthenticated => {
        if( !isAuthenticated ) {
          this.router.navigate(['auth/login']);
        }
      }),
    )

  }

  canMatch(route: Route, segments: UrlSegment[]): MaybeAsync<GuardResult> {
    // console.log('Can Match');
    // console.log({ route, segments})

    return this.checkAuthStatus();
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {

    // console.log('Can Activate')
    // console.log({ route, state })

    return this.checkAuthStatus();
  }

}
