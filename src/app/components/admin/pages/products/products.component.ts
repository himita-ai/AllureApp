// import { Component, OnInit, TemplateRef } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { MatTableDataSource } from '@angular/material/table';
// import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
// import { ToastrService } from 'ngx-toastr';
// import { ApiService } from 'src/app/services/api.service';

// @Component({
//   selector: 'app-products',
//   templateUrl: './products.component.html',
//   styleUrls: ['./products.component.scss']
// })
// export class ProductsComponent implements OnInit {

//   displayedColumns: string[] = ['count', 'name', 'description', 'qty', 'price','image', 'action'] ;
//   dataSource: MatTableDataSource<any>;
//   productForm:FormGroup;
//   products:any[]=[];
//   editModal:boolean=false;
//   categoryList:any[]=[];
//   subCategoryList:any[]=[];

//   constructor(private api: ApiService, private toastr:ToastrService ,private fb:FormBuilder, private modalService: NgbModal) { 
//     this.productForm=this.fb.group({
//       productName:['',[Validators.required,Validators.minLength(5),Validators.maxLength(15)]],
//       productDescription:['',[Validators.required,Validators.minLength(10),Validators.maxLength(50)]],
//       quantity:['',[Validators.required,Validators.min(5)]],
//       price:['',[Validators.required,Validators.min(100)]],
//       categoryId:['',[Validators.required]],
//       subCatId:['',[Validators.required]],
      
//   })
// }

//   ngOnInit(): void {
//     this.loadApi();
//   }
//   loadApi(){
//     this.getProduct();
//     this.getAllCategories();
//   }
//   getProduct(){
//     this.api.getProducts().subscribe(data=>{
//       if(data.Success){
//         this.products=data.Result;
//         console.log(this.products)
//         this.dataSource=new MatTableDataSource(this.products);
//       }
//       else{
//         this.toastr.error('Something went wrong','Error');
//       }
//     })
//   }
//   getAllCategories(){
//     this.api.getCategories().subscribe(data=>{
//       if(data.Success){
//         this.categoryList=data.Result;
//         console.log(this.categoryList)
//       }
//       else{
//         this.toastr.error('Something went wrong','Error');
//       }
//     })
//   }
//   get f(){
//     return this.productForm.controls;
//   }

//   editProduct(product:any){
//     console.log( product);
//   }
//   deleteProduct(product:any){
//     console.log( product);
//   }
//   OnSubmit(){

//     let obj=this.productForm.value;
//     console.log(obj);
//     if(!this.productForm.valid)this.toastr.error('Please fill all the required fields','Error')
//      else{
//     let productObj={
    
//       ProductName: obj.productName,
//       ProductDescription: obj.productDescription,
//       Quantity: obj.quantity,
//       UnitPrice: obj.price,
//      SubCatId: obj.subCatId

//     }
//     this.api.saveProduct(productObj).subscribe({
//      next:resp=>{
//       if(resp.Success){
//         this.toastr.success('Product saved successfully','Success');
       
//         this.getProduct();
//         this.closeModal();
//       }
//       else{
//         this.toastr.error('Something went wrong','Error');
//       }
//      },
//      error:err=>{
//       console.log(err);
//       this.toastr.error('Something went wrong','Error');
//      }

//     }
//     )
//   }
// }

//   openModal(content:TemplateRef<any>){
//     this.modalService.open(content);
//     this.productForm.reset();

//   }
//   closeModal(){
//     this.modalService.dismissAll();
//     this.productForm.reset();
//   }

//   getSubCategory(event:any){
//     let id = this.productForm.controls['categoryId'].value
//     console.log(id);
//     let selectedCategory=this.categoryList.find(c=>c.Id == id);
//     this.subCategoryList=selectedCategory? selectedCategory.SubCategories:[];
//     console.log(this.subCategoryList);

// }
// }
import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
interface Products{
  Id:number;
 
  ProductName: string;
  ProductDescription: string;
  Quantity: number;
  UnitPrice: number;
  Currency: string;
  ImageFile: string; // base64 image string
}
 @Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
    products:any[]=[];
  

  constructor( private api: ApiService, private toastr:ToastrService,private router:Router ) { }

  ngOnInit(): void {
    this.getFrontPage();
  }
    getFrontPage(){
      this.api.getProducts().subscribe(data=>{
        if(data.Success){
          this.products=data.Result;
          console.log(this.products)
          
        }
        else{
          this.toastr.error('Something went wrong','Error');
        }
      })
    }
}
