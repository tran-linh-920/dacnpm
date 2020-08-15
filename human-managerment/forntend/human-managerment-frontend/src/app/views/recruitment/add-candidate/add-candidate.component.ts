import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Candidate } from '../../../models/candidate';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CandidateService } from './../../../services/candidate.service';


@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.css']
})
export class AddCandidateComponent implements OnInit {
  genders = [{value: true, name: 'Nam'}, {value: false, name: 'Nữ'}];
  image: File;
  imgName: string = 'Choose file';
  img: any = 'https://screenshotlayer.com/images/assets/placeholder.png';
  candidate: Candidate = { id: 0 } as Candidate;
  saveForm: FormGroup;

  constructor( private router: Router, private fb: FormBuilder, private candidateService: CandidateService) { 
    this.saveForm = this.fb.group({
      firstname: [''],
      lastname: [''],
      birthDay:[''],
      gender: [''],
      email: [''],
      phoneNumber: [''],
      ethnic: [''],
      hometown: [''],
      IDCard: [''],
      degree: [''],
      career: [''],
      experience: [''],
      literacy: [''],
      skill: [''],
      hobby: [''],
      position: [''],
      file:['']
      });
  }

  ngOnInit(): void { 
  }

  selectFile(event) {
    this.image = event.target.files.item(0);
    console.log(this.image);
  }

  save() {
    this.candidateService.addCandidate(this.image, this.candidate).subscribe(res =>{
      console.log(res);
      this.router.navigateByUrl('tuyen-dung/tuyen-nhan-su');

    });
  }

  preview(files) {
    if (files.length === 0)
    return;
    var mimeType = files[0].type;
    this.imgName = files[0].name;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }

    var reader = new FileReader();
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.img = reader.result;

    }
  }
}
