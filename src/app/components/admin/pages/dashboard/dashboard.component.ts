import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/services/api.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  displayedColumns: string[] = ['count', 'name', 'description', 'qty', 'price','image', 'action'] ;
   dataSource: MatTableDataSource<any>;
   productForm:FormGroup;
   products:any[]=[];
    file:any;
    productImage:any;
    productId:number=0;
   editModal:boolean=false;
   categoryList:any[]=[];
   subCategoryList:any[]=[];
 
   constructor(private api: ApiService, private toastr:ToastrService ,private fb:FormBuilder, private modalService: NgbModal) { 
     this.productForm=this.fb.group({
      id: [0],
       productName:['',[Validators.required,Validators.minLength(5),Validators.maxLength(15)]],
       productDescription:['',[Validators.required,Validators.minLength(10),Validators.maxLength(50)]],
       quantity:['',[Validators.required,Validators.min(5)]],
       price:['',[Validators.required,Validators.min(100)]],
       categoryId:['',[Validators.required]],
       subCatId:['',[Validators.required]],
       
   })
 }
 
   ngOnInit(): void {
     this.loadApi();
   }
   loadApi(){
     this.getProduct();
     this.getAllCategories();
   }
   getProduct(){
     this.api.getProducts().subscribe(data=>{
       if(data.Success){
         this.products=data.Result;
         console.log(this.products)
         this.dataSource=new MatTableDataSource(this.products);
       }
       else{
         this.toastr.error('Something went wrong','Error');
       }
     })
   }
   getAllCategories(){
     this.api.getCategories().subscribe(data=>{
       if(data.Success){
         this.categoryList=data.Result;
         console.log(this.categoryList)
       }
       else{
         this.toastr.error('Something went wrong','Error');
       }
     })
   }
   get f(){
     return this.productForm.controls;
   }
 
   editProduct(product:any, content:TemplateRef<any>){
    this.editModal=true;
     console.log( product)
     this.modalService.open(content);
     this.productForm.patchValue({
      id:product.Id,
      productName:product.ProductName,
      productDescription:product.ProductDescription,
      quantity:product.Quantity,
      price:product.UnitPrice,
      categoryId:product.CategoryId,
      subCatId:product.SubCatId
     })
     console.log(this.productForm.value);
     this.getSubCategory();
     this.getProduct();
   }
   deleteProduct(id:any){
     console.log( id)
     if(id != null){
      this.api.deleteProduct(id).subscribe(data=>{
        this.toastr.success('Product deleted successfully','Success');
        this.getProduct();
      })
     }

   }
   OnSubmit(){
 
     let obj=this.productForm.value;
     console.log(obj);
     if(!this.productForm.valid)this.toastr.error('Please fill all the required fields','Error')
      else{
     let productObj={
     Id:obj.id,
       ProductName: obj.productName,
       ProductDescription: obj.productDescription,
       Quantity: obj.quantity,
       UnitPrice: obj.price,
      subCatId: obj.SubCatId
 
     }
     this.api.saveProduct(productObj).subscribe({
      next:resp=>{
       if(resp.Success){
         this.toastr.success('Product saved successfully','Success');
        
         this.getProduct();
         this.closeModal();
       }
       else{
         this.toastr.error('Something went wrong','Error');
       }
      },
      error:err=>{
       console.log(err);
       this.toastr.error('Something went wrong','Error');
      }
 
     }
     )
   }
 }
 
   openModal(content:TemplateRef<any>){
     this.modalService.open(content);
     this.productForm.reset();
    
 
   }
   closeModal(){
     this.modalService.dismissAll();
     this.productForm.reset();
   }
 
   getSubCategory(){
     let id = this.productForm.controls['categoryId'].value
     console.log(id);
     let selectedCategory=this.categoryList.find(c=>c.Id == id);
     this.subCategoryList=selectedCategory? selectedCategory.SubCategories:[];
     console.log(this.subCategoryList);
 

 }
 //Image section
 openImageModal( content: TemplateRef<any>, id :any){
  console.log(id);
    this.modalService.open(content);  
    this.productId=id;
 }
 closeImageModal(){ 
    this.modalService.dismissAll();
}
UploadImage(){
  // console.log(this.productId,"File,",this.file);
  let form=new FormData();
  form.append('file',this.file);
  this.api.saveImage(form,this.productId).subscribe(data=>{
    if(data.Success){
      this.toastr.success('Image uploaded successfully','Success');
      this.closeImageModal();
      this.getProduct();
    }
    else{
      this.toastr.error('Something went wrong','Error');
    }

  }
)}
readImageFile(event:any){ 
  let reader=new FileReader();
  this.file=event.target.files[0];
  reader.readAsDataURL(this.file);
  reader.onload=()=>{
    this.productImage=reader.result ;
  }

}
}