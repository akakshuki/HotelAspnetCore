import { Injectable } from '@angular/core';
import { CategoryRoomMv } from '../models/categoryRoom.model';

import { from, Observable, throwError, of } from 'rxjs';
import { map, catchError, tap, retry } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CategoryroomService {
  categoryRooms: CategoryRoomMv[];
  private object: string;
  private headers: HttpHeaders;

  

  constructor(private client: HttpClient
  ) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8'});
    this.object = "CategoryRooms";
  }



  private handleError(error: any) {
    console.log(error);
    return throwError(error);
  }

  getcategoryRoom() : Observable<CategoryRoomMv[]> {
    return this.client.get<CategoryRoomMv[]>(environment.baseUrl + this.object).pipe(retry(1));
      }
 
}
