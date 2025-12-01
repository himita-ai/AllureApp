import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-layout',
  templateUrl: './user-layout.component.html',
  styleUrls: ['./user-layout.component.scss']
})
export class UserLayoutComponent implements OnInit, OnDestroy {
  
  bannerImage = "assets/front_page1.jpg"; // default image
  private images: string[] = [
    "assets/front_page 1.jpg",
    "assets/front_page2.jpg",
    "assets/front_page 3.jpg",
    "assets/front_page 4.jpg",
    // "assets/front_page5.jpg"
  ];
  private currentIndex = 0;
  private intervalId: any;

  constructor(private api: ApiService, private toastr: ToastrService, private router: Router) {}

  ngOnInit(): void {
    this.startImageTransition();
  }

  ngOnDestroy(): void {
    if (this.intervalId) clearInterval(this.intervalId);
  }

  startImageTransition() {
    this.intervalId = setInterval(() => {
      this.currentIndex = (this.currentIndex + 1) % this.images.length;
      this.bannerImage = this.images[this.currentIndex];
    }, 2000); // 2 seconds
  }

  goToProducts(): void {
    this.router.navigate(['/admin/product']);
  }

  goToLogin(): void {
    this.router.navigate(['/admin/login']);
  }
  goToCart():void{
    this.router.navigate(['admin/cart']);
  }
}
