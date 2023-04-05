import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortUrlsContainerComponent } from './short-urls-container.component';

describe('ShortUrlsContainerComponent', () => {
  let component: ShortUrlsContainerComponent;
  let fixture: ComponentFixture<ShortUrlsContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShortUrlsContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShortUrlsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
