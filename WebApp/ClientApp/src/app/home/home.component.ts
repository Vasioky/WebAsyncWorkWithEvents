import { Component, Input, OnInit } from '@angular/core';
import { WorkServiceService, SignalRService } from "../services"
import { Work } from '../services/model/work';
import { Batch } from '../services/model/batch';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  @Input() x: number = 1;
  @Input() y: number = 1;
  workIsDone: boolean;
  work: Work;
  constructor(
    private workServiceService: WorkServiceService,
    private signalRService: SignalRService
  ) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener(this.onMessage.bind(this));
  }
  heders() {
    return Array(this.y).fill(0).map((x, i) => 'val ' + i);
  }
  onStart() {
    this.workIsDone = true;
    this.workServiceService.startWork(this.x, this.y)
      .subscribe(x => {
        this.work = x;
        this.workIsDone = false;
      });
  }
  onMessage(batch: Batch) {
    debugger;
    const index = this.work.batches.findIndex(b => b.id == batch.id);
    this.work.batches[index] = batch;
  }
  onClean() {
    this.work = null;
    this.workIsDone = false;
  }
}
