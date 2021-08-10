import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() pageSize :number;
  @Input() totalCount :number;
  @Output() onPageChanged = new EventEmitter<number>();

  onPagerPageChanged(event : any)
  {
    this.onPageChanged.emit(event.page)
  }


}
