import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurpValidationComponent } from './curp-validation.component';

describe('CurpValidationComponent', () => {
  let component: CurpValidationComponent;
  let fixture: ComponentFixture<CurpValidationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CurpValidationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CurpValidationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
