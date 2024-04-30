import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ConectareAngularDotNetService } from './conectare-angular-dot-net.service';

@Component({
  selector: 'app-root',
  template: `
    <h2>Games List</h2>
    <ul>
      <li *ngFor="let game of games">
        {{ game.title }} - {{ game.genre }}
      </li>
    </ul>
  `,
  styleUrl: './app.component.css'
})
export class MyComponent implements OnInit {
  data: any[] = [];

  constructor(private conectare: ConectareAngularDotNetService) {}

  ngOnInit(): void {
    this.conectare.getDataFromEndpoint().subscribe((result) => {
      this.data = result;
    });
  }

  title = 'proiectii.client';
}
