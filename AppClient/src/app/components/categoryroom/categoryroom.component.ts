import { Component, OnInit } from '@angular/core';
import { CategoryroomService } from 'src/app/services/categoryroom.service';
import { CategoryRoomMv } from 'src/app/models/categoryRoom.model';
@Component({
  selector: 'app-categoryroom',
  templateUrl: './categoryroom.component.html',
  styleUrls: ['./categoryroom.component.css']
})
export class CategoryroomComponent implements OnInit {
  categoryrooms: CategoryRoomMv[];
  constructor(private categoryroomService: CategoryroomService) {
  }

  ngOnInit() {
  
    this.categoryroomService.getcategoryRoom()
      .subscribe(res => {
        this.categoryrooms = res;
      });

  }

}
