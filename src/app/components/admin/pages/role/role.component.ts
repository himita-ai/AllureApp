
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})

export class RoleComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'view', 'edit', 'action'];
  dataSource:  MatTableDataSource<any>;

  roleForm: FormGroup;
  selectedValue: any = 'True';

  constructor(private apiService: ApiService, private fb: FormBuilder, private modalServie: NgbModal, private toastr: ToastrService) {
     this.roleForm = this.fb.group({
       RoleName: ['', Validators.required],
       View: [this.selectedValue, Validators.required],
       Edit: [this.selectedValue, Validators.required],
     })
   }

  ngOnInit(): void {
    this.loadApi();
  }

  loadApi(){
    this.getRoles();
  }

  getRoles(){
    this.apiService.getAllRoles().subscribe({
      next: resp => {
         console.log(resp);
         this.dataSource = new MatTableDataSource(resp.Result);
      },
      error: err => console.log(err)
    })
  }

  openModal(content: TemplateRef<any>){
    this.modalServie.open(content);
  }

  onSubmit(){
    console.log(this.roleForm.value);
    if(!this.roleForm.valid){
        this.toastr.error('Invalid input', 'Error!')
    }
    else{
      let obj = this.roleForm.value;
      this.apiService.saveRole(obj).subscribe({
        next: resp => {
          console.log(resp);
          if(resp.Success){
            this.toastr.success('Record saved successfully', 'Success!')
            this.roleForm.reset();
            this.modalServie.dismissAll();
            this.getRoles();
          }
        }
      })
    }
  }

  


}
