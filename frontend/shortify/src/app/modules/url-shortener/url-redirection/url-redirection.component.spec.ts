import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlRedirectionComponent } from './url-redirection.component';

describe('UrlRedirectionComponent', () => {
  let component: UrlRedirectionComponent;
  let fixture: ComponentFixture<UrlRedirectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrlRedirectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlRedirectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
