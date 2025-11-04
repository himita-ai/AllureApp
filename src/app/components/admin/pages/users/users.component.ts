import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  userList: any;
  roles: any[] = [];
  selectedItems: any;
  dropdownData: any[] = [];
  dropdownSettings = {};

  displayedColumns: string[] = ['count', 'firstName', 'lastName', 'email', 'number', 'address', 'action'];
  dataSource: MatTableDataSource<any>;

  assignRoleForm: FormGroup

  constructor(private apiService: ApiService, private modalService: NgbModal, private fb: FormBuilder, private toastr: ToastrService) {

    this.assignRoleForm = this.fb.group({
        RoleName: ['', Validators.required],
        Users: ['', Validators.required]
    })
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'Id',
      textField: 'Name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: false
    };
   }

  ngOnInit(): void {
    this.loadApi();
  }

  loadApi(){
     this.getUser();
     this.getRoles();
  }

  getUser() {
    this.apiService.getAllUser().subscribe(data => {
      //console.log(data);
      if (data.Success) {
        this.userList = data.Result;
        console.log(this.userList);
        this.dataSource = new MatTableDataSource(this.userList);

        this.dropdownData = this.userList.map((obj: any) => ({Id: obj.Id, Name: obj.FirstName}));
        console.log(this.dropdownData);
      }
    })
  }

  getRoles(){
    this.apiService.getAllRoles().subscribe(data => {
      //console.log(data);
      if(data.Success){
        this.roles = data.Result;
        console.log(this.roles)
      }
    })
  }

  editUser(obj: any){

  }

  deleteUser(obj: any){

  }

  openModal(content: TemplateRef<any>){
      this.modalService.open(content);
  }

  closeModal(){
    this.modalService.dismissAll();
    this.assignRoleForm.reset();
  }

  onItemSelect(event: any){
    console.log(event)
  }

  onSelectAll(event: any){
    console.log(event);
  }
  
  onSubmit(){
     console.log(this.assignRoleForm.value);
     let ids = this.assignRoleForm.controls['Users'].value.map((x: any) => x.Id);
     console.log(ids);
     if(this.assignRoleForm.valid){
      let obj = {
        RoleName: this.assignRoleForm.controls['RoleName'].value,
        UserIds: ids
      }
        this.apiService.assignRole(obj).subscribe({
          next: resp => {
            if(resp.Success){
               this.toastr.success('Record updated successfully', 'Success!');
               this.assignRoleForm.reset();
               this.modalService.dismissAll();
            }
            else{
              this.toastr.error('Something went wrong', 'Error');
            }
          }
        })
     }
  }
}