import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogNavComponent } from './catalog-nav.component';

describe('CatalogNavComponent', () => {
  let component: CatalogNavComponent;
  let fixture: ComponentFixture<CatalogNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CatalogNavComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CatalogNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
