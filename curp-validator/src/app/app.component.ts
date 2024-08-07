import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CurpValidationComponent } from './curp-validation/curp-validation.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CurpValidationComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'curp-validator';
}
