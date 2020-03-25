import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryroomComponent } from './components/categoryroom/categoryroom.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { DetailBookingComponent } from '../app/components/detail-booking/detail-booking.component';


const routes: Routes = [
  { path: '', component: MainPageComponent   },
  { path: 'categoryRoom', component: CategoryroomComponent },
  { path: 'booking/:id', component: DetailBookingComponent  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
