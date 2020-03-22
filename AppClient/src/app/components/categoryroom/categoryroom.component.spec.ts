import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryroomComponent } from './categoryroom.component';

describe('CategoryroomComponent', () => {
  let component: CategoryroomComponent;
  let fixture: ComponentFixture<CategoryroomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryroomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryroomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
