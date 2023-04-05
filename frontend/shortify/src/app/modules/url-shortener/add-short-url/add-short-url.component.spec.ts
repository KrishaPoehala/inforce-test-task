import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShortUrlComponent } from './add-short-url.component';

describe('AddShortUrlComponent', () => {
  let component: AddShortUrlComponent;
  let fixture: ComponentFixture<AddShortUrlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddShortUrlComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddShortUrlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
