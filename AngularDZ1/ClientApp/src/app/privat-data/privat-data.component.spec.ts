import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivatDataComponent } from './privat-data.component';

describe('PrivatDataComponent', () => {
  let component: PrivatDataComponent;
  let fixture: ComponentFixture<PrivatDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrivatDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivatDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
