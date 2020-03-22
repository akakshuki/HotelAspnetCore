import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryroomComponent } from './components/categoryroom/categoryroom.component';
import { MainPageComponent } from './components/main-page/main-page.component';


const routes: Routes = [
  { path: '', component: MainPageComponent   },
  { path: 'categoryRoom', component: CategoryroomComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
