import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { shareReplay, startWith, map } from 'rxjs/operators';
import { MoistureService } from 'src/providers/moisture/moisture.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public moisture$: Observable<number | string>;

  public constructor(private moistureService: MoistureService) { }

  ngOnInit(): void {
    this.moisture$ = this.moistureService.getMoisture().pipe(
      shareReplay(1)
    );
  }
}
